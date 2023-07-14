using Entity.Concrete;
using Entity.DTOs;
using Core.Utilities.Results;

namespace Business.Abstract
{
    public interface ICarService
    {
        IResult AddCar(Car car);
        IResult DeleteCar(Car car);
        IResult UpdateCar(Car car);
        IDataResult<Car> GetCarById(int id);
        IDataResult<List<Car>> GetCarsByBrands(int brandId);
        IDataResult<List<Car>> GetCarsByDailyPrice(int min, int max);
        IDataResult<List<Car>> GetCarsByColor(int colorId);
        IDataResult<List<Car>> GetCarsByModelYear(string modelYear);
        IDataResult<List<CarDetailDto>> GetCarsDetail();
        IDataResult<List<Car>> GetAllCars();

    }
}
