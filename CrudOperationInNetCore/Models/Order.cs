using System.ComponentModel.DataAnnotations.Schema;

namespace CrudOperationInNetCore.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [ForeignKey("Brand")]
        public Brand Brandid { get ; set; }

    }
}
