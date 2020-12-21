using ChessLearningTool.Data.Enums;
using ChessLearningTool.Logic.Models;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace ChessLearningTool.Logic.ChessLogic.Pieces
{
    public abstract class ChessPiece : IChessPiece
    {
        protected ChessPiece(ChessColor color, BoardCoordinates coordinates)
        {
            Color = color;
            Coordinates = coordinates;
        }

        public event Action<ChessMove> MoveMade;

        public abstract Bitmap Image { get; }

        public BoardCoordinates Coordinates { get; private set; }

        public ChessColor Color { get; }

        public abstract decimal Value { get; }

        public void TryMakeMove(BoardCoordinates to, ChessPosition position)
        {
            if (CanMakeMove(to, position))
                MakeMove(to, position);
        }

        protected abstract bool IsMoveLegal(BoardCoordinates square, ChessPosition position);

        protected bool IsPieceBlocking(BoardCoordinates square, ChessPosition position)
        {
            var rowDiff = Coordinates.Row - square.Row;
            var columnDiff = Coordinates.Column - square.Column;
            var squaresMoved = Math.Max(Math.Abs(rowDiff), Math.Abs(columnDiff));

            for (int i = 1; i < squaresMoved; i++)
            {
                var row = rowDiff == 0 ? Coordinates.Row : rowDiff < 0 ? Coordinates.Row + i : Coordinates.Row - i;
                var column = columnDiff == 0 ? Coordinates.Column : columnDiff < 0 ? Coordinates.Column + i : Coordinates.Column - i;

                if (position[row, column] != null)
                    return true;
            }

            return position[square] != null && position[square].Color == Color;
        }

        protected bool IsCapture(BoardCoordinates square, ChessPosition position)
        {
            return position[square] != null && position[square].Color != Color;
        }

        public IEnumerable<BoardCoordinates> LegalMoves(ChessPosition position)
        {
            for (int r = 0; r < 8; r++)
            {
                for (int c = 0; c < 8; c++)
                {
                    var square = new BoardCoordinates(r, c);

                    if (CanMakeMove(square, position))
                    {
                        yield return square;
                    }
                }
            }
        }

        public abstract IChessPiece Copy();

        private bool CanMakeMove(BoardCoordinates to, ChessPosition position)
        {
            return !Coordinates.Equals(to) && IsMoveLegal(to, position);
        }

        private void MakeMove(BoardCoordinates to, ChessPosition position)
        {
            ChessMove move = new ChessMove(Coordinates, to, this);

            MoveMade?.Invoke(move);
            Coordinates = to;
        }
    }
}
