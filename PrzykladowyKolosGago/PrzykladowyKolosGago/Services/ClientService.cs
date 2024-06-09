using PrzykladowyKolosGago.DTO_s;
using PrzykladowyKolosGago.Repositories;

namespace PrzykladowyKolosGago.Services;

public class ClientService : IClientService
{
    private readonly IClientRepository _clientRepository;

    public ClientService(IClientRepository clientRepository)
    {
        _clientRepository = clientRepository;
    }

    public async Task<ClientReservationDto> GetClientReservationsAsync(int id)
    {
        return await _clientRepository.GetClientReservationsAsync(id);
    }
}