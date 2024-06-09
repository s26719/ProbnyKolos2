namespace przykladowykolos.Models;

public class Utwor
{
    public int IdUtwor { get; set; }
    public string NazwaUtworu { get; set; }
    public float CzasTrwania { get; set; }
    public int? IdAlbum { get; set; }
    public virtual ICollection<WykonawcaUtworu> WykonawcaUtworu { get; set; }
    public virtual Album IdAlbumNavigation { get; set; }
}