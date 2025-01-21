using BrouwerService.Models;
using BrouwerService.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BrouwerService.Controllers;

[Route("brouwers")]
[ApiController]
public class BrouwerController(IBrouwerRepository repository) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult> FindAll() => base.Ok(await repository.FindAllAsync());

    [HttpGet("{id}")]
    public async Task<ActionResult> FindById(int id) => await repository.FindByIdAsync(id) is Brouwer brouwer ? base.Ok(brouwer) : base.NotFound();

    [HttpGet("naam")]
    public async Task<ActionResult> FindByBeginNaam(string begin) => base.Ok(await repository.FindByBeginNaamAsync(begin));

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var brouwer = await repository.FindByIdAsync(id);
        if (brouwer == null)
        {
            return base.NotFound();
        }
        await repository.DeleteAsync(brouwer);
        return base.Ok();
    }

    [HttpPost]
    public async Task<ActionResult> Post(Brouwer brouwer)
    {
        await repository.InsertAsync(brouwer);
        return base.CreatedAtAction(nameof(FindById), new { id = brouwer.Id }, null);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Put(int id, Brouwer brouwer)
    {
        try
        {
            brouwer.Id = id;
            await repository.UpdateAsync(brouwer);
            return base.Ok();
        }
        catch (DbUpdateConcurrencyException)
        {
            return base.NotFound();
        }
        catch
        {
            return base.Problem();
        }
    }

}
