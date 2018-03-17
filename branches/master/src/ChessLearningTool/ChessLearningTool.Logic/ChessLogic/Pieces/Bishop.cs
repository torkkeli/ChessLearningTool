using ChessLearningTool.Data.Enums;
using ChessLearningTool.Logic.Models;

namespace ChessLearningTool.Logic.ChessLogic.Pieces
{
    public sealed class Bishop : ChessPiece
    {
        public Bishop(ChessColor color, BoardCoordinates coordinates)
            : base(color, coordinates)
        {
        }

        public override string ImagePath => ImageFolder + (Color == ChessColor.White ? "White_Bishop.png" : "Black_Bishop.png");

        protected override bool IsMoveLegal(BoardCoordinates square)
        {
            return true;
        }
    }
}
