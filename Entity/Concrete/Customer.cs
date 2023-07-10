using Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Customer : IEntity
    {
        public int CustomerID { get; set; }
        public int UserID { get; set; }
        public string CompanyName { get; set; }
    }
}
