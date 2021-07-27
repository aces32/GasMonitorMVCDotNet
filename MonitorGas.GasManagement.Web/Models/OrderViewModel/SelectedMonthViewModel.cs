using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MonitorGas.GasManagement.Web.Models.OrderViewModel
{
    public class SelectedMonthViewModel
    {
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime OrderDate { get; set; }

        public List<OrdersForMonthListViewModel> Sales
        {
            get;
            set;
        }
    }
}