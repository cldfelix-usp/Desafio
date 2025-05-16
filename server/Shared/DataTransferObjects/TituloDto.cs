namespace Shared.DataTransferObjects;

public record TituloDto(Guid Id);

public record TituloResponseDto(Guid Id) : TituloDto(Id)
{
    public string? NumeroTitulo { get; set; }
	
    public string? NomeDevedor { get; set; }
	
    public string? CpfDevedor { get; set; }
	
    public decimal PercentualJuros { get; set; }
	
    public decimal PercentualMulta { get; set; }
    
    public List<ParcelaDtoResponse> ParcelasEmAtraso { get; set; } 
    
}