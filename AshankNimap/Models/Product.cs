using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AshankNimap.Models
{
    public class Product
    {
        public int ProductId {  get; set; }

        [Required(ErrorMessage = "Product Name is required")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Product must be between 2 and 50 characters")]
        public string ProductName { get;set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }
    }
}