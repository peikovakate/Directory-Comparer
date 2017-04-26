using System.Windows.Forms;
using System.Windows.Input;
using TestTask.Model;

namespace TestTask.ViewModel
{
    class MainWindowViewModel
    {
        public MainWindowViewModel()
        {
            Comparer = new DComparer();

            ChangeFirst = new Command(arg => ClickMethod(1));
            ChangeSecond = new Command(arg => ClickMethod(2));
        }

        public DComparer Comparer { get; set; }

        //command to change path to first directory
        public ICommand ChangeFirst { get; set; }
        //command to change path to second directory
        public ICommand ChangeSecond { get; set; }

        private void ClickMethod(ushort dir)
        {
            using (var dialog = new FolderBrowserDialog())
            {
                DialogResult result = dialog.ShowDialog();
                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    if (dir == 1)
                    {
                        Comparer.Path1 = dialog.SelectedPath;
                    }
                    else
                    {
                        Comparer.Path2 = dialog.SelectedPath;
                    }
                }
            }
        }

    }
}
