using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.Application.Contracts
{
    public class CreateProductCommand
    {
        public int UintPrice { get;  set; }
        public string Name { get;  set; }
        public int CategoryId{ get; set; }
       
    }

}
