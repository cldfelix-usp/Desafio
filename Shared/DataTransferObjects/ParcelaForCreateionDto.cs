namespace Shared.DataTransferObjects;

public record ParcelaForCreateionDto : ParcelaForManipulationDto
{
    public Guid TituloId { get; set; }
}