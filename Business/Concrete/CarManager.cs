using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
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
        IBrandService _brandService;
        public CarManager(ICarDal carDal, IBrandService brandService)
        {
            _carDal = carDal;
            _brandService = brandService;

        }

        [SecuredOperation("product.add,admin")]
        [ValidationAspect(typeof(CarValidator))]
        public IResult AddCar(Car car)
        {
            var result = BusinessRules.Run(CheckCarNameExists(car.CarName),
                CheckIfCarCountOfBrandCorrect(car.BrandID),
                CheckBrandCount());

            if (result != null)
                return result;

            _carDal.Add(car);
            return new SuccessResult();
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
        
        [ValidationAspect(typeof(CarValidator))]
        public IResult UpdateCar(Car car)
        {
            var result = BusinessRules.Run(CheckCarNameExists(car.CarName),
                CheckIfCarCountOfBrandCorrect(car.BrandID));

            if (result != null)
                return result;

            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }

        private IResult CheckIfCarCountOfBrandCorrect(int brandId)
        {
            if (_carDal.GetAll(c => c.BrandID == brandId).Count > 10)
            {
                return new ErrorResult(Messages.CarCountOfBrandError);
            }
            return new SuccessResult();
        }
        private IResult CheckCarNameExists(string carName)
        {
            if(!_carDal.GetAll(c=> c.CarName == carName).Any())
            {
                return new SuccessResult();
            }
            return new ErrorResult(Messages.CarNameError);
        }
        private IResult CheckBrandCount()
        {
            if (_brandService.GetAll().Data.Count > 15)
                return new ErrorResult(Messages.BrandCountError);
            return new SuccessResult();
        }
    }
}
