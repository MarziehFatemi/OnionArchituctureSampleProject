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


        public bool Create(CreateProductCategoryCommand Command, out string Error)
        {
            if (ProductCatecoryRepository.Exist(Command.Name))
            {
                Error = "نام گروه تکراری است یک نام متفاوت انتخاب کنید";

                return false;
            }
            else
            {
                var PCategory = new ProductCategory(Command.Name);
                ProductCatecoryRepository.Create(PCategory);
                ProductCatecoryRepository.SaveChanges();
                Error = "با موفقیت ذخیره شد";
                return true; 
             }
        }

        public void Edit(EditProductCategoryCommand Command)
        {
            ProductCatecoryRepository.Edit(Command.Id, Command.Name);
            ProductCatecoryRepository.SaveChanges();


        }

        public List<ProductCategoryViewModel> Search(string name)
        {
            ProductCategoryViewModel Instance = new ProductCategoryViewModel(); 
            return Instance.MapFromProductCategory(ProductCatecoryRepository.Search(name)); 
        
                    
        }

        public List<ProductCategoryViewModel> GetAll()
        {
            ProductCategoryViewModel Instance = new ProductCategoryViewModel();
            return Instance.MapFromProductCategory(ProductCatecoryRepository.GetAll());


        }
    }
}
