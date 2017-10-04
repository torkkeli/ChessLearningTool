using ChessLearningTool.Presentation.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessLearningTool.Presentation
{
    public interface IMainWindow
    {
        void AddTab(TabViewModel tab);
        void ChangeSelectedTab(TabViewModel tab);
    }
}
