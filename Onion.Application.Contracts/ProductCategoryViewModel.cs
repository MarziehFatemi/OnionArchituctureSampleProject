using Onion.Domain.Product_Category_agg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.Application.Contracts
{

    public class ProdcutCategoryViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CreationDate { get; set; }

        public ProdcutCategoryViewModel()
        {

        }
        public ProdcutCategoryViewModel(int id, string name, DateTime creationDate)
        {
            Id = id;
            Name = name;
           CreationDate = creationDate.ToString(); 
        }


        public List<ProdcutCategoryViewModel> MapFromProductCategory (List<ProductCategory> productCategories)
        {
            List<ProdcutCategoryViewModel> prodcutCategoryViewModel = new List<ProdcutCategoryViewModel>(); ;

            foreach (var productCategory in productCategories)
            {
               
                prodcutCategoryViewModel.Add(new ProdcutCategoryViewModel()
                {
                    Id = productCategory.Id,
                    Name = productCategory.Name,
                    CreationDate = productCategory.CreationDate.ToString(),

                }); 
                 
               
            }

            return prodcutCategoryViewModel;
        }
    }
    
}
