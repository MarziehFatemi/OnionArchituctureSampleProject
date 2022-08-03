﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.Application.Contracts
{
    public class CreateProductCommand
    {
        [DisplayName("قیمت")]
        [Required(ErrorMessage = "قیمت اجباری است")]
         public int UnitPrice { get;  set; }

        [DisplayName("نام")]
        [Required(ErrorMessage = "نام اجباری است")]
        [MaxLength(255)]
        public string Name { get;  set; }

        [DisplayName("گروه محصول")]
        [Required(ErrorMessage = "گروه محصول اجباری است")]
        [Range(1,100,ErrorMessage ="گروه محصول را درست انتخاب کنید محدودیت 100 محصول")]
        public int CategoryId{ get; set; }
       
    }

}
