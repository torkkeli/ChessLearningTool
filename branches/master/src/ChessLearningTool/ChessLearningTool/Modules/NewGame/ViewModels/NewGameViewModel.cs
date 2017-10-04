using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ChessLearningTool.Presentation;
using ChessLearningTool.Presentation.ViewModels;

namespace ChessLearningTool.Modules.NewGame.ViewModels
{
    internal sealed class NewGameViewModel : TabViewModel
    {
        public NewGameViewModel(IMainWindow mainWindow)
            : base("New Game", mainWindow)
        {
        }
        public override bool IsUnique
        {
            get { return false; }
        }
    }
}
