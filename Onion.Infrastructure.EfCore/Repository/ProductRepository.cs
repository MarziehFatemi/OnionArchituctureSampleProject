﻿using Microsoft.EntityFrameworkCore;
using Onion.Domain.Product_agg;

namespace Onion.Infrastructure.EfCore.Repository
{
    public class ProductRepository : IProductRepository
    {
        Context _context; 
        public ProductRepository(Context context)
        {
            _context = context;
        }


        public void Create(Product product)
        {
            _context.Add(product); 
        }

        public Product Get(int id)
        {
            #pragma warning disable CS8603 // Possible null reference return.
            return _context.products
                .Include(c => c.Category)
                .FirstOrDefault(c => c.Id == id);
            #pragma warning restore CS8603 // Possible null reference return.
        }

        public bool Exist ( string name, int Categoryid)
        {
            return _context.products.Any(c => c.Name == name && c.CategoryId == Categoryid); 
        }
        public bool SaveChanges(out string Error)
        {
            try
            {
                _context.SaveChanges();
                Error = "با موفقیت ذخیره شد";
                return true;
            }
            catch (Exception ex)
            {
                Error = ex.ToString();
                return false;

            }
        }


        public List<Product> Search(string name)
        {
        return _context.products
                .Include(c => c.Category)
                .Where(c => c.Name.Contains(name))
                .OrderBy(c => c.Id)
                .ToList();
         
        }
        public List<Product> GetAll()
        {
            return _context.products
                .Include(c=>c.Category)
                .ToList();
        }

        public void Activate(Product product)
        {
            product.Activate();
            
        }

        public void DeActivate(Product product)
        {
            product.DeActivate();
            
        }
        

        public bool Edit(int id, int UnitPrice, string Name, int CategoryId, out string Error)
        {
            var Product = Get( id); 

            if (Product != null)
            {
                Product.Edit(UnitPrice, Name, CategoryId);
                _context.products.Update(Product);
                Error = "با موفقیت ویرایش شد";
                return true; 
            }
            else
            {
                Error = "متغیر مزبور موجود نیست";
                return false; 
            }

        }
    }
}
