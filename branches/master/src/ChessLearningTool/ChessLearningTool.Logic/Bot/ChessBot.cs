using ChessLearningTool.Data;
using ChessLearningTool.Data.Enums;
using ChessLearningTool.Logic.ChessLogic;
using ChessLearningTool.Logic.ChessLogic.Pieces;
using ChessLearningTool.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChessLearningTool.Logic.Bot
{
    public sealed class ChessBot : IChessBot
    {
        private const int DEPTH = 3;
        private decimal _currentEvaluation = 0m;

        public ChessBot(ChessColor color, ChessPosition position)
        {
            Color = color;
            Position = position;
        }

        private ChessColor Color { get; }

        private ChessPosition Position { get; }

        public async Task MakeMove()
        {
            var pieceEvaluations = new List<Task<List<MoveCandidate>>>();
            var positionCopy = Position.Copy();

            foreach (var pieceMoves in LegalMovesForPiece(positionCopy, Color))
            {
                pieceEvaluations.Add(PerformEvaluationForPiece(pieceMoves, positionCopy));
            }

            await Task.WhenAll(pieceEvaluations);

            var candidates = pieceEvaluations.SelectMany(t => t.Result).ToList();
            var candidate = GetCandidate(candidates);
            var realPiece = Position[candidate.Piece.Coordinates];

            realPiece.TryMakeMove(candidate.Coordinates, Position);
        }

        private static MoveCandidate GetCandidate(IList<MoveCandidate> candidates)
        {
            var random = new Random();
            var evaluation = candidates.Max(c => c.Evaluation);
            var result = candidates.Where(c => c.Evaluation == evaluation);
            var numberOfLegalMoves = result.Max(c => c.NumberOfLegalMoves);
            result = result.Where(c => c.NumberOfLegalMoves == numberOfLegalMoves);

            return result.ElementAt(random.Next(0, result.Count() - 1));
        }

        private IDictionary<IChessPiece, IEnumerable<BoardCoordinates>> LegalMovesForPiece(ChessPosition position, ChessColor color)
        {
            return position.PiecesOnBoard.Where(p => p.Color == color).ToDictionary(p => p, p => p.LegalMoves(position));
        }

        private async Task<List<MoveCandidate>> PerformEvaluationForPiece(
            KeyValuePair<IChessPiece, IEnumerable<BoardCoordinates>> pieceMoves,
            ChessPosition position)
        {
            var candidates = new List<MoveCandidate>();
            var highestScore = -9999m;
            var piece = pieceMoves.Key;

            foreach (var move in pieceMoves.Value)
            {
                var newPosition = position.Copy();
                var newPiece = newPosition[piece.Coordinates];
                var candidate = new MoveCandidate
                {
                    Piece = piece,
                    Coordinates = move,
                    NumberOfLegalMoves = LegalMovesForPiece(newPosition, Color).Sum(p => p.Value.Count())
                };
                newPiece.TryMakeMove(move, newPosition);

                var evaluation = await Evaluate(newPosition, Color.Opposite(), candidate);

                if (evaluation > highestScore)
                {
                    candidate.Evaluation = evaluation;
                    highestScore = evaluation;
                    candidates.Add(candidate);
                }
            }

            return candidates.Where(c => c.Evaluation == highestScore).ToList();
        }

        private async Task<decimal> Evaluate(ChessPosition position, ChessColor turn, MoveCandidate  moveCandidate, int depth = DEPTH)
        {
            var score = 0m;

            if (depth > 0)
            {
                var evaluations = new List<decimal>();

                foreach (var pieceMoves in LegalMovesForPiece(position, turn))
                {
                    var piece = pieceMoves.Key;
                    var newDepth = depth - 1;

                    foreach (var move in pieceMoves.Value)
                    {
                        var newPosition = position.Copy();
                        var newPiece = newPosition[piece.Coordinates];

                        newPiece.TryMakeMove(move, newPosition);

                        evaluations.Add(await Evaluate(newPosition, turn.Opposite(), moveCandidate, newDepth));
                    }
                }

                return turn == Color ? evaluations.Max() : evaluations.Min();
            }
            else
            {
                foreach (var piece in position.PiecesOnBoard)
                {
                    score += piece.Color == Color ? piece.Value : (-piece.Value);
                }
            }

            return score;
        }

        private class MoveCandidate
        {
            public IChessPiece Piece { get; set; }

            public decimal Evaluation { get; set; }

            public BoardCoordinates Coordinates { get; set; }

            public bool AttacksKing { get; set; }

            public int NumberOfLegalMoves { get; set; }
        }
    }
}
