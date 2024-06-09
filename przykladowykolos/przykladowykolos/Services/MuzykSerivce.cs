using przykladowykolos.DTO_s;
using przykladowykolos.Repositories;

namespace przykladowykolos.Services;

public class MuzykSerivce : IMuzykSerivce
{
    private readonly IMuzykRepository _muzykRepository;

    public MuzykSerivce(IMuzykRepository muzykRepository)
    {
        _muzykRepository = muzykRepository;
    }

    public async Task<MuzykOutDto> GetMuzykDetailsAsync(int id)
    {
        return await _muzykRepository.GetMuzykDetailsAsync(id);
    }

    public async Task AddNewMuzykAsync(MuzykInDto muzykInDto)
    {
        await _muzykRepository.AddNewMuzykAsync(muzykInDto);
    }
}