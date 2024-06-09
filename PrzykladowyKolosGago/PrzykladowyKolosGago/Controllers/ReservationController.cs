using Microsoft.AspNetCore.Mvc;
using PrzykladowyKolosGago.DTO_s;
using PrzykladowyKolosGago.Exceptions;
using PrzykladowyKolosGago.Services;

namespace PrzykladowyKolosGago.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ReservationController : ControllerBase
{
    private readonly IReservationSerivce _reservationSerivce;

    public ReservationController(IReservationSerivce reservationSerivce)
    {
        _reservationSerivce = reservationSerivce;
    }

    [HttpPost]
    public async Task<IActionResult> AddReservationAsync(ReservationInDto reservationInDto)
    {
        try
        {
            await _reservationSerivce.AddReservationAsync(reservationInDto);
            return Ok();
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
        catch (InvalidOperationException e)
        {
            return BadRequest(e.Message);
        }
    }
}