namespace WebApi.Data.Entities;

public class CustomerAddressEntity
{
    public int Id { get; set; }
    public string Street { get; set; } = null!;
    public string PostalCode { get; set; } = null!;
    public string City { get; set; } = null!;
}
