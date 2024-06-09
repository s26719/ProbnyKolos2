using System.ComponentModel.DataAnnotations;

namespace przykladowykolos.DTO_s;

public class MuzykDto
{
    [Required][MaxLength(30)]
    public string imie { get; set; }
    [Required][MaxLength(40)]
    public string Nazwisko { get; set; }
    [MaxLength(50)]
    public string? Pseudonim { get; set; }
}