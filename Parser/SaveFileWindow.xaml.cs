using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Parser
{
    /// <summary>
    /// Логика взаимодействия для SaveFileWindow.xaml
    /// </summary>
    public partial class SaveFileWindow : Window
    {
        public string FilePath { get; private set; }
        public bool UpdateBD { get; private set; } = false;
        public SaveFileWindow(string filePath)
        {
            FilePath = filePath;
            InitializeComponent();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.AddExtension = true;
            saveFileDialog.DefaultExt = ".xlsx";
            saveFileDialog.Filter = "Excel file (*.xlsx)|*.xlsx";
            if (saveFileDialog.ShowDialog() == true)
            {
                File.Copy(FilePath, saveFileDialog.FileName, true);
            }

        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
