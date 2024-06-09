using System.ComponentModel.DataAnnotations;

namespace przykladowykolos.DTO_s;

public class UtworInDto
{
    [Required][MaxLength(30)]
    public string NazwaUtworu { get; set; }
    [Required]
    public float CzasTrwania { get; set; }

    public int IdAlbum { get; set; }
}