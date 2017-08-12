using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLearningTool.Presentation.ViewModels
{
    public abstract class ViewModel : NotifyPropertyChanged
    {
        private readonly string _name;
        private bool _isVisible;

        protected ViewModel(string name)
        {
            _name = name;
            _isVisible = true;
        }

        public string Name
        {
            get { return _name; }
        }

        public bool IsVisible
        {
            get { return _isVisible; }
            set { Set(ref _isVisible, () => IsVisible, value); }
        }
    }
}
