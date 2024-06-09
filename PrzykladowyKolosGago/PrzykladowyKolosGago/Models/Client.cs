﻿namespace PrzykladowyKolosGago.Models;

public class Client
{
    public int IdClient { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public DateTime Birthday { get; set; }
    public string Pesel { get; set; }
    public string Email { get; set; }
    public int IdClientCategory { get; set; }
    public virtual ClientCategory IdClientCategoryNavigation { get; set; }
    public virtual ICollection<Reservation> Reservations { get; set; }
}