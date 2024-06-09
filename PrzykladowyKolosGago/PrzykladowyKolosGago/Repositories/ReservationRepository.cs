using Microsoft.EntityFrameworkCore;
using PrzykladowyKolosGago.Context;
using PrzykladowyKolosGago.DTO_s;
using PrzykladowyKolosGago.Exceptions;
using PrzykladowyKolosGago.Models;

namespace PrzykladowyKolosGago.Repositories;

public class ReservationRepository : IReservationRepository
{
    private readonly MyDbContext _myDbContext;

    public ReservationRepository(MyDbContext myDbContext)
    {
        _myDbContext = myDbContext;
    }

    public async Task AddReservationAsync(ReservationInDto reservationInDto)
    {
        //sprawdzamy czy klient o podanym id instenije
        var client = await _myDbContext.Clients.FirstOrDefaultAsync();
        if (client ==null)
        {
            throw new NotFoundException("klient o podanym id nie istnieje");
        }
        //sprawdzamy czy klient nie ma innej aktywnej rezerwacji
        var reservationExist = await _myDbContext.Reservations
            .Where(r => r.IdClient == reservationInDto.IdClient && r.Fulfilled == false && r.CancelReason == null).FirstOrDefaultAsync();
        if (reservationExist != null)
        {
            throw new BadRequestException("klient ma aktywna rezerwacje");
        }
        //sprawdzamy czy mamy odpowiednia liczbe żaglówek
        var sailboatsCount = await _myDbContext.Sailboats.Where(s=>s.IdBoatStandard == reservationInDto.IdBoatStandard).CountAsync();
        if (reservationInDto.NumOfBoats > sailboatsCount)
        {
            var sailboatsHigherStandardCount = await _myDbContext.Sailboats
                .Where(s => s.IdBoatStandard > reservationInDto.IdBoatStandard).CountAsync();
            if (sailboatsHigherStandardCount < reservationInDto.NumOfBoats)
            {
                var reservation = new Reservation
                {
                    IdClient = reservationInDto.IdClient,
                    DateFrom = reservationInDto.DateFrom,
                    DateTo = reservationInDto.DateTo,
                    IdBoatStandrd = reservationInDto.IdBoatStandard,
                    NumOfBoats = reservationInDto.NumOfBoats,
                    CancelReason = "Brak łódek"
                };
                _myDbContext.Reservations.Add(reservation);
                await _myDbContext.SaveChangesAsync();
                throw new InvalidCastException("Brak łódek o podanym standardzie");
            }
        }
        
        //obliczamy cene
        var clientDiscount = client.IdClientCategoryNavigation != null
            ? client.IdClientCategoryNavigation.DiscountPerc
            : 0;
        var pricePerBoat = await _myDbContext.Sailboats.Where(s => s.IdBoatStandard == reservationInDto.IdBoatStandard)
            .Select(s => s.Price).FirstOrDefaultAsync();
        var price = (reservationInDto.NumOfBoats * pricePerBoat) * (1 - clientDiscount / 100);
        var newReservation = new Reservation
        {
            IdClient = reservationInDto.IdClient,
            DateFrom = reservationInDto.DateFrom,
            DateTo = reservationInDto.DateTo,
            IdBoatStandrd = reservationInDto.IdBoatStandard,
            NumOfBoats = reservationInDto.NumOfBoats,
            Price = price
        };
        _myDbContext.Reservations.Add(newReservation);
        await _myDbContext.SaveChangesAsync();
    }
}