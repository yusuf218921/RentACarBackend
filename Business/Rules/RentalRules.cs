using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules
{
    public class RentalRules
    {
        public static bool IsRentable(Car car)
        {
            return car.IsRentable;
        }
    }
}
