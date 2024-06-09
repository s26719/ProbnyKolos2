using Microsoft.AspNetCore.Mvc;
using PrzykladowyKolosGago.DTO_s;
using PrzykladowyKolosGago.Exceptions;
using PrzykladowyKolosGago.Services;

namespace PrzykladowyKolosGago.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ClientController : ControllerBase
{
    private readonly IClientService _clientService;

    public ClientController(IClientService clientService)
    {
        _clientService = clientService;
    }

    [HttpGet]
    public async Task<IActionResult>GetClientReservarionsAsync(int id)
    {
        try
        {
            var clientReservations = await _clientService.GetClientReservationsAsync(id);
            return Ok(clientReservations);
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
    }
}