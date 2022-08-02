
using System.Collections.Generic;

namespace Onion.Domain.Product_Category_agg
{
    public interface IProductCategoryRepository
    {
         ProductCategory Get(int id);
        void Create(ProductCategory productCategory);
        void SaveChanges();
        List<ProductCategory> Search(string name);

    }
}
