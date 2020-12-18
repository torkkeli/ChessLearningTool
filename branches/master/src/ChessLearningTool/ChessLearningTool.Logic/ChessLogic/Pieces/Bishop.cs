using ChessLearningTool.Data.Enums;
using ChessLearningTool.Logic.Models;
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

        protected override bool IsMoveLegal(BoardCoordinates square, ChessPosition position)
        {
            return true;
        }
    }
}
