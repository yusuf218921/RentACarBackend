using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entity.Concrete;

ICarService carService = new CarManager(new EfCarDal());

Car car = new Car() { CarID = 2,CarName = "X5", BrandID = 1, ColorID = 2, DailyPrice = 100, ModelYear = "2022", Description = "Çok iyi Araba"};
//carService.AddCar(car);
//Car car1 = new Car() { CarID = 1, CarName = "X2", BrandID = 1, ColorID = 3, DailyPrice = 200, ModelYear = "2021", Description = "Çok iyi Araba2" };
//carService.UpdateCar(car1);
carService.DeleteCar(car);
