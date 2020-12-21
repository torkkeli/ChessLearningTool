using ChessLearningTool.Data.Enums;
using ChessLearningTool.Logic.Models;
using System;
using System.Drawing;

namespace ChessLearningTool.Logic.ChessLogic.Pieces
{
    public sealed class Bishop : ChessPiece
    {
        public Bishop(ChessColor color, BoardCoordinates coordinates)
            : base(color, coordinates)
        {
        }

        public override Bitmap Image => Color == ChessColor.White ? Images.Images.White_Bishop : Images.Images.Black_Bishop;

        public override decimal Value => 3.1m;

        public override IChessPiece Copy() => new Bishop(Color, Coordinates);

        protected override bool IsMoveLegal(BoardCoordinates square, ChessPosition position)
        {
            if (Math.Abs(Coordinates.Row - square.Row) != Math.Abs(Coordinates.Column - square.Column))
                return false;

            return !IsPieceBlocking(square, position);
        }
    }
}
