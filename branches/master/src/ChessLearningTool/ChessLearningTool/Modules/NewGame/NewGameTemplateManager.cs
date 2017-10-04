using ChessLearningTool.Modules.NewGame.ViewModels;
using ChessLearningTool.Modules.NewGame.Views;
using ChessLearningTool.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ChessLearningTool.Modules.NewGame
{
    internal sealed class NewGameTemplateManager : TemplateManager
    {
        public override IEnumerable<DataTemplate> Templates
        {
            get
            {
                yield return AddDataTemplate<NewGameViewModel, NewGameView>();
            }
        }
    }
}
