using System.Security.Principal;

namespace przykladowykolos.Models;

public class Album
{
    public int IdAlbum { get; set; }
    public string NazwaAlbumu { get; set; }
    public DateTime DataWydania { get; set; }
    public int IdWytwornia { get; set; }
    public virtual Wytwornia idWytworniaNagivation { get; set; }
    public virtual ICollection<Utwor> Utwors { get; set; }
}