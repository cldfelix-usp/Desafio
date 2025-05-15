using Shared.DataTransferObjects;

namespace Service.Contracts;

public interface IParcelaService
{
    Task CriarParcelaAsync(ParcelaForCreateionDto parcela, TituloResponseDto? titulo = null);
}