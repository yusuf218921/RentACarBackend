﻿using Entity.Concrete;
using Core.Utilities.Abstract;
using Core.Utilities.Concrete;

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
    }
}
