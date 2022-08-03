using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.Application.Contracts
{
    public  class EditProductCommand: CreateProductCommand
    {
        public int Id { get;  set; }
        public EditProductCommand()
        {

        }
        public EditProductCommand(int id, string name, int unitPrice, int categoryId)
        {

            Id = id;
            Name = name;
            UnitPrice = unitPrice;
            CategoryId = categoryId; 
        }
    }
}
