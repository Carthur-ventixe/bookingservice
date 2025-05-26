using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models;

public class CreateBookingModel
{
    public int EventId { get; set; }

    [Required]
    public int TicketQuantity { get; set; }

    [Required]
    public decimal TotalPrice { get; set; }
    public DateTime? BookingDate { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Street { get; set; } = null!;
    public string PostalCode { get; set; } = null!;
    public string City { get; set; } = null!;
}
