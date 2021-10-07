using System;
using System.ComponentModel.DataAnnotations;

namespace Test.Models
{
    public class Product
    {
        [Required]
        public int Id { get; set; }
        
        [Required (ErrorMessage = "Name is required")]
        [Display(Name = "Название продукта")]
        public string Name { get; set; }

        [Required (ErrorMessage = "Price is required")]
        [Display (Name = "Цена продукта")]
        public double Price { get; set; }

        [Required (ErrorMessage = "CategoryId is required")]
        [Range(1, 100)]
        public int CategoryId { get; set; }

        public string Photo { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
