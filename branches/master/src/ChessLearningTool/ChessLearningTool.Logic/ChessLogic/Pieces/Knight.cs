using ChessLearningTool.Data.Enums;
using ChessLearningTool.Logic.Models;
using System;
using System.Drawing;

namespace ChessLearningTool.Logic.ChessLogic.Pieces
{
    public sealed class Knight : ChessPiece
    {
        public Knight(ChessColor color, BoardCoordinates coordinates)
            : base(color, coordinates)
        {
        }

        public override Bitmap Image => Color == ChessColor.White ? Images.Images.White_Knight : Images.Images.Black_Knight;

        public override decimal Value => 3m;

        public override IChessPiece Copy() => new Knight(Color, Coordinates);

        protected override bool IsMoveLegal(BoardCoordinates square, ChessPosition position)
        {
            if (position[square.Row, square.Column]?.Color == Color)
                return false;

            if (Math.Abs(Coordinates.Row - square.Row) == 2)
                return Math.Abs(Coordinates.Column - square.Column) == 1;

            return Math.Abs(Coordinates.Column - square.Column) == 2 && Math.Abs(Coordinates.Row - square.Row) == 1;
        }
    }
}
