namespace BrouwerService.Models;

public class Filiaal
{
    public int Id { get; init; }
    public required string Naam { get; init; }
    public int HuurPrijs { get; init; }
    public int WoonPlaatsId { get; init; }
    public required Woonplaats Woonplaats { get; init; }
}
