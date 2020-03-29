using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.Data
{
    public class Product
    {
        [Required]
        public int ID { get; set; }
        [Required]
        public int InStock { get; set; }
        [Required]
        public float Price { get; set; }
        public string Description { get; set; }
        [Required]
        public string Name { get; set; }
        public List<string> ImagePaths { get; set; }
        [Required]
        public List<Category> Categories { get; set; }
    }
}
