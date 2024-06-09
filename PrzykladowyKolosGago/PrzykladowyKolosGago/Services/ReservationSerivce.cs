using PrzykladowyKolosGago.DTO_s;
using PrzykladowyKolosGago.Repositories;

namespace PrzykladowyKolosGago.Services;

public class ReservationSerivce : IReservationSerivce
{
    private readonly IReservationRepository _reservationRepository;

    public ReservationSerivce(IReservationRepository reservationRepository)
    {
        _reservationRepository = reservationRepository;
    }

    public async Task AddReservationAsync(ReservationInDto reservationInDto)
    {
        await _reservationRepository.AddReservationAsync(reservationInDto);
    }
}