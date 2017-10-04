using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ChessLearningTool.Presentation.ViewModels;
using System.Windows.Controls;
using System.Collections.ObjectModel;
using ChessLearningTool.Modules.NewGame.ViewModels;
using ChessLearningTool.Presentation;

namespace ChessLearningTool
{
    internal sealed class MainWindowViewModel : ViewModel, IMainWindow
    {
        private readonly ICollection<TabViewModel> _openTabs = new ObservableCollection<TabViewModel>();
        private readonly ICollection<MenuItem> _menuItems = new ObservableCollection<MenuItem>();

        private TabViewModel _selectedTab;
        public MainWindowViewModel()
            : base("Chess Learning Tool")
        {
            _menuItems.Add(new MenuItem() { Header = "File" });
            _menuItems.Add(new MenuItem() { Header = "Tools" });

            AddTab(new NewGameViewModel(this));
        }

        public ICollection<MenuItem> MenuItems
        {
            get { return _menuItems; }
        }
        public TabViewModel SelectedTab
        {
            get { return _selectedTab; }
        }
        public ICollection<TabViewModel> OpenTabs
        {
            get { return _openTabs; }
        }
        public void AddTab(TabViewModel tab)
        {
            if (!(tab.IsUnique && _openTabs.Contains(tab)))
                _openTabs.Add(tab);

            _selectedTab = tab;
        }
        public void ChangeSelectedTab(TabViewModel tab)
        {
            if (_openTabs.Contains(tab))
                _selectedTab = tab;
        }
    }
}
