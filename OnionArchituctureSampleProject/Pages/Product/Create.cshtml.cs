using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Onion.Application.Contracts;
using Onion.Application.Contracts.ProductApplication_Agg;

namespace OnionArchituctureSampleProject.Pages.Product
{
    public class CreateModel : PageModel
    {
        public SelectList ProductCategories; 
        public CreateProductCommand Command { get; set; }



        private readonly IProductAppication _IProductApplication;
        private readonly IProductCategoryApplication _IProductCategoryApplication;


        public CreateModel(IProductAppication productAppication, IProductCategoryApplication iProductCategoryApplication)
        {
            _IProductApplication = productAppication;
            _IProductCategoryApplication = iProductCategoryApplication;
        }
        public void OnGet()
        {
            ProductCategories = new SelectList
                (_IProductCategoryApplication.GetAll(), "Id", "Name"); 
        }

        public IActionResult OnPost(CreateProductCommand Command)
        {
            if ( ModelState.IsValid)
            {
                string Error = "";
                if (_IProductApplication.Create(Command, out Error))
                { return RedirectToPage("/Product/Index"); }
                else
                {
                    ViewData["Error"] = Error;
                    return Page();

                }

            }

            else 
            {
                ViewData["Error"] = "مشکلی پیش امده مجدد تلاش کنید";
                return Page(); 
            }
        }
    }
}
