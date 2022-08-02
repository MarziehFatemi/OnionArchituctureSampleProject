using Onion.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.Application
{
    public class ProductCategoryApplication : IProductCategoryApplication
    {
        public void Create(CreateProductCategoryCommand Command)
        {
            throw new NotImplementedException();
        }

        public void Edit(EditProductCategoryCommand Command)
        {
            throw new NotImplementedException();
        }

        public List<ProdcutCategoryViewModel> Search(string name)
        {
            throw new NotImplementedException();
        }
    }
}
