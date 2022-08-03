using Onion.Domain.Product_agg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.Application.Contracts.ProductApplication_Agg
{
    public class ProductViewModel
    {
        public int Id { get;  set; }
        public int UnitPrice { get;  set; }
        public string Name { get;  set; }
        public bool IsRemoved { get;  set; }
        public string Category { get;  set; }
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
