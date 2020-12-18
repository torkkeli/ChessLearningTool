using ChessLearningTool.Presentation.ViewModels;

namespace ChessLearningTool.Presentation
{
    public interface IMainWindow
    {
        void AddTab(TabViewModel tab);

        void ChangeSelectedTab(TabViewModel tab);
    }
}
