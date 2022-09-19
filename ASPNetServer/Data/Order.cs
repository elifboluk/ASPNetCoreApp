using System.ComponentModel.DataAnnotations;

namespace ASPNetServer.Data
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        public DateTime OrderDate { get; set; }

        [Required]
        public string OrderingCompanyName { get; set; }


        

    }
}
