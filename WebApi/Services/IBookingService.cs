using WebApi.Models;

namespace WebApi.Services
{
    public interface IBookingService
    {
        Task<BookingResult> CreateAsync(CreateBookingModel model);
    }
}