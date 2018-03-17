using ChessLearningTool.Data.Enums;
using ChessLearningTool.Logic.Models;

namespace ChessLearningTool.Logic.ChessLogic.Pieces
{
    public sealed class Pawn : ChessPiece
    {
        public Pawn(ChessColor color, BoardCoordinates coordinates)
            : base(color, coordinates)
        {
        }

        public override string ImagePath => ImageFolder + (Color == ChessColor.White ? "White_Pawn.png" : "Black_Pawn.png");

        protected override bool IsMoveLegal(BoardCoordinates square)
        {
            return Coordinates.Row > square.Row;
        }
    }
}
