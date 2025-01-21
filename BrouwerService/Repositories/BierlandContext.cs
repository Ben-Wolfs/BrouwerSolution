using BrouwerService.Models;
using Microsoft.EntityFrameworkCore;

namespace BrouwerService.Repositories;

public class BierlandContext(DbContextOptions<BierlandContext> options) : DbContext(options)
{
    public required DbSet<Brouwer> Brouwers { get; init; }
}
