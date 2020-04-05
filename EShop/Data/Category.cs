using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.Data
{
    public class Category
    {
        [Key]
        public int ID { get; set; }
        public int? ParentID { get; set; }
        [Required]
        public string DisplayName { get; set; }
        public string IdentifierName { get; set; }
        [ForeignKey("ParentID")]
        public Category Parent { get; set; }
        [InverseProperty("Parent")]
        public ICollection<Category> Subcategories { get; set; }
        public ICollection<CategoryProduct> CategoryProducts { get; set; }
    }
}
