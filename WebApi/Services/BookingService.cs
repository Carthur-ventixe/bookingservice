using Azure.Messaging.ServiceBus;
using System.Text.Json;
using WebApi.Data.Entities;
using WebApi.Data.Repositories;
using WebApi.Factories;
using WebApi.Models;

namespace WebApi.Services;

public class BookingService(IBookingRepository repository, EventContract.EventContractClient eventContractClient, IConfiguration configuration) : IBookingService
{
    private readonly IBookingRepository _repository = repository;
    private readonly EventContract.EventContractClient _eventContractClient = eventContractClient;
    private readonly string _connectionString = configuration["ASB:ConnectionString"]!;

    public async Task<BookingResult> CreateAsync(CreateBookingModel model)
    {
        var entity = await _repository.GetAsync(x => x.Customer.Email == model.Email);

        var newBooking = BookingFactory.CreateBookingEntity(model);

        if (entity.Result == null)
        {
            newBooking.Customer = BookingFactory.CreateCustomerEntity(model);
        }
        else
        {
            newBooking.BookingCustomerId = entity.Result.BookingCustomerId;
        }

        var result = await _repository.CreateAsync(newBooking);
        if (!result.Success)
            return new BookingResult { Success = false, Error = "Error creating booking" };

        var eventInfo = await _eventContractClient.GetEventWithPackageByIdAsync(new EventByIdRequest { EventId = model.EventId, PackageId = model.PackageId});
   
        var queueName = "email-service";

        var client = new ServiceBusClient(_connectionString);
        var sender = client.CreateSender(queueName);

        var message = new BookingMessage
        {
            EventName = eventInfo.EventName,
            PackageName = eventInfo.PackageName,
            EventDate = eventInfo.EventDate.ToDateTime(),
            Location = eventInfo.Location,
            TicketQuantity = model.TicketQuantity,
            TotalPrice = model.TotalPrice,
            BookingDate = model.BookingDate,
            FirstName = model.FirstName,
            LastName = model.LastName,
            Email = model.Email,
            Street = model.Street,
            City = model.City,
            PostalCode = model.PostalCode,
        };

        var messageJson = JsonSerializer.Serialize(message);

        await sender.SendMessageAsync(new ServiceBusMessage(messageJson));

        return new BookingResult { Success = true };
    }
}
