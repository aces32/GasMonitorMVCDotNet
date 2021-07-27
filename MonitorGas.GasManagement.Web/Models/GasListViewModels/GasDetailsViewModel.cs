using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MonitorGas.GasManagement.Web.Models
{
    public class GasDetailsViewModel
    {
        public Guid GasID { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "The vendor name should be 50 characters or less")]
        public string GasVendorName { get; set; }
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Price should be a positive value")]
        public int Price { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "The color should be 50 characters or less")]
        public string Color { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
        [Required]
        [StringLength(500, ErrorMessage = "The description can't be longer than 500 characters")]
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public Guid GasSizeID { get; set; }
        public GasSizesViewModel GasSize { get; set; }

    }
}