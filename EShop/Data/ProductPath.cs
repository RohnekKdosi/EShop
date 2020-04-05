using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.Data
{
    public class ProductPath
    {
        [Key]
        public int ProductID { get; set; }
        [Key]
        public int PathID { get; set; }
        public Product Product { get; set; }
        public ImagePath Path { get; set; }
    }
}
