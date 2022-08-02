using Onion.Application.Contracts;
using Onion.Domain.Product_Category_agg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.Application
{
    public class ProductCategoryApplication : IProductCategoryApplication
    {
        private readonly IProductCategoryRepository ProductCatecoryRepository; 

        public ProductCategoryApplication(IProductCategoryRepository productCatecoryRepository)
        {
            ProductCatecoryRepository = productCatecoryRepository;
        }


        public void Create(CreateProductCategoryCommand Command)
        {
            if (ProductCatecoryRepository.Exist(Command.Name))
                return; 

            var PCategory = new ProductCategory(Command.Name); 
            ProductCatecoryRepository.Create(PCategory);
            ProductCatecoryRepository.SaveChanges();
        }

        public void Edit(EditProductCategoryCommand Command)
        {
            ProductCatecoryRepository.Edit(Command.Id, Command.Name);
            ProductCatecoryRepository.SaveChanges();


        }

        public List<ProdcutCategoryViewModel> Search(string name)
        {
            ProdcutCategoryViewModel Instance = new ProdcutCategoryViewModel(); 
            return Instance.MapFromProductCategory(ProductCatecoryRepository.Search(name)); 
        
                    
        }
    }
}
