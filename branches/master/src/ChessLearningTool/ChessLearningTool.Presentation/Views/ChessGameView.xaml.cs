using System.Windows.Controls;

using ChessLearningTool.Presentation.ViewModels;

namespace ChessLearningTool.Presentation.Views
{
    /// <summary>
    /// Interaction logic for ChessGameView.xaml
    /// </summary>
    public partial class ChessGameView : UserControl
    {
        public ChessGameView()
        {
            InitializeComponent();
            DataContext = new ChessGameViewModel();
        }
    }
}
