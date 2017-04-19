using System.Windows;
using System.Windows.Forms;


namespace TestTask
{
    public partial class MainWindow : Window
    {
        DComparer comparer;

        public MainWindow()
        {
            InitializeComponent();
            comparer = new DComparer();
        }

        private void reloadTable()
        {
            InfoTable.ItemsSource = null;
            InfoTable.ItemsSource = comparer.Files;
        }

        private void FirstDirectory_Change(object sender, RoutedEventArgs e)
        {
            using (var dialog = new FolderBrowserDialog())
            {
                DialogResult result = dialog.ShowDialog();
                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    comparer.Path1 = dialog.SelectedPath;
                    FirstPathTextBlock.Text = dialog.SelectedPath;
                    reloadTable();
                }
            }   
        }

        private void SecondDirectory_Change(object sender, RoutedEventArgs e)
        {
            using (var dialog = new FolderBrowserDialog())
            {
                DialogResult result = dialog.ShowDialog();
                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    comparer.Path2 = dialog.SelectedPath;
                    SecondPathTextBlock.Text = dialog.SelectedPath;
                }
            }
            reloadTable();
        }
    }
}
