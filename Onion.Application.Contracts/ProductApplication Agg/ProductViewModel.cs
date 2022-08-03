using Onion.Domain.Product_agg;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.Application.Contracts.ProductApplication_Agg
{
    public class ProductViewModel
    {
        [DisplayName("شماره")]
        public int Id { get;  set; }

        [DisplayName("قیمت")]
        [Required(ErrorMessage = "قیمت اجباری است")]
        [MaxLength(255)]
        public int UnitPrice { get;  set; }


        [DisplayName("نام")]
        [Required(ErrorMessage = "نام اجباری است")]
        [MaxLength(255)]
        public string Name { get;  set; }
        public bool IsRemoved { get;  set; }

        [DisplayName("گروه محصول")]
        [Required(ErrorMessage = "گروه محصول اجباری است")]
        [MaxLength(255)]
        public string Category { get;  set; }

        [DisplayName("تاریخ ایجاد")]
        public string CreationDate { get;  set; }

        public ProductViewModel(int id, int uintPrice, string name, bool isRemoved, string category, string creationDate)
        {
            Id = id;
            UnitPrice = uintPrice;
            Name = name;
            IsRemoved = isRemoved;
            Category = category;
            CreationDate = creationDate;
        }

        

    }
}
