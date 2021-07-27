using MonitorGas.GasManagement.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitorGas.GasManagement.Application.Interfaces
{
    public interface IGasSizeRepository : IAsyncRepository<GasSize>
    {
        List<GasSize> GetGasSizesWithGas(bool includeHistory);
    }
}
