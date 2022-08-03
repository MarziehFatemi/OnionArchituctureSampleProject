using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Onion.Application.Contracts
{
    public class CreateProductCategoryCommand
    {
        [DisplayName("نام")]
        [Required(ErrorMessage = "نام اجباری است")]
        [MaxLength(255)]

        public string  Name { get; set; }
    }

   
    
}
