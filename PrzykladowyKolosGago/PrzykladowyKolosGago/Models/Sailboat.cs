namespace PrzykladowyKolosGago.Models;

public class Sailboat
{
    public int IdSailboat { get; set; }
    public string Name { get; set; }
    public int Capacity { get; set; }
    public string Description { get; set; }
    public float Price { get; set; }
    public int IdBoatStandard { get; set; }

    // zmienilem na kolekcje rezerwacji a nie sailboaT_reservation
    public virtual ICollection<Sailboat_Reservation> SailboatReservations { get; set; }
    public virtual BoatStandard IdBoatStandardNavigation { get; set; }
}