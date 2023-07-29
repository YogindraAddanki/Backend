﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrudOperationInNetCore.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }

        public int BrandId { get; set; }

        [ForeignKey("BrandId")]
        public Brand? Brand {  get; set; }

        


        

    }
}
