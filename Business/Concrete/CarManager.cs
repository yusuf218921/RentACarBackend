using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.DTOs;
using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        [ValidationAspect(typeof(ValidationTool))]
        public IResult AddCar(Car car)
        {

            ValidationTool.Validate(new CarValidator(), car);

            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
        }

        public IResult DeleteCar(Car car)
        {
            // iş kodları
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }

        public IDataResult<List<Car>> GetAllCars()
        {
            // iş kodları
            return new SuccessDataResult<List<Car>>(Messages.CarsListed, _carDal.GetAll());
        }

        public IDataResult<Car> GetCarById(int id)
        {
            // iş kodları
            var result = new SuccessDataResult<Car>(Messages.CarsListed, _carDal.Get(c => c.CarID == id));
            return result;
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
