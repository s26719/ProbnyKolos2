using PrzykladowyKolosGago.DTO_s;

namespace PrzykladowyKolosGago.Repositories;

public interface IReservationRepository
{
    Task AddReservationAsync(ReservationInDto reservationInDto);
}