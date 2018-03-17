using ChessLearningTool.Data.Enums;
using ChessLearningTool.Logic.Models;

namespace ChessLearningTool.Logic.ChessLogic.Pieces
{
    public sealed class Rook : ChessPiece
    {
        public Rook(ChessColor color, BoardCoordinates coordinates)
            : base(color, coordinates)
        {
        }

        public override string ImagePath => ImageFolder + (Color == ChessColor.White ? "White_Rook.png" : "Black_Rook.png");

        protected override bool IsMoveLegal(BoardCoordinates square)
        {
            return true;
        }
    }
}
