using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Onion.Application.Contracts.ProductApplication_Agg;

namespace OnionArchituctureSampleProject.Pages.Product
{
    public class IndexModel : PageModel
    {
        public List<ProductViewModel> ProductsViewModel { get; set; }

        private readonly IProductAppication _ProductApplication; 
        
        public IndexModel(IProductAppication productAppication)
        {
            _ProductApplication = productAppication;
        }

        public void OnGet()
        {
            ProductsViewModel = _ProductApplication.GetAll(); 
        }
    }
}
