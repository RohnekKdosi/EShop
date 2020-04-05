using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EShop.Data;

namespace EShop.Services
{
    public class DataProvider
    {
        public DataProvider(ApplicationDbContext db)
        {
            _db = db;
        }

        private ApplicationDbContext _db { get; set; }

        public ICollection<Category> GetCategories()
        {
            return _db.Categories.ToList();
        }

    }
}
