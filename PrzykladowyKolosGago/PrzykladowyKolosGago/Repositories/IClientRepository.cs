using PrzykladowyKolosGago.DTO_s;

namespace PrzykladowyKolosGago.Repositories;

public interface IClientRepository
{
    Task<ClientReservationDto> GetClientReservationsAsync(int id);
}