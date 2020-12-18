using ChessLearningTool.Data.Enums;
using ChessLearningTool.Logic.Models;
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

        protected override bool IsMoveLegal(BoardCoordinates square)
        {
            return true;
        }
    }
}
