using MonitorGas.GasManagement.Data.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitorGas.GasManagement.Data.Entities
{
    public class GasSize : AuditableEntity
    {
        public Guid GasSizeID { get; set; }
        public double SizeInKg { get; set; }
        public ICollection<Gas> Gases { get; set; }
    }
}
