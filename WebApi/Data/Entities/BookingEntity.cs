using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Data.Entities;

public class BookingEntity
{
    [Key]
    public int Id { get; set; }
    public int EventId { get; set; }
    public int TicketQuantity { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal TotalPrice { get; set; }

    [Column(TypeName = "datetime2")]
    public DateTime BookingDate { get; set; }

    [ForeignKey(nameof(Customer))]
    public int BookingCustomerId { get; set; }
    public BookingCustomerEntity Customer { get; set; } = null!;
}
