
using Microsoft.EntityFrameworkCore;
using MinimalBrouwerService.Models;

namespace MinimalBrouwerService.Repositories;

public class BierlandContext(DbContextOptions<BierlandContext> options) : DbContext(options)
{
    public required DbSet<Brouwer> Brouwers { get; init; }

}
