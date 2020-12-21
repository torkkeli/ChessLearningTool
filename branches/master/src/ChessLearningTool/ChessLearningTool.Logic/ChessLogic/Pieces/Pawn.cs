using ChessLearningTool.Data.Enums;
using ChessLearningTool.Logic.Models;
using System;
using System.Drawing;

namespace ChessLearningTool.Logic.ChessLogic.Pieces
{
    public sealed class Pawn : ChessPiece
    {
        public Pawn(ChessColor color, BoardCoordinates coordinates)
            : base(color, coordinates)
        {
        }

        public override Bitmap Image => Color == ChessColor.White ? Images.Images.White_Pawn : Images.Images.Black_Pawn;

        private bool IsAtStartingPosition => Color == ChessColor.White ? Coordinates.Row == 1 : Coordinates.Row == 6;

        public override decimal Value => 1m;

        public override IChessPiece Copy() => new Pawn(Color, Coordinates);

        protected override bool IsMoveLegal(BoardCoordinates square, ChessPosition position)
        {
            if (IsImpossible(square))
                return false;

            if (IsPawnCapture(square, position))
                return true;

            if (position[square] != null)
                return false;

            if (IsAtStartingPosition)
            {
                return Math.Abs(Coordinates.Row - square.Row) <= 2 && Coordinates.Column - square.Column == 0 && !IsPieceBlocking(square, position);
            }

            return Math.Abs(Coordinates.Row - square.Row) == 1 && Coordinates.Column -square.Column == 0 && !IsPieceBlocking(square, position);
        }

        private bool IsPawnCapture(BoardCoordinates square, ChessPosition position)
        {
            return Math.Abs(Coordinates.Row - square.Row) == 1 &&
                Math.Abs(Coordinates.Column - square.Column) == 1 &&
                IsCapture(square, position);
        }

        private bool IsImpossible(BoardCoordinates square)
        {
            if (Color == ChessColor.White ? square.Row <= Coordinates.Row : square.Row >= Coordinates.Row)
                return true;

            if (Math.Abs(square.Row - Coordinates.Row) > 2)
                return true;

            if (Math.Abs(square.Column - Coordinates.Column) > 1)
                return true;

            return false;
        }
    }
}
