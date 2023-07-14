using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entity.Concrete;

ICarService carService = new CarManager(new EfCarDal());
Console.WriteLine(carService.GetCarById(1).Success);








