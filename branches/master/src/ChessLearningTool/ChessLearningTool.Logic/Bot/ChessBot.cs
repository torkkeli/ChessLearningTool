using ChessLearningTool.Data;
using ChessLearningTool.Data.Enums;
using ChessLearningTool.Logic.ChessLogic;
using ChessLearningTool.Logic.ChessLogic.Pieces;
using ChessLearningTool.Logic.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChessLearningTool.Logic.Bot
{
    public sealed class ChessBot : IChessBot
    {
        private const int DEPTH = 3;

        public ChessBot(ChessColor color, ChessPosition position)
        {
            Color = color;
            Position = position;
        }

        private ChessColor Color { get; }

        private ChessPosition Position { get; }

        public async Task MakeMove()
        {
            var pieceEvaluations = new List<Task<KeyValuePair<decimal, KeyValuePair<IChessPiece, BoardCoordinates>>>>();
            var positionCopy = Position.Copy();

            foreach (var pieceMoves in LegalMovesForPiece(positionCopy))
            {
                pieceEvaluations.Add(PerformEvaluationForPiece(pieceMoves, positionCopy));
            }

            await Task.WhenAll(pieceEvaluations);

            var evaluations = pieceEvaluations.Select(t => t.Result);
            var candidate = evaluations.FirstOrDefault(kvp => kvp.Key == evaluations.Max(e => e.Key)).Value;
            var realPiece = Position[candidate.Key.Coordinates.Row, candidate.Key.Coordinates.Column];

            realPiece.TryMakeMove(candidate.Value, Position);
        }

        private IDictionary<IChessPiece, IEnumerable<BoardCoordinates>> LegalMovesForPiece(ChessPosition position)
        {
            return position.PiecesOnBoard.Where(p => p.Color == Color).ToDictionary(p => p, p => p.LegalMoves(Position));
        }

        private async Task<KeyValuePair<decimal, KeyValuePair<IChessPiece, BoardCoordinates>>> PerformEvaluationForPiece(
            KeyValuePair<IChessPiece, IEnumerable<BoardCoordinates>> pieceMoves,
            ChessPosition position)
        {
            var candidate = new KeyValuePair<decimal, KeyValuePair<IChessPiece, BoardCoordinates>>(-99999m, new KeyValuePair<IChessPiece, BoardCoordinates>());
            var piece = pieceMoves.Key;

            foreach (var move in pieceMoves.Value)
            {
                var newPosition = position.Copy();
                var newPiece = newPosition[piece.Coordinates];
                newPiece.TryMakeMove(move, newPosition);

                var evaluation = await Evaluate(newPosition, Color);

                if (evaluation > candidate.Key)
                {
                    candidate = new KeyValuePair<decimal, KeyValuePair<IChessPiece, BoardCoordinates>>(
                        evaluation, new KeyValuePair<IChessPiece, BoardCoordinates>(piece, move));
                }
            }

            return candidate;
        }

        private async Task<decimal> Evaluate(ChessPosition position, ChessColor turn, int depth = DEPTH)
        {
            var score = 0m;

            if (depth > 0)
            {
                var evaluations = new List<decimal>();

                foreach (var pieceMoves in LegalMovesForPiece(position))
                {
                    var piece = pieceMoves.Key;
                    var newDepth = depth - 1;

                    foreach (var move in pieceMoves.Value)
                    {
                        var newPosition = position.Copy();
                        var newPiece = newPosition[piece.Coordinates];

                        newPiece.TryMakeMove(move, newPosition);

                        evaluations.Add(await Evaluate(newPosition, turn.Opposite(), newDepth));
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
    }
}
