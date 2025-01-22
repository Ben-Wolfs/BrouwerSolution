using BrouwerService.Models;
using Microsoft.EntityFrameworkCore;

namespace BrouwerService.Repositories;

public class FiliaalRepository(BierlandContext context) : IFiliaalRepository
{
    public async Task<List<Filiaal>> FindAllAsync() => await context.Filialen.Include(filiaal => filiaal.Woonplaats).AsNoTracking().ToListAsync();
}
