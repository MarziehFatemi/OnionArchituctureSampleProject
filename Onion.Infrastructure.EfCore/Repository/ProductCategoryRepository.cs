using Onion.Domain.Product_Category_agg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.Infrastructure.EfCore.Repository
{
    public class ProductCategoryRepository : IProductCategoryRepository
    {
        Context _context;
        public ProductCategoryRepository(Context context)
        {
            _context = context;
        }

        public void Create(ProductCategory productCategory)
        {
            _context.Add(productCategory); 
        }

        public bool Exist(string categoryName)
        {
            return _context.productCategories.Any(c=>c.Name == categoryName); 
        }

        public ProductCategory Get(int id)
        {
            return _context.productCategories.FirstOrDefault(c => c.Id == id);
        }

        public void Edit (int id, string Name)
        {
            var category = Get(id);
            if (category != null)
            {
                category.Edit(Name);
                _context.productCategories.Update(category);
            }

        }
        public void SaveChanges()
        {
            _context.SaveChanges(); 
        }

        public List<ProductCategory> Search(string name)
        {
            return _context.productCategories
                .Where(c=> c.Name.Contains(name))
                .OrderBy(c => c.Id)
                .ToList(); 
        }

    }
}
