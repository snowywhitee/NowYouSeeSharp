using System.Collections.ObjectModel;
using System.Windows.Controls;
//using Microsoft.VisualStudio.Tools.Applications.Runtime;


namespace Parser
{
    public abstract class PageNavigator : IPageNavigatable
    {
        protected ObservableCollection<Entry> dataPage = new ObservableCollection<Entry>();
        protected Label label;
        public abstract int PagesCount { get; }
        public int CurrentPage { get; protected set; } = 1;
        public int Step { get; set; } = 15;
        public PageNavigator(Label label)
        {
            this.label = label;
        }

        public abstract void DisplayPage();

        public void Navigate(bool direction)
        {
            if (direction)
            {
                //Forward
                if (CurrentPage + 1 <= PagesCount)
                {
                    CurrentPage++;
                }
            }
            else
            {
                //Backwards
                if (CurrentPage - 1 >= 1)
                {
                    CurrentPage--;
                }
            }
            DisplayPage();
        }

        public void SetCurrentPage(int num)
        {
            if (num <= 0 || num > PagesCount)
            {
                MainWindow.ShowError($"Current page out of range [1;{PagesCount}]");
            }
            else
            {
                CurrentPage = num;
            }
        }
    }
}
