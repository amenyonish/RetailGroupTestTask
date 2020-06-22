using ClientApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientApp.Services
{
    public class OpenViewService : IOpenViewService
    {
        public MainViewModel OpenMainWindow()
        {
            MainViewModel MainVM = null;
            try
            {
                MainWindow mainWindow = new MainWindow();
                MainVM = ((App)App.Current).VMLocator.MainVM;
                mainWindow.DataContext = MainVM;
                mainWindow.Show();
            }
            catch (Exception)
            {
                //logService.Write(ex.ToString());
            }
            return MainVM;
        }
    }
}
