using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entity.Concrete;

IRentalService rentalService = new RentalManager(new EfRentalDal());
IUserService userService = new UserManager(new EfUserDal());
ICustomerService customerService = new CustomerManager(new EfCustomerDal());

//userService.Add(new User { FirstName = "yusuf", LastName = "sönmez", Email = "yusuf@gmail.com", Password = "218921aa" });
//customerService.Add(new Customer { UserID = 1, CompanyName = "ovam" });
rentalService.Add(new Rental { CarID = 1, CustomerID = 1, RentDate = DateTime.Now.ToString(), ReturnDate = null }, new Car() { IsRentable=true });
// To Do -> Rental için bir tane dto yaz





