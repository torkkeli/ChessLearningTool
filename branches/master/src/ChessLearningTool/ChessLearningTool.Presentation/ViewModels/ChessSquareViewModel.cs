using ChessLearningTool.Data.Enums;
using ChessLearningTool.Logic.ChessLogic;
using ChessLearningTool.Presentation.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ChessLearningTool.Presentation.ViewModels
{
    public sealed class ChessSquareViewModel : ViewModel
    {
        private readonly int _row;
        private readonly int _column;
        private readonly ICommand _onClick;

        private ChessPieceType _piece;
        private Colors _color;

        public ChessSquareViewModel(int row, int column, ChessPieceType piece)
            : base("Square")
        {
            _row = row;
            _column = column;
            _piece = piece;
            _color = (Row + Column) % 2 == 1 ? Colors.Black : Colors.White;
            _onClick = new Command<ChessSquareViewModel>(OnSquareClicked, CanClick);
        }

        public int Row => _row;

        public int Column => _column;

        public Colors Color
        {
            get { return _color; }
            set { Set(ref _color, () => Color, value); }
        }

        public ICommand OnClick => _onClick;

        public ChessPieceType Piece
        {
            get { return _piece; }
            set { Set(ref _piece, () => Piece, value); }
        }

        public BoardCoordinates ToCoordinates()
        {
            return new BoardCoordinates(Row, Column);
        }

        private bool CanClick(ChessSquareViewModel square) => !Piece.Equals(ChessPieceType.None);

        private void OnSquareClicked(ChessSquareViewModel square)
        {
            throw new Exception("Square clicked");
        }
    }
}
