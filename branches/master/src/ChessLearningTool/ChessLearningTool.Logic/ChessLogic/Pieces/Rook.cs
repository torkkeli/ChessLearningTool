using ChessLearningTool.Data.Enums;
using ChessLearningTool.Logic.Models;
using System;
using System.Drawing;

namespace ChessLearningTool.Logic.ChessLogic.Pieces
{
    public sealed class Rook : ChessPiece
    {
        public Rook(ChessColor color, BoardCoordinates coordinates)
            : base(color, coordinates)
        {
        }

        public override Bitmap Image => Color == ChessColor.White ? Images.Images.White_Rook : Images.Images.Black_Rook;

        public override decimal Value => 5m;

        public override IChessPiece Copy() => new Rook(Color, Coordinates);

        protected override bool IsMoveLegal(BoardCoordinates square, ChessPosition position)
        {
            if (Math.Abs(Coordinates.Row - square.Row) != 0 && Math.Abs(Coordinates.Column - square.Column) != 0)
                return false;

            return !IsPieceBlocking(square, position);
        }
    }
}
