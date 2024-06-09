using PrzykladowyKolosGago.DTO_s;

namespace PrzykladowyKolosGago.Services;

public interface IReservationSerivce
{
    Task AddReservationAsync(ReservationInDto reservationInDto);
}