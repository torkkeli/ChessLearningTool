using ChessLearningTool.Data.Enums;
using ChessLearningTool.Logic.Models;

namespace ChessLearningTool.Logic.ChessLogic.Pieces
{
    public sealed class King : ChessPiece
    {
        public King(ChessColor color, BoardCoordinates coordinates)
            : base(color, coordinates)
        {
        }

        public override string ImagePath => ImageFolder + (Color == ChessColor.White ? "White_King.png" : "Black_King.png");

        protected override bool IsMoveLegal(BoardCoordinates square)
        {
            return true;
        }
    }
}
