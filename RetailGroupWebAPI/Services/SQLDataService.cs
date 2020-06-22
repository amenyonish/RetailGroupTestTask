using Microsoft.Extensions.Configuration;
using RetailGroupWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RetailGroupWebAPI.Services
{
    public class SQLDataService : IDataService
    {
        private RetailGroupDBContext _context;

        public SQLDataService(RetailGroupDBContext context)
        {
            _context = context;
        }

        public void WriteSpaceInfo(ComputerInfo info)
        {
            _context.ComputersInfo.Add(info);
            _context.SaveChanges();
        }
    }
}
