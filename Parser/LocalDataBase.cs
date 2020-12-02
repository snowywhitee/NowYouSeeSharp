using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Controls;
//using Microsoft.VisualStudio.Tools.Applications.Runtime;


namespace Parser
{
    public class LocalDataBase 
    {
        //Display data
        private HashSet<DataGridControl> dataGridControls = new HashSet<DataGridControl>();
        public DataGridUpdate DataGridUpdate { get; private set; }

        //Local path
        public string FilePath { get; private set; }
        public string LoadPath { get; private set; }

        //Data
        public DateTime LastUpdate { get; private set; }
        private Dictionary<int, Entry> items = new Dictionary<int, Entry>();
        public int Count { get => items.Count; }

        //Methods for binding
        public LocalDataBase(string filePath, string loadPath)
        {
            FilePath = filePath;
            LoadPath = loadPath;
        }
        public void BindDataGrid(DataGridControl dataGrid)
        {
            if (!dataGridControls.Contains(dataGrid))
            {
                dataGridControls.Add(dataGrid);
            }
        }
        public void BindDataGridUpdate(DataGridUpdate dataGridUpdate)
        {
            DataGridUpdate = dataGridUpdate;
        }
        public void AddToGrids(Entry entry)
        {
            foreach (var dataGrid in dataGridControls)
            {
                dataGrid.AddEntry(entry);
            }
        }
        public void EditGrids(Entry a, Entry b)
        {
            foreach (var dataGrid in dataGridControls)
            {
                dataGrid.EditEntry(a, b);
            }
        }
        public void RemoveFromGrids(Entry entry)
        {
            foreach (var dataGrid in dataGridControls)
            {
                dataGrid.RemoveEntry(entry);
            }
        }

        //Methods for working with database
        public void SaveChanges()
        {
            ParseExcel();
        }
        public void Update()
        {
            DataGridUpdate.Clear();
            LoadFile();
            Dictionary<int, Entry> newEntries = ParseExcelToDict();

            foreach (var item in items)
            {
                if (newEntries.ContainsKey(item.Key))
                {
                    //Edited?
                    if (item.Value != newEntries[item.Key])
                    {
                        DataGridUpdate.AddEntry(new ChangedEntry(newEntries[item.Key], EntryStatus.Edited, item.Value));
                        EditGrids(item.Value, newEntries[item.Key]);
                    }
                }
                else
                {
                    DataGridUpdate.AddEntry(new ChangedEntry(null, EntryStatus.Removed, item.Value));
                    RemoveFromGrids(item.Value);
                }
            }
            foreach (var item in newEntries)
            {
                if (! items.ContainsKey(item.Key))
                {
                    DataGridUpdate.AddEntry(new ChangedEntry(item.Value, EntryStatus.New, null));
                    AddToGrids(item.Value);
                }
            }
            if (DataGridUpdate.Count != 0)
            {
                LastUpdate = DateTime.Now;
                SaveChanges();
            }
            
        }
        public void LoadData()
        {
            if (File.Exists(FilePath))
            {
                try
                {
                    ParseExcel();
                    LastUpdate = DateTime.Now;
                }
                catch (Exception ex)
                {
                    MainWindow.ShowError($"Data couldn't be loaded! {ex.Message}");
                }
            }
            else
            {
                MainWindow.ShowMessage($"Ой, а файла то нет! Ну ничего, скачаем..");
                LoadFile();
                ParseExcel();
            }
        }
        public void LoadFile()
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    client.DownloadFile(LoadPath, FilePath);
                }
            }
            catch (Exception ex)
            {
                MainWindow.ShowError($"Не смогло скачаться: {ex.Message}");
            }
        }
        public Dictionary<int, Entry> ParseExcelToDict()
        {
            Dictionary<int, Entry> newEntries = new Dictionary<int, Entry>();

            try
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                using (FileStream fileStream = new FileStream(FilePath, FileMode.Open))
                {
                    ExcelPackage excel = new ExcelPackage(fileStream);
                    var workSheet = excel.Workbook.Worksheets.First();
                    string[] row = new string[workSheet.Dimension.End.Column];

                    for (int i = 3; i <= workSheet.Dimension.End.Row; i++)
                    {
                        for (int j = 1; j <= workSheet.Dimension.End.Column; j++)
                        {
                            row[j - 1] = workSheet.Cells[i, j].Text;
                        }
                        Entry entry = new Entry(row);
                        newEntries.Add(entry.Id, entry);
                    }
                }
            }
            catch (Exception ex)
            {
                MainWindow.ShowError($"Не смогло спарситься: {ex.Message}");
            }
            
            return newEntries;
        }
        public void ParseExcel()
        {
            try
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                using (FileStream fileStream = new FileStream(FilePath, FileMode.Open))
                {
                    ExcelPackage excel = new ExcelPackage(fileStream);
                    var workSheet = excel.Workbook.Worksheets.First();
                    string[] row = new string[workSheet.Dimension.End.Column];

                    for (int i = 3; i <= workSheet.Dimension.End.Row; i++)
                    {
                        for (int j = 1; j <= workSheet.Dimension.End.Column; j++)
                        {
                            row[j - 1] = workSheet.Cells[i, j].Text;
                        }
                        Entry entry = new Entry(row);
                        if (items.ContainsKey(entry.Id))
                        {
                            items[entry.Id] = entry;
                        }
                        else
                        {
                            items.Add(entry.Id, entry);
                        }
                        
                        AddToGrids(entry);
                    }
                }
            }
            catch (Exception ex)
            {
                MainWindow.ShowError($"Не смогло спарситься: {ex.Message}");
            }
        }
    }
}
