using Business.Abstract;
using Business.Constants;
using Business.Rules;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Add(Rental rental,Car car)
        {
            if (RentalRules.IsRentable(car))
            {
                _rentalDal.Add(rental);
                return new SuccessResult(Messages.RentalCar);
            }
            else
                return new ErrorResult(Messages.NotReturnCar);
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

        public IDataResult<List<Rental>> GetNotReturnCars(Rental rental)
        {
            // iş kodları
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(r => r.ReturnDate == null));
        }

        public IDataResult<List<Rental>> GetOnlyReturnCars()
        {
            // iş kodları
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(r => r.ReturnDate != null));
        }

        public IResult Update(Rental rental)
        {
            // iş kodları
            _rentalDal.Update(rental);
            return new SuccessResult();
        }
    }
}
