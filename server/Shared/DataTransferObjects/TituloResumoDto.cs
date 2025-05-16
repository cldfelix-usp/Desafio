namespace Shared.DataTransferObjects;

public record TituloResumoDto(Guid Id) : TituloDto(Id)
{
    public string? NumeroTitulo { get; set; }
	
    public string? NomeDevedor { get; set; }
    public List<ParcelaDtoResponse> ParcelasEmAtraso { get; set; } = new();
     
    public int? QtdParcelas { get; private set; }
	
    public decimal ValorOriginal { get; private set; }
    public decimal ValorAtualizado { get; private set; }
	
    public int DiasEmAtrazo { get; private set; }

    public decimal PercentualJuros { get; set; }
	
    public decimal PercentualMulta { get; set; }
    
    public void SetSumario()
    {
	    
	    var dataHoje = DateTime.Now;
	    var qtdDiasEmAtrazo  = (dataHoje  - ParcelasEmAtraso.MinBy(obj => obj.DataVencimento)!.DataVencimento).Days;
	    DiasEmAtrazo =  ParcelasEmAtraso.Max(x => qtdDiasEmAtrazo);
	    QtdParcelas = ParcelasEmAtraso.Count();
	    ValorOriginal = ParcelasEmAtraso.Sum(x => x.ValorParcela);
	    
	    foreach (var parcela in ParcelasEmAtraso)
		    parcela.CalcularNovosValores(PercentualJuros, PercentualMulta);
	    
	    ValorAtualizado = ParcelasEmAtraso.Sum(x => x.ValorParcelaAtualizada);
	    
		    
    }

}