using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonitorGas.GasManagement.Web.Models
{
    public class GasSizesWithGasModel
    {
        public Guid GasSizeID { get; set; }
        public double SizeInKg { get; set; }
        public ICollection<GasesNestedViewModel> Gases { get; set; }
    }
}