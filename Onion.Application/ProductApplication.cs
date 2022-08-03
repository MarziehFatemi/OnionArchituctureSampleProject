using Onion.Application.Contracts;
using Onion.Application.Contracts.DataMapping;
using Onion.Application.Contracts.ProductApplication_Agg;
using Onion.Domain.Product_agg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.Application
{
    public class ProductApplication : IProductAppication
    {
        private readonly IProductRepository _IProductRepository; 
        public ProductApplication(IProductRepository iProductRepository)
        {
            _IProductRepository = iProductRepository; 

        }
        public bool Activate(int id, out string Error)
        {
            _IProductRepository.Activate(_IProductRepository.Get(id));
           return  _IProductRepository.SaveChanges(out Error); 


        }
        public bool DeActivate(int id, out string Error)
        {
            _IProductRepository.Activate(_IProductRepository.Get(id));
            return _IProductRepository.SaveChanges(out Error);

        }

        public bool Create(CreateProductCommand Command, out string Error)
        {
            if (!_IProductRepository.Exist(Command.Name, Command.CategoryId))
            {
                _IProductRepository.Create(new Product(Command.UnitPrice, Command.Name, Command.CategoryId));
                return _IProductRepository.SaveChanges(out Error);
            }
            {
                Error = "نام و گروه محصول تکراری است. ";
                return false; 
            }

        }



        public bool Edit(EditProductCommand Command, out string Error)
        {
            
            if (_IProductRepository.Edit(Command.Id, Command.UnitPrice, Command.Name, Command.CategoryId, out Error))
            {
                return _IProductRepository.SaveChanges(out Error);
            }
            {

                return false; 
            }

        }
        public List<ProductViewModel> Search(string name)
        {
            return DataMapping.ProductList2ProductViewModelList(_IProductRepository.Search(name));


        }

        public List<ProductViewModel> GetAll()
        {
          return DataMapping.ProductList2ProductViewModelList(_IProductRepository.GetAll()); 
        }

        public EditProductCommand GetBy(int id)
        {
            return DataMapping.Product2EditProduct( _IProductRepository.Get(id));
            
        }
    }
}
