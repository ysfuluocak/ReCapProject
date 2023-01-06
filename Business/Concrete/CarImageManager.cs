using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IResult = Core.Utilities.Results.IResult;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        public IResult Add(IFormFile file, CarImage carImage)
        {
            BusinessRules.Run(UploadImage(file,carImage));
            _carImageDal.Add(carImage);
            return new SuccessResult();
        }

        public IResult Delete(CarImage carImage)
        {
            BusinessRules.Run(DeleteImageFromFolder(carImage));
            _carImageDal.Delete(carImage);

            return new SuccessResult();
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<CarImage> GetById(int carImageId)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(c => c.CarImageId == carImageId));
        }

        public IResult Update(IFormFile file, CarImage carImage)
        {
            BusinessRules.Run(DeleteImageFromFolder(carImage), UploadImage(file, carImage));
            _carImageDal.Update(carImage);
            return new SuccessResult();
        }

        public IDataResult<List<CarImage>> GetImagesByCar(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId);
            if (result.Count > 0)
            {
                result.ForEach(c => c.ImagePath = "/images/" + c.ImagePath);
                return new SuccessDataResult<List<CarImage>>(result);
            }
            else
            {
                result.Add(new CarImage { CarId = carId, ImagePath = Path.Combine("/images", "DefaultLogo.jpg").Replace("\\","/") });
                return new SuccessDataResult<List<CarImage>>(result, Messages.ImageNotFound);
            }
        }


        private IResult UploadImage(IFormFile file, CarImage carImage)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carImage.CarImageId).Count;
            if (result < 5)
            {
                var fileName = file.FileName;
                var guidFileName = Guid.NewGuid().ToString()+ "_" + fileName;
                var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot","images", guidFileName);
                file.CopyTo(new FileStream(imagePath, FileMode.Create));
                carImage.ImagePath = guidFileName;
                carImage.AddDate = DateTime.Now;
                return new SuccessResult();
            }
            return new ErrorResult();


        }

        private IResult DeleteImageFromFolder(CarImage carImage)
        {
            var deletedImage = _carImageDal.Get(c => c.CarImageId == carImage.CarImageId);
            var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot","images", deletedImage.ImagePath);
            File.Delete(imagePath);
            return new SuccessResult();
        }


    }
}