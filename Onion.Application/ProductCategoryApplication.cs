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
                if (ProductCatecoryRepository.SaveChanges(out Error))
                {
                    Error = "با موفقیت ذخیره شد";
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool Edit(EditProductCategoryCommand Command, out string Error)
        {
           if ( ProductCatecoryRepository.Edit(Command.Id, Command.Name, out Error))
            {
                if (ProductCatecoryRepository.SaveChanges(out Error))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
           else
            {
                return false; 
            }
           


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


        public EditProductCategoryCommand GetEntity(int Id)
        {
            var Command = new EditProductCategoryCommand(Id,
                ProductCatecoryRepository.Get(Id).Name);

            return Command;
        }
       

    }
}
