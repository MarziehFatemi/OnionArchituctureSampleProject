using Onion.Application.Contracts;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;

namespace OnionArchituctureSampleProject.Pages.ProductCategory
{
    public class EditModel : PageModel
    {

        public EditProductCategoryCommand Command { get; set; }
        string Error = "";

        private readonly IProductCategoryApplication _IProductCategoryApplication;

        public EditModel(IProductCategoryApplication iProductCategoryApplication)
        {
            _IProductCategoryApplication = iProductCategoryApplication;
        }

        public void OnGet(int id)
        {
            Command = _IProductCategoryApplication.GetEntity(id);
        
        }
        public IActionResult OnPost(EditProductCategoryCommand Command)
        {
            if (_IProductCategoryApplication.Edit(Command, out Error))
            {
                return RedirectToPage("/ProductCategory/Index");

            }
            else
            {
                ViewData["Error"] = Error;
                return Page();
            }
        }

    }
}
