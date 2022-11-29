using Business.Concrete;
using DataAccess.Concrete.EntityFramework;

RentalManager rentalManager = new RentalManager(new EfRentalDal());
Console.WriteLine(rentalManager.Add(new Entities.Concrete.Rental { CarId=2, CustomerId=2, RentDate=DateTime.Now }).Message);

foreach (var rental in rentalManager.GetAllRentals().Data)
{
    Console.WriteLine(rental.ReturnDate);
} 
