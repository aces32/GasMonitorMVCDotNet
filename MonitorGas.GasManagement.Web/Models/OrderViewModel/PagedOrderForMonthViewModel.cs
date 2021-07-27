using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonitorGas.GasManagement.Web.Models.OrderViewModel
{
    public class PagedOrderForMonthViewModel
    {
        public int Count { get; set; }
        public int Page { get; set; }
        public int Size { get; set; }
        public ICollection<OrdersForMonthListViewModel> OrdersForMonth { get; set; }
    }
}