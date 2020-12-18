using ChessLearningTool.Data.Enums;
using ChessLearningTool.Logic.Models;
using System.Drawing;

namespace ChessLearningTool.Logic.ChessLogic.Pieces
{
    public sealed class Knight : ChessPiece
    {
        public Knight(ChessColor color, BoardCoordinates coordinates)
            : base(color, coordinates)
        {
        }

        public override Bitmap Image => Color == ChessColor.White ? Images.Images.White_Knight : Images.Images.Black_Knight;

        protected override bool IsMoveLegal(BoardCoordinates square, ChessPosition position)
        {
            return true;
        }
    }
}
