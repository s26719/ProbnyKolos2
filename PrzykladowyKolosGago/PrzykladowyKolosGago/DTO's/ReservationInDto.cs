﻿namespace PrzykladowyKolosGago.DTO_s;

public class ReservationInDto
{
    public int IdClient { get; set; }
    public DateTime DateFrom { get; set; }
    public DateTime DateTo { get; set; }
    public int IdBoatStandard { get; set; }
    public int NumOfBoats { get; set; }
}