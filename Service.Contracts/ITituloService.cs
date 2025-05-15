using Shared.DataTransferObjects;

namespace Service.Contracts;

public interface ITituloService
{
    Task<TituloDto> CriarTituloAsync(TituloForCreateionDto titulo);
    Task<IEnumerable<TituloResumoDto>> GetTitulosAsync();
    Task<TituloResponseDto?> GetTituloAsync(string tituloNumeroTitulo);
}