using MinimalBrouwerService.Models;


namespace MinimalBrouwerService.Repositories;

public interface IBrouwerRepository
{
    Task<List<Brouwer>> FindAllAsync();
    Task<Brouwer?> FindByIdAsync(int id);
    Task<List<Brouwer>> FindByBeginNaamAsync(string begin);
    Task UpdateAsync(Brouwer brouwer);
    Task DeleteAsync(Brouwer brouwer);
    Task InsertAsync(Brouwer brouwer);
}
