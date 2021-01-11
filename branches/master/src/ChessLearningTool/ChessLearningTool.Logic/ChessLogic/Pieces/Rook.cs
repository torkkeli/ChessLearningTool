using ChessLearningTool.Data.Enums;
using ChessLearningTool.Logic.Models;
using System;
using System.Drawing;

namespace ChessLearningTool.Logic.ChessLogic.Pieces
{
    public sealed class Rook : ChessPiece
    {
        public Rook(ChessColor color, BoardCoordinates coordinates, bool canCastle = true)
            : base(color, coordinates)
        {
            CanCastle = canCastle;

            MoveMade += (m) => CanCastle = false;
        }

        public bool CanCastle { get; set; }

        public override Bitmap Image => Color == ChessColor.White ? Images.Images.White_Rook : Images.Images.Black_Rook;

        public override decimal Value => 5m;

        public override IChessPiece Copy() => new Rook(Color, Coordinates, CanCastle);

        public void Castle()
        {
            Coordinates = new BoardCoordinates(Coordinates.Row, Coordinates.Column == 0 ? 3 : 5);
            CanCastle = false;
        }

        protected override bool IsMoveLegal(BoardCoordinates square, ChessPosition position)
        {
            if (Math.Abs(Coordinates.Row - square.Row) != 0 && Math.Abs(Coordinates.Column - square.Column) != 0)
                return false;

            return !IsPieceBlocking(square, position);
        }
    }
}
