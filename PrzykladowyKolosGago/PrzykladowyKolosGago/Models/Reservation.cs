namespace PrzykladowyKolosGago.Models;

public class Reservation
{
    public int IdReservation { get; set; }
    public int IdClient { get; set; }
    public DateTime DateFrom { get; set; }
    public DateTime DateTo { get; set; }
    public int IdBoatStandrd { get; set; }
    public int Capacity { get; set; }
    public int NumOfBoats { get; set; }
    public bool Fulfilled { get; set; }
    public float? Price { get; set; }
    public string? CancelReason { get; set; }

    // zmienielem na kolekcje sailboats 
    public virtual ICollection<Sailboat_Reservation> SailboatReservations{ get; set; }
    public virtual Client IdClientNavigation { get; set; }
    public BoatStandard IdBoatStandardNavigation { get; set; }
}
    