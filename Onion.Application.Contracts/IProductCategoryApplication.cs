using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.Application.Contracts
{
    public interface IProductCategoryApplication
    {
       
        void Create(CreateProductCategoryCommand Command);
        void Edit (EditProductCategoryCommand Command);
        List<ProdcutCategoryViewModel> Search(string name); 

    }
}
