using System.Collections.Generic;

using ChessLearningTool.Presentation.ViewModels;
using System.Windows.Controls;
using System.Collections.ObjectModel;
using ChessLearningTool.Modules.NewGame.ViewModels;
using ChessLearningTool.Presentation;

namespace ChessLearningTool
{
    internal sealed class MainWindowViewModel : ViewModel, IMainWindow
    {
        public MainWindowViewModel()
            : base("Chess Learning Tool")
        {
            MenuItems.Add(new MenuItem() { Header = "File" });
            MenuItems.Add(new MenuItem() { Header = "Tools" });

            AddTab(new NewGameViewModel(this));
        }

        public ICollection<MenuItem> MenuItems { get; } = new ObservableCollection<MenuItem>();

        public TabViewModel SelectedTab { get; private set; }

        public ICollection<TabViewModel> OpenTabs { get; } = new ObservableCollection<TabViewModel>();

        public void AddTab(TabViewModel tab)
        {
            if (!(tab.IsUnique && OpenTabs.Contains(tab)))
                OpenTabs.Add(tab);

            SelectedTab = tab;
        }

        public void ChangeSelectedTab(TabViewModel tab)
        {
            if (OpenTabs.Contains(tab))
                SelectedTab = tab;
        }
    }
}
