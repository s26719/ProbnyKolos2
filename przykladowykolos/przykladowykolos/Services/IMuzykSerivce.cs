using przykladowykolos.DTO_s;

namespace przykladowykolos.Services;

public interface IMuzykSerivce
{
    Task<MuzykOutDto> GetMuzykDetailsAsync(int id);
    Task AddNewMuzykAsync(MuzykInDto muzykInDto);
}