using System;
using System.ComponentModel.DataAnnotations;

namespace DutchTreat.Models
{
    public class OrderModel
    {
        public int OrderId { get; set; }

        [Required]
        [MinLength(4, ErrorMessage="Order number must be atleast four characters")]
        public string OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
    }
}