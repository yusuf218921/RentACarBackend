using Core.DataAccess;
using Entity.Concrete;
using Entity.DTOs;


namespace DataAccess.Abstract
{
    public interface ICarDal : IEntityRepository<Car>
    {
        List<CarDetailDto> GetCarDetail();
    }
}
