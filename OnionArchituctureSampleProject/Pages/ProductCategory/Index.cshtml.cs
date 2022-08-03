using Microsoft.AspNetCore.Mvc.RazorPages;
using Onion.Application.Contracts;

namespace OnionArchituctureSampleProject.Pages.ProductCategory
{
    public class IndexModel : PageModel
    {
        public List<ProductCategoryViewModel> _ProductCategoryViewModel;
        public ProductCategoryViewModel AProductCategoryViewModel = new ProductCategoryViewModel(); 

        private readonly IProductCategoryApplication _IProductCategoryApplication; 
        public IndexModel(IProductCategoryApplication iProductCategoryApplication)
        {
            _IProductCategoryApplication = iProductCategoryApplication; 
        }

        public void OnGet()
        {
            _ProductCategoryViewModel = _IProductCategoryApplication.GetAll(); 
        }

        
    }
}
