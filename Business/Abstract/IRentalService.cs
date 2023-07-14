using Core.Utilities.Results;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IResult Add(Rental rental, Car car);
        IResult Delete(Rental rental);
        IResult Update(Rental rental);
        IDataResult<Rental> Get(int id);
        IDataResult<List<Rental>> GetAll();
        IDataResult<List<Rental>> GetNotReturnCars(Rental rental);
        IDataResult<List<Rental>> GetOnlyReturnCars();

    }
}
