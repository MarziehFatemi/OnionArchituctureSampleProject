
namespace Onion.Domain.Product_Category_agg
{
    public interface IProductCategoryRepository
    {
         ProductCategory Get(int id);
        void Create(ProductCategory productCategory);

    }
}
