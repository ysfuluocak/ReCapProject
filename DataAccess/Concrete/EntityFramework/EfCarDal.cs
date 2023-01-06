using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarContext>, ICarDal
    {
        public List<CarDetailsDto> GetCarDetailsDto()
        {
            using (var context = new CarContext())
            {
                var result = from car in context.Cars
                             join color in context.Colors
                             on car.ColorId equals color.ColorId
                             join brand in context.Brands
                             on car.BrandId equals brand.BrandId
                             select new CarDetailsDto { CarId = car.CarId, CarName = car.CarName, BrandName = brand.BrandName, ColorName = color.ColorName, DailyPrice = car.DailyPrice, ModelYear = car.ModelYear };
                return result.ToList();
            }
        }
    }
}
