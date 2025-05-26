using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebApi.Data.Contexts;
using WebApi.Data.Entities;
using WebApi.Models;

namespace WebApi.Data.Repositories;

public class BookingRepository(DataContext context) : BaseRepository<BookingEntity>(context), IBookingRepository
{
    public override async Task<RepositoryResult<BookingEntity>> GetAsync(Expression<Func<BookingEntity, bool>> expression)
    {
        var entity = await _context.Bookings
            .Include(c => c.Customer)
            .ThenInclude(a => a.Address)
            .FirstOrDefaultAsync(expression);

        return new RepositoryResult<BookingEntity> { Success = true, Result = entity };
    }
}
