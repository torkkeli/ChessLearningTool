using ChessLearningTool.Data.Enums;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLearningTool.Presentation.ViewModels
{
    public sealed class ChessBoardViewModel : ViewModel
    {
        private readonly ICollection<ChessSquareViewModel> _squares = new ObservableCollection<ChessSquareViewModel>();
        public ChessBoardViewModel()
            : base (string.Empty)
        {
            for (int r = 0; r < 8; r++)
            {
                for (int c = 0; c < 8; c++)
                {
                    _squares.Add(new ChessSquareViewModel(r, c, ChessPieceType.None));
                }
            }
        }
        public ICollection<ChessSquareViewModel> Squares
        {
            get { return _squares; }
        }
    }
}
