namespace przykladowykolos.DTO_s;

public class MuzykOutDto
{
    public int IdMuzyk { get; set; }
    public string Imie { get; set; }
    public string Nazwisko { get; set; }
    public string Pseudonim { get; set; }
    public List<UtworOutDto> UtworOutDtos { get; set; }
}