using BrouwerService.DTOs;
using BrouwerService.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BrouwerService.Controllers;

[Route("filialen"), ApiController]
public class FiliaalController(IFiliaalRepository repository) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult> FindAll()
    {
        var filialen = await repository.FindAllAsync();
        var filiaalDTOs = filialen.Select(filiaal => new FiliaalDTO(filiaal.Id, filiaal.Naam, filiaal.Woonplaats.Postcode, filiaal.Woonplaats.Naam));
        return base.Ok(filiaalDTOs);
    }
}
