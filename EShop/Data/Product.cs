using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.Data
{
    public class Product
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public int InStock { get; set; }
        [Required]
        public float Price { get; set; }
        public string Description { get; set; }
        [Required]
        public string Name { get; set; }
        public ICollection<ProductPath> ProductPaths { get; set; }
        [Required]
        public ICollection<Category> CategoryProducts { get; set; }
    }
}
