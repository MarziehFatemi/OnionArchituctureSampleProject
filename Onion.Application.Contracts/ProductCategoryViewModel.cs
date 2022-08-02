using Onion.Domain.Product_Category_agg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.Application.Contracts
{

    public class ProductCategoryViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CreationDate { get; set; }

        public ProductCategoryViewModel()
        {

        }
        public ProductCategoryViewModel(int id, string name, DateTime creationDate)
        {
            Id = id;
            Name = name;
           CreationDate = creationDate.ToString(); 
        }


        public List<ProductCategoryViewModel> MapFromProductCategory (List<ProductCategory> productCategories)
        {
            List<ProductCategoryViewModel> productCategoryViewModel = new List<ProductCategoryViewModel>(); ;

            foreach (var productCategory in productCategories)
            {
               
                productCategoryViewModel.Add(new ProductCategoryViewModel()
                {
                    Id = productCategory.Id,
                    Name = productCategory.Name,
                    CreationDate = productCategory.CreationDate.ToString(),

                }); 
                 
               
            }

            return productCategoryViewModel;
        }
    }
    
}
