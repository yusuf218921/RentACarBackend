using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, NorthwindContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetail()
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var result = from car in context.Cars
                             join color in context.Colors on car.ColorID equals color.ColorID
                             join brand in context.Brands on car.BrandID equals brand.BrandID
                             select new CarDetailDto
                             {
                                 CarId = car.CarID,
                                 CarName = car.CarName,
                                 BrandName = brand.BrandName,
                                 ColorName = color.ColorName,
                                 DailyPrice = car.DailyPrice,
                                 Description = car.Description,
                                 ModelYear = car.ModelYear
                             };
                return result.ToList();
            }
        }
    }
}
