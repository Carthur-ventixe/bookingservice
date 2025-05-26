using WebApi.Data.Repositories;
using WebApi.Factories;
using WebApi.Models;

namespace WebApi.Services;

public class BookingService(IBookingRepository repository) : IBookingService
{
    private readonly IBookingRepository _repository = repository;

    public async Task<BookingResult> CreateAsync(CreateBookingModel model)
    {
        var entity = BookingFactory.CreateEntity(model);

        var result = await _repository.CreateAsync(entity);
        if (!result.Success)
            return new BookingResult { Success = false, Error = "Error creating booking" };

        return new BookingResult { Success = true };
    }
}
