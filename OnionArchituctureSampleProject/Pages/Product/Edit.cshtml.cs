using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Onion.Application.Contracts;
using Onion.Application.Contracts.ProductApplication_Agg;

namespace OnionArchituctureSampleProject.Pages.Product
{
    public class EditModel : PageModel
    {
        public SelectList ProductCategories;
        public int Id { get; set; }
        public EditProductCommand Command { get; set; }
        
        
        public IProductAppication _iProductApplication;
        public IProductCategoryApplication _iProductCategoryApplication; 
        
        public EditModel(IProductAppication iproductApplication, IProductCategoryApplication iproductCategoryApplication)
        {
            _iProductApplication = iproductApplication;
            _iProductCategoryApplication = iproductCategoryApplication;
        }

        public void OnGet(int id)
        {

            bool IsNull = false;
            string Error = "";
            Command = _iProductApplication.GetBy(id, out IsNull, out Error);
            ProductCategories = new SelectList(_iProductCategoryApplication.GetAll(), "Id", "Name");
            if (IsNull)
            {
                ViewData["Error"] = Error;
            }

        }
        public IActionResult OnPost(EditProductCommand Command)
        {
            string Error = "";
            if (_iProductApplication.Edit(Command, out Error))
            {
                return RedirectToPage("/Product/Index");

            }
            else
            {
                ViewData["Error"] = Error;
                return Page();
            }

        }
    }
}
