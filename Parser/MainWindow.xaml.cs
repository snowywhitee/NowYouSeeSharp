using Caliburn.Micro;
using DocumentFormat.OpenXml.Spreadsheet;
using GemBox.Spreadsheet;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Excel = Microsoft.Office.Interop.Excel;
//using Microsoft.VisualStudio.Tools.Applications.Runtime;


namespace Parser
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// C:\Users\нр\source\repos\Parser\thrlist.xlsx
    /// https://bdu.fstec.ru/files/documents/thrlist.xlsx
    public partial class MainWindow : Window
    {
        LocalDataBase db = new LocalDataBase(System.IO.Path.Combine(Directory.GetCurrentDirectory(), "thrlist.xlsx"), @"https://bdu.fstec.ru/files/documents/thrlist.xlsx");
        DataGridControl FullGrid;
        DataGridControl ShortGrid;
        DataGridUpdate UpdateGrid;
        private List<int> pageRecords = new List<int>() { 15, 20, 25, 30, 35, 40};

        public MainWindow()
        {
            InitializeComponent();
            //Show the prompt
            inputBox.Text = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "thrlist.xlsx");
        }

        //Other windows spawn
        public static void ShowMessage(string msg)
        {
            Window window = new MessageWindow(msg);
            window.Show();
        }
        public static void ShowError(string msg)
        {
            Window window = new MessageWindow(msg);
            window.Show();
        }
        public void MakePaginationVisible(bool res)
        {
            if (res)
            {
                PageBack.Visibility = Visibility.Visible;
                PageForward.Visibility = Visibility.Visible;
                PaginationLabel.Visibility = Visibility.Visible;
                NumberOfRecords.Visibility = Visibility.Visible;
            }
            else
            {
                PageBack.Visibility = Visibility.Hidden;
                PageForward.Visibility = Visibility.Hidden;
                PaginationLabel.Visibility = Visibility.Hidden;
                NumberOfRecords.Visibility = Visibility.Hidden;
            }
        }
        public void GridWindow(string filePath)
        {
            prompt.Visibility = Visibility.Hidden;
            msgBox.Text = "Вот что мы напарсили:";
            
            //Takes time
            db = new LocalDataBase(filePath, @"https://bdu.fstec.ru/files/documents/thrlist.xlsx");
            FullGrid = new DataGridControl(dataGrid, PaginationLabel);
            ShortGrid = new DataGridControl(dataGridShort, PaginationLabel);
            UpdateGrid = new DataGridUpdate(dataGridUpdated, PaginationLabel);
            db.BindDataGrid(FullGrid);
            db.BindDataGrid(ShortGrid);
            db.BindDataGridUpdate(UpdateGrid);
            db.LoadData();

            msgBox.Visibility = Visibility.Visible;
            ShortView.Visibility = Visibility.Visible;
            FullView.Visibility = Visibility.Visible;
            dataGridShort.Visibility = Visibility.Visible;
            Exit.Visibility = Visibility.Visible;
            Refresh.Visibility = Visibility.Visible;
            SaveToFile.Visibility = Visibility.Visible;
            BeforeAfter.Visibility = Visibility.Visible;
            NumberOfRecords.ItemsSource = pageRecords;
            MakePaginationVisible(true);


        }

        //Buttons
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            string filePath = "";
            filePath = inputBox.Text;
            if (Directory.Exists(System.IO.Path.GetDirectoryName(filePath)))
            {
                if (System.IO.Path.GetFileName(filePath) != null && System.IO.Path.GetFileName(filePath) != "")
                {
                    if (System.IO.Path.GetExtension(filePath) == ".xlsx")
                    {
                        inputBox.Visibility = Visibility.Hidden;
                        submitButton.Visibility = Visibility.Hidden;
                        GridWindow(filePath);
                    }
                    else
                    {
                        prompt.Text = $"Тут нужен .xlsx файлик, а не '{System.IO.Path.GetExtension(filePath)}' .. Еще разок?";
                    }
                }
                else
                {
                    prompt.Text = "А файлик то как назвать?";
                }
            }
            else
            {
                prompt.Text = "Какой-то неправильный путь.. Еще разок?";
            }
            
        }

        private void ShortView_Checked(object sender, RoutedEventArgs e)
        {
            if (dataGridUpdated != null && dataGridUpdated.Visibility == Visibility.Visible)
            {
                dataGridUpdated.Visibility = Visibility.Hidden;
            }
            if (dataGrid != null && dataGrid.Visibility == Visibility.Visible)
            {
                dataGrid.Visibility = Visibility.Hidden;
            }
            if (dataGridShort != null && dataGridShort.Visibility == Visibility.Hidden)
            {
                dataGridShort.Visibility = Visibility.Visible;
                ShortGrid.DisplayPage();
            }
           
        }

        private void FullView_Checked(object sender, RoutedEventArgs e)
        {
            if (dataGridUpdated != null && dataGridUpdated.Visibility == Visibility.Visible)
            {
                dataGridUpdated.Visibility = Visibility.Hidden;
            }
            if (dataGridShort != null && dataGridShort.Visibility == Visibility.Visible)
            {
                dataGridShort.Visibility = Visibility.Hidden;
            }
            if (dataGrid != null && dataGrid.Visibility == Visibility.Hidden)
            {
                dataGrid.Visibility = Visibility.Visible;
                FullGrid.DisplayPage();
            }
            
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            db.Update();
            if (db.DataGridUpdate.Count == 0)
            {
                ShowMessage($"Хорошие новости! Локальная база и так обновлена до последней версии {db.LastUpdate}");
            }
            else
            {
                ShowMessage("Обновление завершено!");
            }
            BeforeAfter.IsEnabled = true;
        }

        private void BeforeAfter_Click(object sender, RoutedEventArgs e)
        {
            if (BeforeAfter.Content != null && BeforeAfter.Content == "Назад")
            {
                if (dataGridUpdated != null && dataGridUpdated.Visibility == Visibility.Visible)
                {
                    dataGridUpdated.Visibility = Visibility.Hidden;
                }
                if (dataGrid != null && dataGrid.Visibility == Visibility.Visible)
                {
                    dataGrid.Visibility = Visibility.Hidden;
                }
                if (dataGridShort != null && dataGridShort.Visibility == Visibility.Hidden)
                {
                    dataGridShort.Visibility = Visibility.Visible;
                }
                BeforeAfter.Content = "Было/Стало";
                Refresh.IsEnabled = true;
                ShortView.Visibility = Visibility.Visible;
                FullView.Visibility = Visibility.Visible;
                FullGrid.DisplayPage();
                ShortGrid.DisplayPage();
            }
            else
            {
                if (dataGridShort != null && dataGridShort.Visibility == Visibility.Visible)
                {
                    dataGridShort.Visibility = Visibility.Hidden;
                }
                if (dataGrid != null && dataGrid.Visibility == Visibility.Visible)
                {
                    dataGrid.Visibility = Visibility.Hidden;
                }
                if (dataGridUpdated != null && dataGridUpdated.Visibility == Visibility.Hidden)
                {
                    dataGridUpdated.Visibility = Visibility.Visible;
                }
                ShortView.Visibility = Visibility.Hidden;
                FullView.Visibility = Visibility.Hidden;
                msgBox.Text = $"Всего изменений: {dataGridUpdated.Items.Count}, последнее обновление: {db.LastUpdate.ToString("HH:mm:ss dd.MM.yyyy")}";
                BeforeAfter.Content = "Назад";
                Refresh.IsEnabled = false;
                UpdateGrid.DisplayPage();
            }
            
        }

        private void SaveToFile_Click(object sender, RoutedEventArgs e)
        {
            Window saveWindow = new SaveFileWindow(db.FilePath);
            saveWindow.Show();
        }

        private void PageBack_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid.Visibility == Visibility.Visible)
            {
                FullGrid.Navigate(false);
            }
            else if (dataGridShort.Visibility == Visibility.Visible)
            {
                ShortGrid.Navigate(false);
            }
            else if (dataGridUpdated.Visibility == Visibility.Visible)
            {
                UpdateGrid.Navigate(false);
            }
        }

        private void PageForward_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid.Visibility == Visibility.Visible)
            {
                FullGrid.Navigate(true);
            }
            else if (dataGridShort.Visibility == Visibility.Visible)
            {
                ShortGrid.Navigate(true);
            }
            else if (dataGridUpdated.Visibility == Visibility.Visible)
            {
                UpdateGrid.Navigate(true);
            }
        }

        private void NumberOfRecords_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FullGrid.Step = (int)NumberOfRecords.SelectedItem;
            ShortGrid.Step = (int)NumberOfRecords.SelectedItem;
            FullGrid.SetCurrentPage(1);
            ShortGrid.SetCurrentPage(1);
            FullGrid.DisplayPage();
            ShortGrid.DisplayPage();
        }
    }
}
