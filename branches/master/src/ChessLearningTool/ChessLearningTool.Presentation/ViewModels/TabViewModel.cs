using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLearningTool.Presentation.ViewModels
{
    public abstract class TabViewModel : ViewModel
    {
        public TabViewModel(string name)
            : base(name)
        {

        }

        public abstract bool IsUnique { get; }
    }
}
