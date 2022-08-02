using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Onion.Application.Contracts;

namespace OnionArchituctureSampleProject.Pages.ProductCategory
{
    public class CreateModel : PageModel
    {
        public CreateProductCategoryCommand Command { get; set; } 



        private readonly IProductCategoryApplication _IProductCategoryApplication;
        public CreateModel(IProductCategoryApplication iProductCategoryApplication)
        {
            _IProductCategoryApplication = iProductCategoryApplication;
        }

        public void OnGet()
        {
        }
        public IActionResult OnPost(CreateProductCategoryCommand Command)
        {
            string Error = "";
            if (ModelState.IsValid)
            {
                if (_IProductCategoryApplication.Create(Command, out Error))
                {
                    return RedirectToPage("/ProductCategory/Index");
                }
                else
                {
                    ViewData["Error"] = Error;
                    return Page();
                }
            }
            else
            {
                Error = ModelState.Select(x => x.Value.Errors)
                           .Where(y => y.Count > 0).ToString(); 
                return Page();
            }


        }
    }
}
