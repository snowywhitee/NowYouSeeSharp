using System;
using System.Collections.ObjectModel;
using System.Windows.Controls;
//using Microsoft.VisualStudio.Tools.Applications.Runtime;


namespace Parser
{
    public class DataGridUpdate : PageNavigator, IDataGridControler
    {
        //Data for binding
        private DataGrid dataGrid;
        protected ObservableCollection<ChangedEntry> data = new ObservableCollection<ChangedEntry>();
        public int Count { get => data.Count; }
        public DataGridUpdate(DataGrid dataGrid, Label label) : base(label)
        {
            this.dataGrid = dataGrid;
            this.dataGrid.ItemsSource = data;
        }

        //Grid control
        public void AddEntry(Entry entry)
        {
            if (!data.Contains(entry as ChangedEntry))
            {
                data.Add(entry as ChangedEntry);
                dataGrid.Items.Refresh();
            }
            
        }
        public void EditEntry(Entry a, Entry b)
        {
            int index = data.IndexOf(a as ChangedEntry);
            if (index != -1)
            {
                data.Remove(a as ChangedEntry);
                data.Insert(index, b as ChangedEntry);
                dataGrid.Items.Refresh();
            }
            else
            {
                AddEntry(b);
            }
        }
        public void Clear()
        {
            data.Clear();
            dataGrid.Items.Refresh();
        }
        public void RemoveEntry(Entry entry)
        {
            if (data.Contains(entry as ChangedEntry))
            {
                data.Remove(entry as ChangedEntry);
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
