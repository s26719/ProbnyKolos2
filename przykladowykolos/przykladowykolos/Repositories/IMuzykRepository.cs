using przykladowykolos.DTO_s;

namespace przykladowykolos.Repositories;

public interface IMuzykRepository
{
    Task<MuzykOutDto> GetMuzykDetailsAsync(int id);
    Task AddNewMuzykAsync(MuzykInDto muzykInDto);
}