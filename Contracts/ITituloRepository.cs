using Entities.Models;

namespace Contracts;

public interface ITituloRepository
{
    void CreateTitulo(Titulo tituloEntity);
    Task<Titulo?> GetTituloAsync(string? tituloEntityNumeroTitulo);
    Task<IEnumerable<Titulo>> GetAllTitulosAsync();
}