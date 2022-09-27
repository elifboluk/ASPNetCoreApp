using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNetServer.Data
{
    public class OrderDetail
    {
        [Key]
        public int OrderDetailId { get; set; }

        public decimal Total { get; set; }

        public int ProductId { get; set; }

        public virtual Product ProductName { get; set; }

        public int OrderId { get; set; }

        public virtual Order OrderingCompanyName { get; set; }
    }
}
