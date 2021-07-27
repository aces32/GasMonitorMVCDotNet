using MonitorGas.GasManagement.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitorGas.GasManagement.Data
{
    public class MonitorGasDbContext : DbContext
    {
        public DbSet<Gas> Gases { get; set; }
        public DbSet<GasSize> GasSizes { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
