using ChessLearningTool.Data.Enums;
using ChessLearningTool.Logic.Models;
using System;
using System.Drawing;

namespace ChessLearningTool.Logic.ChessLogic.Pieces
{
    public sealed class Queen : ChessPiece
    {
        public Queen(ChessColor color, BoardCoordinates coordinates)
            : base(color, coordinates)
        {
        }

        public override Bitmap Image => Color == ChessColor.White ? Images.Images.White_Queen : Images.Images.Black_Queen;

        public override decimal Value => 9m;

        public override IChessPiece Copy() => new Queen(Color, Coordinates);

        protected override bool IsMoveLegal(BoardCoordinates square, ChessPosition position)
        {
            if (Math.Abs(Coordinates.Row - square.Row) != Math.Abs(Coordinates.Column - square.Column) &&
                Math.Abs(Coordinates.Row - square.Row) != 0 && Math.Abs(Coordinates.Column - square.Column) != 0)
                return false;

            return !IsPieceBlocking(square, position);
        }
    }
}
