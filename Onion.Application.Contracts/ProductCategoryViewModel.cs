using Onion.Domain.Product_Category_agg;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace Onion.Application.Contracts
{

    public class ProductCategoryViewModel
    {
        [DisplayName("شماره")]
        public int Id { get; set; }

        [DisplayName("نام")]
        [Required(ErrorMessage = "نام اجباری است")]
        [MaxLength(255)]
        public string Name { get; set; }

        [DisplayName("تاریخ ایجاد")]
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
