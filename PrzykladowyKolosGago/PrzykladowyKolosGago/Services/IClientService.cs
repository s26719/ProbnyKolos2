using PrzykladowyKolosGago.DTO_s;

namespace PrzykladowyKolosGago.Services;

public interface IClientService
{
    Task<ClientReservationDto> GetClientReservationsAsync(int id);
}