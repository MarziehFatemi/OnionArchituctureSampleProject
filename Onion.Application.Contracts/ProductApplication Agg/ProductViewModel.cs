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
        public int UintPrice { get;  set; }
        public string Name { get;  set; }
        public bool IsRemoved { get;  set; }
        public string Category { get;  set; }
        public string CreationDate { get;  set; }


    }
}
