using Microsoft.AspNetCore.Mvc;
using przykladowykolos.DTO_s;
using przykladowykolos.Exception;
using przykladowykolos.Services;

namespace przykladowykolos.Controllers;
[Route("api/[controller]")]
[ApiController]
public class MuzykController : ControllerBase
{
    private readonly IMuzykSerivce _muzykSerivce;

    public MuzykController(IMuzykSerivce muzykSerivce)
    {
        _muzykSerivce = muzykSerivce;
    }

    [HttpGet]
    public async Task<IActionResult> GetMuzykDetailsAsync(int id)
    {
        try
        {
            return Ok(await _muzykSerivce.GetMuzykDetailsAsync(id));
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> AddMuzykAsync(MuzykInDto muzykInDto)
    {
        try
        {
            await _muzykSerivce.AddNewMuzykAsync(muzykInDto);
            return Ok();
        }
        catch (BadRequestException e)
        {
            return BadRequest(e.Message);
        }
    }
}