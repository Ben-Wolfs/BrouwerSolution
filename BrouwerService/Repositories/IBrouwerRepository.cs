using BrouwerService.Models;

namespace BrouwerService.Repositories;

public interface IBrouwerRepository
{
    IQueryable<Brouwer> FindAll();
    Brouwer? FindById(int id);
    IQueryable<Brouwer> FindByBeginNaam(string begin);
    void Update(Brouwer brouwer);
    void Delete(Brouwer brouwer);
    void Insert(Brouwer brouwer);
}
