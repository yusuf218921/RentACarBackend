using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entity.Concrete;

ICarService carService = new CarManager(new EfCarDal());

var result = carService.GetCarsDetail().Data;
foreach (var item in result)
{
    Console.WriteLine(item.CarName + " / " + item.BrandName + " / " + item.ColorName);
}



