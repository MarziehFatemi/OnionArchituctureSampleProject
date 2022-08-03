using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace OnionArchituctureSampleProject.Pages.Product
{
    public class EditModel : PageModel
    {
        public int Id { get; set; }
        public EditModel()
        {

        }
        public void OnGet(int id)
        {
            Id = id;
        }
    }
}
