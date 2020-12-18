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
        private readonly IDictionary<BoardCoordinates, ChessSquareViewModel> _squaresOnBoard =
            new Dictionary<BoardCoordinates, ChessSquareViewModel>();
        private ChessSquareViewModel _selected;

        public ChessBoardViewModel()
            : base (string.Empty)
        {
            OnClick = new Command<ChessSquareViewModel>(OnSquareClicked, s => true);
            Position = new ChessPosition();
            Position.SetStartingPosition();

            for (int r = 7; r >= 0; r--)
            {
                for (int c = 0; c < 8; c++)
                {
                    var model = new ChessSquareViewModel(r, c, Position[r, c]);

                    Squares.Add(model);
                    _squaresOnBoard.Add(new BoardCoordinates(r, c), model);
                }
            }

            Position.PositionChanged += OnPositionChanged;
        }

        public ICollection<ChessSquareViewModel> Squares { get; } = new ObservableCollection<ChessSquareViewModel>();

        public ICommand OnClick { get; }

        public ChessPosition Position { get; }

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

            _selected.Piece.TryMakeMove(square.ToCoordinates(), Position);

            _selected = null;
        }

        private void OnPositionChanged()
        {
            ChessMove move = Position.Moves.Last();

            _squaresOnBoard[move.End].Piece = _squaresOnBoard[move.Start].Piece;
            _squaresOnBoard[move.Start].Piece = null;
        }
    }
}
