using ChessLearningTool.Data;
using ChessLearningTool.Data.Enums;
using ChessLearningTool.Logic.ChessLogic;
using ChessLearningTool.Logic.ChessLogic.Pieces;
using ChessLearningTool.Logic.Models;
using System.Collections.Generic;
using System.Linq;

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

        public void MakeMove()
        {
            var candidate = new KeyValuePair<decimal, KeyValuePair<IChessPiece, BoardCoordinates>>(-99999m, new KeyValuePair<IChessPiece, BoardCoordinates>());
            var position = Position.Copy();
            var candidateRow = 0;
            var candidateColumn = 0;

            foreach (var pieceMoves in LegalMovesForPiece(position))
            {
                var piece = pieceMoves.Key;
                var row = piece.Coordinates.Row;
                var column = piece.Coordinates.Column;

                foreach (var move in pieceMoves.Value)
                {
                    var newPosition = Position.Copy();
                    piece.TryMakeMove(move, position);

                    var evaluation = Evaluate(newPosition, Color);

                    if (evaluation > candidate.Key)
                    {
                        candidate = new KeyValuePair<decimal, KeyValuePair<IChessPiece, BoardCoordinates>>(
                            evaluation, new KeyValuePair<IChessPiece, BoardCoordinates>(piece, move));

                        candidateRow = row;
                        candidateColumn = column;
                    }

                    piece.Coordinates = new BoardCoordinates(row, column);
                }
            }

            var realPiece = Position[candidateRow, candidateColumn];

            realPiece.TryMakeMove(candidate.Value.Value, Position);
        }

        private IDictionary<IChessPiece, IEnumerable<BoardCoordinates>> LegalMovesForPiece(ChessPosition position)
        {
            return position.PiecesOnBoard.Where(p => p.Color == Color).ToDictionary(p => p, p => p.LegalMoves(Position));
        }

        private decimal Evaluate(ChessPosition position, ChessColor turn, int depth = DEPTH)
        {
            var score = 0m;

            if (depth > 0)
            {
                var evaluations = new List<decimal>();

                foreach (var pieceMoves in LegalMovesForPiece(position))
                {
                    var piece = pieceMoves.Key;
                    var row = piece.Coordinates.Row;
                    var column = piece.Coordinates.Column;
                    var newDepth = depth - 1;

                    foreach (var move in pieceMoves.Value)
                    {
                        var newPosition = Position.Copy();

                        piece.TryMakeMove(move, newPosition);
                        evaluations.Add(Evaluate(newPosition, turn.Opposite(), newDepth));
                        piece.Coordinates = new BoardCoordinates(row, column);
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
