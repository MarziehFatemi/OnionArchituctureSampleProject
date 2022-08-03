using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Onion.Application.Contracts;
using Onion.Application.Contracts.ProductApplication_Agg;

namespace OnionArchituctureSampleProject.Pages.Product
{
    public class CreateModel : PageModel
    {
        public CreateProductCommand Command { get; set; }



        private readonly IProductAppication _IProductApplication;

        public CreateModel(IProductAppication productAppication)
        {
            _IProductApplication = productAppication;

        }
        public void OnGet()
        {
        }
    }
}
