using ChessLearningTool.Logic.ChessLogic;
using ChessLearningTool.Presentation.Commands;
using ChessLearningTool.Presentation.Enums;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Linq;
using ChessLearningTool.Logic.Models;

namespace ChessLearningTool.Presentation.ViewModels
{
    public sealed class ChessBoardViewModel : ViewModel
    {
        private readonly ICollection<ChessSquareViewModel> _squares = new ObservableCollection<ChessSquareViewModel>();
        private readonly IDictionary<BoardCoordinates, ChessSquareViewModel> _squaresOnBoard =
            new Dictionary<BoardCoordinates, ChessSquareViewModel>();

        private readonly ICommand _onClick;
        private readonly ChessPosition _position;

        private ChessSquareViewModel _selected;

        public ChessBoardViewModel()
            : base (string.Empty)
        {
            _onClick = new Command<ChessSquareViewModel>(OnSquareClicked, s => true);
            _position = new ChessPosition();
            _position.SetStartingPosition();

            for (int r = 7; r >= 0; r--)
            {
                for (int c = 0; c < 8; c++)
                {
                    var model = new ChessSquareViewModel(r, c, _position[r, c]);

                    Squares.Add(model);
                    _squaresOnBoard.Add(new BoardCoordinates(r, c), model);
                }
            }

            _position.PositionChanged += OnPositionChanged;
        }

        public ICollection<ChessSquareViewModel> Squares => _squares;

        public ICommand OnClick => _onClick;

        private void OnSquareClicked(ChessSquareViewModel square)
        {
            if (_selected == null)
            {
                if (square.Piece == null)
                    return;

                _selected = square;
                _selected.Color = SquareColor.Selected;
                return;
            }

            _selected.Color = (_selected.Row + _selected.Column) % 2 == 0 ? SquareColor.Black : SquareColor.White;

            _selected.Piece.TryMakeMove(square.ToCoordinates());

            _selected = null;
        }

        private void OnPositionChanged()
        {
            ChessMove move = _position.Moves.Last();

            _squaresOnBoard[move.End].Piece = _squaresOnBoard[move.Start].Piece;
            _squaresOnBoard[move.Start].Piece = null;
        }
    }
}
