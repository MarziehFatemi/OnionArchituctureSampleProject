using Onion.Application.Contracts;
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
            
            _IProductRepository.Create(new Product(Command.UintPrice, Command.Name, Command.CategoryId));
            return _IProductRepository.SaveChanges(out Error);

        }



        public bool Edit(EditProductCommand Command, out string Error)
        {
            
            if (_IProductRepository.Edit(Command.Id, Command.UintPrice, Command.Name, Command.CategoryId, out Error))
            {
                return _IProductRepository.SaveChanges(out Error);
            }
            {

                return false; 
            }

        }

        public List<ProductViewModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public EditProductCommand GetBy(int id)
        {
            throw new NotImplementedException();
        }
    }
}
