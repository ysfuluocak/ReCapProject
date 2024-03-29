﻿using Core.DataAccess.EntityFramework;
using Core.Utilities.Results;
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
    public class EfRentalDal : EfEntityRepositoryBase<Rental, CarContext>, IRentalDal
    {
        public List<RentalDetailsDto> GetRentalDetailsDto()
        {
            using (var context = new CarContext())
            {
                var result = from rental in context.Rentals
                             join car in context.Cars
                             on rental.CarId equals car.CarId
                             join customer in context.Customers
                             on rental.CustomerId equals customer.CustomerId
                             join user in context.Users 
                             on customer.UserId equals user.UserId
                             select new RentalDetailsDto { RentalId = rental.RentalId, CarName = car.CarName, CompanyName = customer.CompanyName, RentDate = rental.RentDate, ReturnDate = rental.ReturnDate };
                return result.ToList();
            }
        }
    }
}
