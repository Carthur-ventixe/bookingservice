using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.Services;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BookingsController(IBookingService bookingsService) : ControllerBase
{
    private readonly IBookingService _bookingsService = bookingsService;

    [HttpPost]
    public async Task<IActionResult> CreateBooking(CreateBookingModel model)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var result = await _bookingsService.CreateAsync(model);
        if (!result.Success)
            return StatusCode(500, result.Error);

        return Ok(result);
    }
}
