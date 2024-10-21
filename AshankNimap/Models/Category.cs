using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AshankNimap.Models
{
    public class Category
    {
        public int CategoryId { get; set;}
        [Required(ErrorMessage = "Category Name is required")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Category must be between 2 and 50 characters")]
        public string CategoryName { get; set;}
        public ICollection<Product> Products { get; set;}
    }
}