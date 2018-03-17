using ChessLearningTool.Data.Enums;
using ChessLearningTool.Logic.Models;

namespace ChessLearningTool.Logic.ChessLogic.Pieces
{
    public sealed class Queen : ChessPiece
    {
        public Queen(ChessColor color, BoardCoordinates coordinates)
            : base(color, coordinates)
        {
        }

        public override string ImagePath => ImageFolder + (Color == ChessColor.White ? "White_Queen.png" : "Black_Queen.png");

        protected override bool IsMoveLegal(BoardCoordinates square)
        {
            return true;
        }
    }
}
