using ChessLearningTool.Data.Enums;
using ChessLearningTool.Logic.Models;
using System;
using System.Drawing;

namespace ChessLearningTool.Logic.ChessLogic.Pieces
{
    public sealed class King : ChessPiece
    {
        public King(ChessColor color, BoardCoordinates coordinates)
            : base(color, coordinates)
        {
        }

        public override Bitmap Image => Color == ChessColor.White ? Images.Images.White_King : Images.Images.Black_King;

        public override decimal Value => 999m;

        public override IChessPiece Copy() => new King(Color, Coordinates);

        protected override bool IsMoveLegal(BoardCoordinates square, ChessPosition position)
        {
            if (Math.Abs(Coordinates.Row - square.Row) > 1 || Math.Abs(Coordinates.Column - square.Column) > 1)
                return false;

            return !IsPieceBlocking(square, position);
        }
    }
}
