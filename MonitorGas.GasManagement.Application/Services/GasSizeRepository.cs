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
    public class GasSizeRepository : BaseRepository<GasSize>, IGasSizeRepository
    {
        public GasSizeRepository(MonitorGasDbContext dbContext) : base(dbContext)
        {
        }

        public List<GasSize> GetGasSizesWithGas(bool includeHistory)
        {
            var allGasSize = _dbContext.GasSizes.Include(nameof(_dbContext.Gases)).ToList();
            if (!includeHistory)
            {
                allGasSize.ForEach(p => p.Gases.ToList().RemoveAll(c => c.Date < DateTime.Today));
            }
            return allGasSize;
        }
    }
}
