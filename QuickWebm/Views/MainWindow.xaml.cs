using Microsoft.Win32;
using QuickWebm.ViewModels;
using System;
using System.Windows;
using System.Windows.Controls;

namespace QuickWebm
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(QuickWebmConverterViewModel vm)
        {
            InitializeComponent();
            DataContext = vm;
        }

        private void BrowseForInputFile_OnClick(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog
            {
                Filter = "Video files (*.mp4;*.avi;*.mkv;*.m4v)|*.mp4;*.avi;*.mkv;*.m4v",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyVideos)
            };

            if (dialog.ShowDialog() == true)
            {
                InputTextBox.Text = dialog.FileName;
                InputTextBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            }
        }

        private void BrowseForOutputFolder_OnClick(object sender, EventArgs e)
        {
            var dialog = new SaveFileDialog()
            {
                DefaultExt = ".webm",
                Filter = "Webm files (*.webm)|*.webm"
            };

            if (dialog.ShowDialog() == true)
            {
                OutputTextBox.Text = dialog.FileName;
                OutputTextBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            }
        }
    }
}
