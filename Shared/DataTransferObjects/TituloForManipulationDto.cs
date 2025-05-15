using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransferObjects;

public abstract record TituloForManipulationDto
{
    /*
	 *  Número do título 
	    Nome do devedor 
	    CPF do devedor 
	    % de juros 
	    % de multa 
	    Parcelas da dívida 
	    Número da parcela 
	    Data de vencimento 
	    Valor da parcela 
	 */
	
    [Required(ErrorMessage = "Número do título é um campo obrigatório.")]
    [MaxLength(30, ErrorMessage = "O número do título deve ter no máximo 30 caracteres.")]
    public string? NumeroTitulo { get; init; }
	
    [Required(ErrorMessage = "Nome do devedor é um campo obrigatório.")]
    [MaxLength(100, ErrorMessage = "O nome do devedor deve ter no máximo 100 caracteres.")]
    public string? NomeDevedor { get; init; }
	
    [Required(ErrorMessage = "CPF do devedor é um campo obrigatório.")]
    [MaxLength(11, ErrorMessage = "O CPF do devedor deve ter no máximo 11 caracteres.")]
    public string? CpfDevedor { get; init; }
	
    [Required(ErrorMessage = "% de juros é um campo obrigatório.")]
    [Range(0, int.MaxValue, ErrorMessage = "O % de juros deve ser maior ou igual a 0.")]
    public decimal PercentualJuros { get; init; }
	
    [Required(ErrorMessage = "% de multa é um campo obrigatório.")]
    [Range(0, int.MaxValue, ErrorMessage = "O % de multa deve ser maior ou igual a 0.")]
    public decimal PercentualMulta { get; init; }

 

}