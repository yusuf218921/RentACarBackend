using Business.Abstract;
using Business.Constants;
using Core.Utilities.Abstract;
using Core.Utilities.Concrete;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            if (car.IsRentable)
            {
                _rentalDal.Add(rental);
                return new SuccessResult(Messages.RentalCar);
            }
            else
                return new ErrorResult(Messages.NotReturnCar);
        }

        public IResult Delete(Rental rental)
        {
            throw new NotImplementedException();
        }

        public IDataResult<Rental> Get(int id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Rental>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Rental>> GetNotReturnCars(Rental rental)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Rental>> GetOnlyReturnCars()
        {
            throw new NotImplementedException();
        }

        public IResult Update(Rental rental)
        {
            // iş kodları
            _rentalDal.Update(rental);
            return new SuccessResult();
        }
    }
}
