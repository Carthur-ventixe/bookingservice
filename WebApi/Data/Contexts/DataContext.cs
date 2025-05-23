using Microsoft.EntityFrameworkCore;
using WebApi.Data.Entities;

namespace WebApi.Data.Contexts;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public DbSet<BookingEntity> Bookings { get; set; }
    public DbSet<BookingCustomerEntity> BookingCustomers { get; set; }
    public DbSet<CustomerAddressEntity> CustomerAddresses { get; set; }
}
