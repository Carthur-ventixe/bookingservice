using WebApi.Data.Entities;
using WebApi.Models;

namespace WebApi.Factories;

public static class BookingFactory
{
    public static BookingEntity CreateBookingEntity(CreateBookingModel model)
    {
        return new BookingEntity
        {
            EventId = model.EventId,
            PackageId = model.PackageId,
            TicketQuantity = model.TicketQuantity,
            TotalPrice = model.TotalPrice,
            BookingDate = DateTime.Now,
        };

    }
    public static BookingCustomerEntity CreateCustomerEntity(CreateBookingModel model)
    {
        return new BookingCustomerEntity
        {
            FirstName = model.FirstName,
            LastName = model.LastName,
            Email = model.Email,
            Address = new CustomerAddressEntity
            {
                Street = model.Street,
                PostalCode = model.PostalCode,
                City = model.City,
            }
        };
    }
}
