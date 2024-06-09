namespace przykladowykolos.Models;

public class WykonawcaUtworu
{
    public int IdMuzyk { get; set; }
    public virtual Muzyk IdMuzykNavigation { get; set; }
    public int IdUtwor { get; set; }
    public virtual Utwor IdUtworNavigation { get; set; }
}