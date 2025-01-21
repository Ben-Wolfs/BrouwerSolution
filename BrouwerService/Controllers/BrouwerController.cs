using BrouwerService.Models;
using BrouwerService.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BrouwerService.Controllers;

[Route("brouwers")]
[ApiController]
public class BrouwerController(IBrouwerRepository repository) : ControllerBase
{
    [HttpGet]
    public ActionResult FindAll() => base.Ok(repository.FindAll());

    [HttpGet("{id}")]
    public ActionResult FindById(int id) => repository.FindById(id) is Brouwer brouwer ? base.Ok(brouwer) : base.NotFound();

    [HttpGet("naam")]
    public ActionResult FindByBeginNaam(string begin) => base.Ok(repository.FindByBeginNaam(begin));
}
