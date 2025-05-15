using Contracts;
using Entities.Models;

namespace Repository;

internal sealed class ParcelaRepository : RepositoryBase<Parcela>, IParcelaRepository
{
    public ParcelaRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
    {
    }

    public void CreateParcela(Parcela parcelaEntity)=> Create(parcelaEntity);
}