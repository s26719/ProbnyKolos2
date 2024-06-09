namespace PrzykladowyKolosGago.Models;

public class Sailboat_Reservation
{
    public int IdSailboat { get; set; }
    public int IdReservation { get; set; }

    public virtual Reservation IdReservationNavigation { get; set; }
    public virtual Sailboat IdSailboatNavigation { get; set; }
}