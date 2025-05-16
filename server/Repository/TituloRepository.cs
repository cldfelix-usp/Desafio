using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository;

internal sealed class TituloRepository: RepositoryBase<Titulo>, ITituloRepository
{
    public TituloRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
    {
    }

    public void CreateTitulo(Titulo tituloEntity) => Create(tituloEntity);
    public async Task<Titulo?> GetTituloAsync(string? tituloEntityNumeroTitulo)
    {
        var titulo = await FindByCondition(x 
                => x.NumeroTitulo.Equals(tituloEntityNumeroTitulo), false)
            .FirstOrDefaultAsync();

        return titulo;
    }

    public async Task<IEnumerable<Titulo>> GetAllTitulosAsync()
    {
        var titulos = await FindAll(false)
            .Include(x=> x.ParcelasEmAtraso)
            .OrderBy(x => x.NumeroTitulo)
            .ToListAsync();

        return titulos;
    }
}