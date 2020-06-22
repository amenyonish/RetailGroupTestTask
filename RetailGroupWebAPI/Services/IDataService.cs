using RetailGroupWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RetailGroupWebAPI.Services
{
    public interface IDataService
    {
        void WriteSpaceInfo(ComputerInfo info);
    }
}
