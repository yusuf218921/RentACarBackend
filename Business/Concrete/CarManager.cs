using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
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


        [SecuredOperation("admin")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("IProductService.Get")]
        public IResult AddCar(Car car)
        {
            var result = BusinessRules.Run(
                CheckIfCarCountOfBrandCorrect(car.BrandID),
                CheckBrandCount());

            if (result != null)
                return result;

            _carDal.Add(car);
            return new SuccessResult();
        }
        [SecuredOperation("admin")]
        [CacheRemoveAspect("IProductService.Get")]
        public IResult DeleteCar(Car car)
        {
            // iş kodları
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }

        [CacheAspect]
        public IDataResult<List<Car>> GetAllCars()
        {
            // iş kodları
            return new SuccessDataResult<List<Car>>(Messages.CarsListed, _carDal.GetAll());
        }

        [CacheAspect]
        public IDataResult<Car> GetCarById(int id)
        {
            // iş kodları
            var result = new SuccessDataResult<Car>(Messages.CarsListed, _carDal.Get(c => c.CarID == id));
            return result;
        }
        
        [CacheAspect]
        public IDataResult<List<Car>> GetCarsByBrands(int brandId)
        {
            // iş kodları 
            return new SuccessDataResult<List<Car>>(Messages.CarsListed, _carDal.GetAll(c=> c.BrandID == brandId));
        }
        
        [CacheAspect]
        public IDataResult<List<Car>> GetCarsByColor(int colorId)
        {
            // iş kodları
            return new SuccessDataResult<List<Car>>(Messages.CarsListed, _carDal.GetAll(c => c.ColorID == colorId));
        }
        
        [CacheAspect]
        public IDataResult<List<Car>> GetCarsByDailyPrice(int min, int max)
        {
            // iş kodları
            return new SuccessDataResult<List<Car>>(Messages.CarsListed, _carDal.GetAll(c => c.DailyPrice >= min && c.DailyPrice <= max));
        }
        
        [CacheAspect]
        public IDataResult<List<Car>> GetCarsByModelYear(string modelYear)
        {
            // iş kodları
            return new SuccessDataResult<List<Car>>(Messages.CarsListed, _carDal.GetAll(c => c.ModelYear == modelYear));
        }
        
        [CacheAspect]
        public IDataResult<List<CarDetailDto>> GetCarsDetail()
        {
            // iş kodları
            return new SuccessDataResult<List<CarDetailDto>>(Messages.CarsListed, _carDal.GetCarsDetail());
        }
        
        [SecuredOperation("admin")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("IProductService.Get")]
        public IResult UpdateCar(Car car)
        {
            var result = BusinessRules.Run(
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
        
        private IResult CheckBrandCount()
        {
            if (_brandService.GetAll().Data.Count > 15)
                return new ErrorResult(Messages.BrandCountError);
            return new SuccessResult();
        }
    }
}
