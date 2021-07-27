using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonitorGas.GasManagement.Web.Models
{
    public class GasListViewModel
    {
        public Guid GasID { get; set; }
        public string GasVendorName { get; set; }
        public DateTime Date { get; set; }
        public string ImageUrl { get; set; }
    }
}