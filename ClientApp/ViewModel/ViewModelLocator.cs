using ClientApp.Services;
using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientApp.ViewModel
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            SimpleIoc.Default.Register<IOpenViewService, OpenViewService>();
            SimpleIoc.Default.Register<ILogService, LogService>();
            SimpleIoc.Default.Register<MainViewModel>();
        }

        public IOpenViewService OpenViewService
        {
            get
            {
                return ServiceLocator.Current.GetInstance<OpenViewService>();
            }
        }

        public ILogService LogService
        {
            get
            {
                return ServiceLocator.Current.GetInstance<LogService>();
            }
        }

        public MainViewModel MainVM
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }
    }
}
