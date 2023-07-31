using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrudOperationInNetCore.Models
{
    public class Customer
    {
        [Key]

        public int Id { get; set; }

        public String? CustomerName { get; set; }

        public String? Email { get; set; }

        public String? Phone { get; set; }

        public int BrandId { get; set; }

        [ForeignKey("BrandId")]

        public ICollection<Brand>? Brands { get; set; }

        public int OrderId { get; set; }

        [ForeignKey("OrderId")]

        public Order? Order { get; set; }   




    }
}
