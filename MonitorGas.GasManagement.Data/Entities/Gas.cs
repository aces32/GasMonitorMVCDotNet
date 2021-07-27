using MonitorGas.GasManagement.Data.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitorGas.GasManagement.Data.Entities
{
    public class Gas : AuditableEntity
    {
        public Guid GasID { get; set; }
        public string GasVendorName { get; set; }
        public int Price { get; set; }
        public string Color { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public Guid GasSizeID { get; set; }
        public GasSize GasSize { get; set; }
    }
}
