using System.Windows;
using TestTask.View;
using TestTask.ViewModel;

namespace TestTask
{
    public partial class App : Application
    {
        public App()
        {
            //Main view
            var mw = new MainWindowView
            {
                //View Model for main view
                DataContext = new MainWindowViewModel()
            };
            mw.Show();
        }
    }
}
