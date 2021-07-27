using System;

namespace MonitorGas.GasManagement.Web.Models
{
    public class GasesNestedViewModel
    {
        public Guid GasID { get; set; }
        public string GasVendorName { get; set; }
        public int Price { get; set; }
        public string Color { get; set; }
        public DateTime Date { get; set; }
        public Guid GasSizeID { get; set; }
    }
}