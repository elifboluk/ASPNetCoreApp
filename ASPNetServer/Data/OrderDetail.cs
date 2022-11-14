using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNetServer.Data
{
    internal sealed class OrderDetail
    {
        [Key]
        public int OrderDetailId { get; set; }
        public decimal Total { get; set; }
        public string? ProductName { get; set; }
        public int ProductQuantity { get; set; }
        public decimal ProductPrice { get; set; }
        public string? OrderingCompanyName { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
