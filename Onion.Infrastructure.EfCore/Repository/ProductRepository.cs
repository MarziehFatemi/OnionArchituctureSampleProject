using Onion.Domain.Product_agg;

namespace Onion.Infrastructure.EfCore.Repository
{
    public class ProductRepository : IProductRepository
    {
        Context _context; 
        public ProductRepository(Context context)
        {
            _context = context;
        }


        public void Create(Product product)
        {
            _context.Add(product); 
        }

        public Product Get(int id)
        {
            #pragma warning disable CS8603 // Possible null reference return.
            return _context.products.FirstOrDefault(c => c.Id == id);
            #pragma warning restore CS8603 // Possible null reference return.
        }

        public void SaveChanges()
        {
            _context.SaveChanges(); 
        }

        public List<Product> Search(string name)
        {
        return _context.products
                .Where(c => c.Name.Contains(name))
                .OrderBy(c => c.Id)
                .ToList();
         
        }
    }
}
