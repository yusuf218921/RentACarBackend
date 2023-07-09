using Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Brand : IEntity
    {
        public int BrandID { get; set; }
        public string BrandName { get; set; }
    }
}
