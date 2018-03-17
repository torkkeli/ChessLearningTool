using ChessLearningTool.Data.Enums;
using ChessLearningTool.Logic.ChessLogic;
using ChessLearningTool.Logic.ChessLogic.Pieces;
using ChessLearningTool.Logic.Models;
using ChessLearningTool.Presentation.Commands;
using ChessLearningTool.Presentation.Enums;
using System;
using System.Windows.Input;

namespace ChessLearningTool.Presentation.ViewModels
{
    public sealed class ChessSquareViewModel : ViewModel
    {
        private readonly int _row;
        private readonly int _column;

        private SquareColor _color;
        private IChessPiece _piece;

        public ChessSquareViewModel(int row, int column, IChessPiece piece)
            : base("Square")
        {
            _row = row;
            _column = column;
            _piece = piece;
            _color = (Row + Column) % 2 == 1 ? SquareColor.White : SquareColor.Black;
        }

        public int Row => _row;

        public int Column => _column;

        public SquareColor Color
        {
            get { return _color; }
            set { Set(ref _color, () => Color, value); }
        }

        public IChessPiece Piece
        {
            get { return _piece; }
            set { Set(ref _piece, () => Piece, value); }
        }

        public BoardCoordinates ToCoordinates()
        {
            return new BoardCoordinates(Row, Column);
        }
    }
}
