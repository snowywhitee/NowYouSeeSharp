//using Microsoft.VisualStudio.Tools.Applications.Runtime;

namespace Parser
{
    public interface IPageNavigatable
    {
        int PagesCount { get; }
        int CurrentPage { get; }
        int Step { get; }
        void SetCurrentPage(int num);
        void DisplayPage();
        void Navigate(bool direction);
    }
}
