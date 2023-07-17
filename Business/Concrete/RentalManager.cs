using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        ICarService _carService;

        public RentalManager(IRentalDal rentalDal, ICarService carService)
        {
            _rentalDal = rentalDal;
            _carService = carService;
        }

        [ValidationAspect(typeof(RentalValidator))]
        public IResult Add(Rental rental)
        {
            var result = BusinessRules.Run(CheckIsCarRentable(rental.CarID));
            if (result != null)
                return result;

            _rentalDal.Add(rental);
            return new SuccessResult(Messages.RentalCar);
        }

        public IResult Delete(Rental rental)
        {
            // iş kodları
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalDeleted);
        }

        public IDataResult<Rental> Get(int id)
        {
            // iş kodları
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.RentalID == id));
        }

        public IDataResult<List<Rental>> GetAll()
        {
            // iş kodları
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IDataResult<List<Rental>> GetNotReturnCars()
        {
            // iş kodları
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(r => r.ReturnDate == null));
        }

        public IDataResult<List<Rental>> GetOnlyReturnCars()
        {
            // iş kodları
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(r => r.ReturnDate != null));
        }

        [ValidationAspect(typeof(RentalValidator))]
        public IResult Update(Rental rental)
        {
            var result = BusinessRules.Run(CheckIsCarRentable(rental.CarID));
            if (result != null)
                return result;
            _rentalDal.Update(rental);
            return new SuccessResult();
        } 

        private IResult CheckIsCarRentable(int carId)
        {
            if (_carService.GetCarById(carId).Data.IsRentable)
                return new SuccessResult();
            return new ErrorResult(Messages.CarIsNotRentable);
        }
    }
}
