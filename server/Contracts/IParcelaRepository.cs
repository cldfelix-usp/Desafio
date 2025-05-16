using Entities.Models;

namespace Contracts;

public interface IParcelaRepository
{
    void CreateParcela(Parcela parcelaEntity);
}