using ClientApp.ViewModel;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using System.Windows;

namespace ClientApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public ViewModelLocator VMLocator
        {
            get
            {
                ViewModelLocator vml = (ViewModelLocator)Application.Current.Resources["Locator"];
                return vml;
            }
        }
    }
}
