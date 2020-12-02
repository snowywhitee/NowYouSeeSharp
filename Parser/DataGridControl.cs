using System;
using System.Collections.ObjectModel;
using System.Windows.Controls;
//using Microsoft.VisualStudio.Tools.Applications.Runtime;


namespace Parser
{
    public class DataGridControl : PageNavigator, IDataGridControler
    {
        //Data for binding
        private DataGrid dataGrid;
        protected ObservableCollection<Entry> data = new ObservableCollection<Entry>();
        public int Count { get => data.Count; }
        public DataGridControl(DataGrid dataGrid, Label label) : base(label)
        {
            this.dataGrid = dataGrid;
            this.dataGrid.ItemsSource = data;
        }

        //Grid control
        public void AddEntry(Entry entry)
        {
            if (!data.Contains(entry))
            {
                data.Add(entry);
                dataGrid.Items.Refresh();
            }
        }
        public void EditEntry(Entry a, Entry b)
        {
            int index = data.IndexOf(a);
            if (index != -1)
            {
                data.Remove(a);
                data.Insert(index, b);
                dataGrid.Items.Refresh();
            }
            else
            {
                AddEntry(b);
            }
        }
        public void RemoveEntry(Entry entry)
        {
            if (data.Contains(entry))
            {
                data.Remove(entry);
                dataGrid.Items.Refresh();
            }
        }

        //Pages management
        public override int PagesCount { get => (int)(Math.Floor((double)Count / Step) + 1); }
        public override void DisplayPage()
        {
            dataPage.Clear();
            for (int i = 0; i < data.Count; i++)
            {
                if (i <= CurrentPage * Step - 1 && i >= (CurrentPage - 1) * Step)
                {
                    dataPage.Add(data[i]);
                }
            }
            dataGrid.ItemsSource = dataPage;
            dataGrid.Items.Refresh();
            label.Content = $"{CurrentPage} of {PagesCount}";
        }
    }
}
