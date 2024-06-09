using Microsoft.EntityFrameworkCore;
using PrzykladowyKolosGago.Context;
using PrzykladowyKolosGago.DTO_s;
using PrzykladowyKolosGago.Exceptions;

namespace PrzykladowyKolosGago.Repositories;

public class ClientRepository : IClientRepository
{
    private readonly MyDbContext _myDbContext;

    public ClientRepository(MyDbContext myDbContext)
    {
        _myDbContext = myDbContext;
    }

    public async Task<ClientReservationDto> GetClientReservationsAsync(int id)
    {
        // Pobieramy dane klienta oraz jego rezerwacje w jednym zapytaniu
        var clientDto = await _myDbContext.Clients
            .Where(c => c.IdClient == id)
            .Select(c => new ClientReservationDto
            {
                IdClient = c.IdClient,
                Name = c.Name,
                LastName = c.LastName,
                Birthday = c.Birthday,
                Pesel = c.Pesel,
                Email = c.Email,
                ReservationOutDto = c.Reservations.Select(r => new ReservationOutDto
                {
                    IdReservation = r.IdReservation,
                    DateFrom = r.DateFrom,
                    DateTo = r.DateTo,
                    IdBoatStandrd = r.IdBoatStandrd,
                    Capacity = r.Capacity,
                    NumOfBoats = r.NumOfBoats,
                    Fulfilled = r.Fulfilled,
                    Price = r.Price,
                    CancelReason = r.CancelReason
                }).OrderByDescending(r => r.DateTo).ToList()
            })
            .FirstOrDefaultAsync();

        if (clientDto == null)
        {
            throw new NotFoundException("klient o podanym id nie istnieje");
        }

        return clientDto;
    }

}