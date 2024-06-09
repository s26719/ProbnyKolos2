namespace przykladowykolos.Models;

public class Muzyk
{
    public int IdMuzyk { get; set; }
    public string Imie { get; set; }
    public string Nazwisko { get; set; }
    public string Pseudonim { get; set; }
    public virtual ICollection<WykonawcaUtworu> WykonawcaUtworu { get; set; }
}