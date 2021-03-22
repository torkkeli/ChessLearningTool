using ChessLearningTool.Data.Enums;
using ChessLearningTool.Logic.Models;
using System;
using System.Drawing;

namespace ChessLearningTool.Logic.ChessLogic.Pieces
{
    public sealed class King : ChessPiece
    {
        public King(ChessColor color, BoardCoordinates coordinates, bool canCastle = true)
            : base(color, coordinates)
        {
            CanCastle = canCastle;

            MoveMade += (m) => CanCastle = false;
        }

        public bool CanCastle { get; set; }

        public override Bitmap Image => Color == ChessColor.White ? Images.Images.White_King : Images.Images.Black_King;

        public override decimal Value => 999m;

        public override IChessPiece Copy() => new King(Color, Coordinates, CanCastle);

        protected override bool IsMoveLegal(BoardCoordinates square, ChessPosition position)
        {
            if (!Castle(square, position) &&
                (Math.Abs(Coordinates.Row - square.Row) > 1 || Math.Abs(Coordinates.Column - square.Column) > 1))
                return false;

            return !IsPieceBlocking(square, position);
        }

        protected override void OnMoveMade(ChessMove move, ChessPosition position)
        {
            if (Castle(move.End, position))
            {
                move.Castle = true;

                Rook rook;

                if (Coordinates.Column > move.End.Column)
                {
                    rook = Color == ChessColor.White ? position[0, 0] as Rook : position[7, 0] as Rook;
                }
                else
                {
                    rook = Color == ChessColor.White ? position[0, 7] as Rook : position[7, 7] as Rook;
                }

                rook.Castle();
            }

            base.OnMoveMade(move, position);
        }

        private bool Castle(BoardCoordinates square, ChessPosition position)
        {
            if (!CanCastle)
                return false;

            if (Math.Abs(Coordinates.Column - square.Column) != 2 || Coordinates.Row != square.Row)
                return false;

            Rook rook;

            if (Coordinates.Column > square.Column)
            {
                rook = Color == ChessColor.White ? position[0, 0] as Rook : position[7, 0] as Rook;
            }
            else
            {
                rook = Color == ChessColor.White ? position[0, 7] as Rook : position[7, 7] as Rook;
            }

            return rook != null && rook.CanCastle;
        }
    }
}
