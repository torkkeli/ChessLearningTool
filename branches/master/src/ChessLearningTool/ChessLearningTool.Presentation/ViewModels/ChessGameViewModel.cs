using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ChessLearningTool.Presentation.ViewModels
{
    public sealed class ChessGameViewModel : ViewModel
    {
        private readonly ICollection<string> _moves;

        public ChessGameViewModel()
            : base("Chess Game")
        {
            _moves = new ObservableCollection<string>();
            _moves.Add("1.   e4           c5");
            _moves.Add("2.   Nf3         d6");
        }

        public ICollection<string> Moves
        {
            get { return _moves; }
        }
    }
}
