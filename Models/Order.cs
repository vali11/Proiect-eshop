using System.ComponentModel.DataAnnotations;

namespace Proiect_eshop.Models
{
    public class Order
    {
        public int ID { get; set; }
        public int? MemberID { get; set; }
        public Member? Member { get; set; }
        public int? ProductID { get; set; }
        public Product? Product { get; set; }
        [DataType(DataType.Date)]
        public DateTime PlacementDate { get; set; }
        public int Quantity { get; set; }   

    }
}
