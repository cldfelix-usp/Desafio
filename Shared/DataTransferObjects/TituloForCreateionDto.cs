using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransferObjects;

public record TituloForCreateionDto : TituloForManipulationDto
{
    [Required(ErrorMessage = "Parcelas da dívida é um campo obrigatório.")]
    public List<ParcelaForCreateionDto> ParcelasEmAtraso { get; set; } = new();
}