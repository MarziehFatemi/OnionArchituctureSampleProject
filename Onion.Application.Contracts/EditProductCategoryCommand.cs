﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.Application.Contracts
{
    public class EditProductCategoryCommand : CreateProductCategoryCommand
    {
        public int Id { get; set; }
    }
}