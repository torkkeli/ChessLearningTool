using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLearningTool.Presentation.ViewModels
{
    public abstract class TabViewModel : ViewModel
    {
        private readonly IMainWindow _mainWIndow;
        public TabViewModel(string name, IMainWindow mainWindow)
            : base(name)
        {
            _mainWIndow = mainWindow;
        }
        protected IMainWindow MainWindow
        {
            get { return _mainWIndow; }
        }
        public abstract bool IsUnique { get; }
    }
}
