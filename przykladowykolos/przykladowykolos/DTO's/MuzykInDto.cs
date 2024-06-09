using System.ComponentModel.DataAnnotations;

namespace przykladowykolos.DTO_s;

public class MuzykInDto
{
    [Required][MaxLength(30)]
    public string imie { get; set; }
    [Required][MaxLength(40)]
    public string Nazwisko { get; set; }
    [MaxLength(50)]
    public string? Pseudonim { get; set; }

    public UtworInDto? Utwor { get; set; }
}