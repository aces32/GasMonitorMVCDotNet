using MonitorGas.GasManagement.Application.Interfaces;
using MonitorGas.GasManagement.Data;
using MonitorGas.GasManagement.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitorGas.GasManagement.Application.Services
{
    public class GasRepository : BaseRepository<Gas>, IGasRepository
    {
        public GasRepository(MonitorGasDbContext dbContext) : base(dbContext)
        {

        }
    }
}
