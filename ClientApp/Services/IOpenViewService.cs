using ClientApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientApp.Services
{
    public interface IOpenViewService
    {
        MainViewModel OpenMainWindow();
    }
}
