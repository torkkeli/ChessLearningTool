using ChessLearningTool.Data.Enums;
using ChessLearningTool.Logic.Models;
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

        protected override bool IsMoveLegal(BoardCoordinates square)
        {
            return Coordinates.Row > square.Row;
        }
    }
}
