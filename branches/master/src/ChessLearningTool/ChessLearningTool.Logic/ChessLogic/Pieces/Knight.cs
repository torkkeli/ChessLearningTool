using ChessLearningTool.Data.Enums;
using ChessLearningTool.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLearningTool.Logic.ChessLogic.Pieces
{
    public sealed class Knight : ChessPiece
    {
        public Knight(ChessColor color, BoardCoordinates coordinates)
            : base(color, coordinates)
        {
        }

        public override string ImagePath => ImageFolder + (Color == ChessColor.White ? "White_Knight.png" : "Black_Knight.png");

        protected override bool IsMoveLegal(BoardCoordinates square)
        {
            return true;
        }
    }
}
