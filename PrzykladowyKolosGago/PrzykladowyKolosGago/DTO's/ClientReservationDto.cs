namespace PrzykladowyKolosGago.DTO_s;

public class ClientReservationDto
{
    public int IdClient { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public DateTime Birthday { get; set; }
    public string Pesel { get; set; }
    public string Email { get; set; }

    public List<ReservationOutDto> ReservationOutDto { get; set; }
}