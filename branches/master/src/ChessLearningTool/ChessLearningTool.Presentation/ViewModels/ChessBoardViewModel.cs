using ChessLearningTool.Data.Enums;
using ChessLearningTool.Logic.ChessLogic;
using ChessLearningTool.Presentation.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ChessLearningTool.Presentation.ViewModels
{
    public sealed class ChessBoardViewModel : ViewModel
    {
        private readonly ICollection<ChessSquareViewModel> _squares = new ObservableCollection<ChessSquareViewModel>();
        private readonly ICommand _onClick;
        private readonly ChessPieceType[,] _position = new ChessPieceType[8, 8];

        private ChessSquareViewModel selected;

        public ChessBoardViewModel()
            : base (string.Empty)
        {
            _onClick = new Command<ChessSquareViewModel>(OnSquareClicked, s => true);

            LoadStartingPosition();
        }

        public ICollection<ChessSquareViewModel> Squares => _squares;

        public ICommand OnClick => _onClick;

        private void OnSquareClicked(ChessSquareViewModel square)
        {
            if (selected == null)
            {
                if (square.Piece == ChessPieceType.None)
                    return;

                selected = square;
                selected.Color = Colors.Selected;
                return;
            }

            selected.Color = (selected.Row + selected.Column) % 2 == 1 ? Colors.Black : Colors.White;

            if (selected == square)
            {
                selected = null;
                return;
            }


            if (RegisterMove(selected.Piece, selected, square))
            {
                square.Piece = selected.Piece;
                selected.Piece = ChessPieceType.None;              
            }

            selected = null;
        }

        private void LoadStartingPosition()
        {
            ChessPieceType current = default(ChessPieceType);

            for (int r = 0; r < 8; r++)
            {
                for (int c = 0; c < 8; c++)
                {
                    switch (r)
                    {
                        case 0:
                        case 7:
                            switch (c)
                            {
                                case 0:
                                case 7:
                                    current = r == 7 ? ChessPieceType.WhiteRook : ChessPieceType.BlackRook;                                 
                                    _squares.Add(new ChessSquareViewModel(r, c, current));
                                    break;
                                case 1:
                                case 6:
                                    current = r == 7 ? ChessPieceType.WhiteKnight : ChessPieceType.BlackKnight;
                                    _squares.Add(new ChessSquareViewModel(r, c, current));
                                    break;
                                case 2:
                                case 5:
                                    current = r == 7 ? ChessPieceType.WhiteBishop : ChessPieceType.BlackBishop;
                                    _squares.Add(new ChessSquareViewModel(r, c, current));
                                    break;
                                case 3:
                                    current = r == 7 ? ChessPieceType.WhiteQueen : ChessPieceType.BlackQueen;
                                    _squares.Add(new ChessSquareViewModel(r, c, current));
                                    break;
                                case 4:
                                    current = r == 7 ? ChessPieceType.WhiteKing : ChessPieceType.BlackKing;
                                    _squares.Add(new ChessSquareViewModel(r, c, current));
                                    break;
                            }
                            break;
                        case 1:
                            current = ChessPieceType.BlackPawn;
                            _squares.Add(new ChessSquareViewModel(r, c, current));
                            break;
                        case 6:
                            current = ChessPieceType.WhitePawn;
                            _squares.Add(new ChessSquareViewModel(r, c, current));
                            break;
                        default:
                            current = ChessPieceType.None;
                            _squares.Add(new ChessSquareViewModel(r, c, current));
                            break;
                    }

                    _position[r, c] = current;
                }
            }
        }

        private bool RegisterMove(ChessPieceType piece, ChessSquareViewModel start, ChessSquareViewModel end)
        {
            BoardCoordinates startBC = start.ToCoordinates();
            BoardCoordinates endBC = end.ToCoordinates();

            if (CheckLegality(piece, startBC, endBC))
            {
                return true;
            }

            return false;
        }

        private bool CheckLegality(ChessPieceType piece, BoardCoordinates start, BoardCoordinates end)
        {
            return true;
        }
    }
}
