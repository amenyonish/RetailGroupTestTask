using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RetailGroupWebAPI.Models
{
    public class RetailGroupDBContext : DbContext
    {
        public RetailGroupDBContext(DbContextOptions<RetailGroupDBContext> options)
            : base(options)
        {
        }

        public DbSet<ComputerInfo> ComputersInfo { get; set; }
    }
}
