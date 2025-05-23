using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Data.Entities;

public class BookingCustomerEntity
{
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;

    [ForeignKey(nameof(Address))]
    public int CustomerAddressId { get; set; }
    public CustomerAddressEntity Address { get; set; } = null!;
}
