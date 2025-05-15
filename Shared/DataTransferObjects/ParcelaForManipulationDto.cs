using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransferObjects;

public abstract record ParcelaForManipulationDto
{
    // [Required(ErrorMessage = "Parcelas da dívida é um campo obrigatório.")]
    // [Range(1, int.MaxValue, ErrorMessage = "O número de parcelas deve ser maior ou igual a 1.")]
    public int ParcelasDivida { get; init; }
	
    [Required(ErrorMessage = "Número da parcela é um campo obrigatório.")]
    [Range(1, int.MaxValue, ErrorMessage = "O número da parcela deve ser maior ou igual a 1.")]
    public int QtdParcelas { get; init; }
	
    [Required(ErrorMessage = "Data de vencimento é um campo obrigatório.")]
    public DateTime DataVencimento { get; init; }
	
	
    [Required(ErrorMessage = "Valor da parcela é um campo obrigatório.")]
    [Range(1, int.MaxValue, ErrorMessage = "O valor da parcela deve ser maior ou igual a 1.")]
    public decimal ValorParcela { get; init; }
}