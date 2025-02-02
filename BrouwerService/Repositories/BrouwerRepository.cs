﻿using BrouwerService.Models;
using Microsoft.EntityFrameworkCore;

namespace BrouwerService.Repositories;

public class BrouwerRepository(BierlandContext context) : IBrouwerRepository
{


    public async Task<List<Brouwer>> FindAllAsync() => await context.Brouwers.AsNoTracking().ToListAsync();

    public async Task<List<Brouwer>> FindByBeginNaamAsync(string begin) => await context.Brouwers.AsNoTracking().Where(brouwer => brouwer.Naam.StartsWith(begin)).ToListAsync();

    public async Task<Brouwer?> FindByIdAsync(int id) => await context.Brouwers.FindAsync(id);

    public async Task InsertAsync(Brouwer brouwer)
    {
        await context.Brouwers.AddAsync(brouwer);
        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Brouwer brouwer)
    {
        context.Brouwers.Update(brouwer);
        await context.SaveChangesAsync();
    }
    public async Task DeleteAsync(Brouwer brouwer)
    {
        context.Brouwers.Remove(brouwer);
        await context.SaveChangesAsync();
    }
}
