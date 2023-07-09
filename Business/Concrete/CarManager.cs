using Business.Abstract;
using Business.Constants;
using Core.DataAccess;
using Core.Utilities.Abstract;
using Core.Utilities.Concrete;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }
        public IResult AddCar(Car car)
        {
            if (car.CarName.Length < 2)
                return new ErrorResult(Messages.CarNameInvalid);
            else if(car.DailyPrice <= 0)
                return new ErrorResult(Messages.CarDailyPriceInvalid);
            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
        }

        public IResult DeleteCar(Car car)
        {
            // iş kodları
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }

        public IDataResult<Car> GetCarById(int id)
        {
            // iş kodları
            return new SuccessDataResult<Car>(Messages.CarsListed, _carDal.Get(c=> c.CarID == id));
        }

        public IDataResult<List<Car>> GetCarsByBrands(int brandId)
        {
            // iş kodları 
            return new SuccessDataResult<List<Car>>(Messages.CarsListed, _carDal.GetAll(c=> c.BrandID == brandId));
        }

        public IDataResult<List<Car>> GetCarsByColor(int colorId)
        {
            // iş kodları
            return new SuccessDataResult<List<Car>>(Messages.CarsListed, _carDal.GetAll(c => c.ColorID == colorId));
        }

        public IDataResult<List<Car>> GetCarsByDailyPrice(int min, int max)
        {
            // iş kodları
            return new SuccessDataResult<List<Car>>(Messages.CarsListed, _carDal.GetAll(c => c.DailyPrice >= min && c.DailyPrice <= max));
        }

        public IDataResult<List<Car>> GetCarsByModelYear(string modelYear)
        {
            // iş kodları
            return new SuccessDataResult<List<Car>>(Messages.CarsListed, _carDal.GetAll(c => c.ModelYear == modelYear));
        }

        public IDataResult<List<CarDetailDto>> GetCarsDetail()
        {
            // iş kodları
            return new SuccessDataResult<List<CarDetailDto>>(Messages.CarsListed, _carDal.GetCarsDetail());
        }

        public IResult UpdateCar(Car car)
        {
            // iş kodları
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }
    }
}
