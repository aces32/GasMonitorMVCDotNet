using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonitorGas.GasManagement.Web.Models.OrderViewModel
{
    public class OrdersForMonthListViewModel
    {
        public Guid Id { get; set; }
        public int OrderTotal { get; set; }
        public DateTime OrderPlaced { get; set; }
    }
}