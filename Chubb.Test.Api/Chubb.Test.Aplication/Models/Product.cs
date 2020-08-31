using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Chubb.Test.Aplication.Models
{
    public class Product
    {
        [Required]
        public int ProductId { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Category { get; set; }
        public decimal Price { get; set; }
        public int Amount { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
    }
    
}
