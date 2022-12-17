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
        public List<CarColorBrandImageDto> GetCarColorBrandImageDto()
        {
            using (var context = new CarContext())
            {
                var result = from car in context.Cars
                             join color in context.Colors
                             on car.ColorId equals color.ColorId
                             join brand in context.Brands
                             on car.BrandId equals brand.BrandId
                             join image in context.CarImages
                             on car.CarId equals image.CarId
                             select new CarColorBrandImageDto { CarId = car.CarId, CarName = car.CarName, BrandName = brand.BrandName, ColorName = color.ColorName, DailyPrice = car.DailyPrice, ImagePath = image.ImagePath, ModelYear = car.ModelYear };
                return result.ToList();
            }
        }
    }
}
