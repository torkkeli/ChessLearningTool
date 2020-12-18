using ChessLearningTool.Data.Enums;
using ChessLearningTool.Logic.Models;
using System.Drawing;

namespace ChessLearningTool.Logic.ChessLogic.Pieces
{
    public sealed class Queen : ChessPiece
    {
        public Queen(ChessColor color, BoardCoordinates coordinates)
            : base(color, coordinates)
        {
        }

        public override Bitmap Image => Color == ChessColor.White ? Images.Images.White_Queen : Images.Images.Black_Queen;

        protected override bool IsMoveLegal(BoardCoordinates square, ChessPosition position)
        {
            return true;
        }
    }
}
