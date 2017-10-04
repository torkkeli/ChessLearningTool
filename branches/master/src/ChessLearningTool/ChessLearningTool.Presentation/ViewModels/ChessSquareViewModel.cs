using ChessLearningTool.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLearningTool.Presentation.ViewModels
{
    public sealed class ChessSquareViewModel : ViewModel
    {
        private readonly int _row;
        private readonly int _column;

        private ChessPieceType _piece;
        public ChessSquareViewModel(int row, int column, ChessPieceType piece)
            : base("Square")
        {
            _row = row;
            _column = column;
            _piece = piece;
        }
        public int Row
        {
            get { return _row; }
        }
        public int Column
        {
            get { return _column; }
        }
        public ChessColor Color
        {
            get { return (Row + Column) % 2 == 1 ? ChessColor.White : ChessColor.Black; }
        }
        public ChessPieceType Piece
        {
            get { return _piece; }
            set { Set(ref _piece, () => Piece, value); }
        }
    }
}
