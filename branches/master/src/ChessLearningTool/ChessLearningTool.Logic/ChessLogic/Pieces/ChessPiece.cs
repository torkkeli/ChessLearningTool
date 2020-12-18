using ChessLearningTool.Data.Enums;
using ChessLearningTool.Logic.Models;
using System;
using System.Drawing;
using System.Linq;

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

        protected BoardCoordinates Coordinates { get; private set; }

        public ChessColor Color { get; }

        public void TryMakeMove(BoardCoordinates to, ChessPosition position)
        {
            if (IsMoveLegal(to, position))
            {
                ChessMove move = new ChessMove(Coordinates, to, this);
                
                MoveMade?.Invoke(move);
                Coordinates = to;
            }
        }

        protected abstract bool IsMoveLegal(BoardCoordinates square, ChessPosition position);

        protected bool IsPieceBlocking(BoardCoordinates square, ChessPosition position)
        {
            var rowDiff = Coordinates.Row - square.Row;
            var columnDiff = Coordinates.Column - square.Column;
            var squaresMoved = Math.Max(Math.Abs(rowDiff), Math.Abs(columnDiff));

            for (int i = 1; i <= squaresMoved; i++)
            {
                var row = rowDiff == 0 ? Coordinates.Row : rowDiff < 0 ? Coordinates.Row + i : Coordinates.Row - i;
                var column = columnDiff == 0 ? Coordinates.Column : columnDiff < 0 ? Coordinates.Column + i : Coordinates.Column - i;

                if (position[row, column] != null)
                    return true;
            }

            return false;
        }

        protected bool IsCapture(BoardCoordinates square, ChessPosition position)
        {
            return position[square.Row, square.Column] != null && position[square.Row, square.Column].Color != Color;
        }
    }
}
