using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Entities.Models;

[Index(nameof(NumeroTitulo), IsUnique = true)]
public class Titulo
{
    [Column("TituloId")]
    public Guid Id { get; set; }
	
    [Required(ErrorMessage = "Número do título é um campo obrigatório.")]
    [MaxLength(30, ErrorMessage = "O número do título deve ter no máximo 30 caracteres.")]
    public string? NumeroTitulo { get; set; }
	
    [Required(ErrorMessage = "Nome do devedor é um campo obrigatório.")]
    [MaxLength(100, ErrorMessage = "O nome do devedor deve ter no máximo 100 caracteres.")]
    public string? NomeDevedor { get; set; }
	
    [Required(ErrorMessage = "CPF do devedor é um campo obrigatório.")]
    [MaxLength(11, ErrorMessage = "O CPF do devedor deve ter no máximo 11 caracteres.")]
    public string? CpfDevedor { get; set; }
	
    [Required(ErrorMessage = "% de juros é um campo obrigatório.")]
    [Range(0, int.MaxValue, ErrorMessage = "O % de juros deve ser maior ou igual a 0.")]
    public decimal PercentualJuros { get; set; }
	
    [Required(ErrorMessage = "% de multa é um campo obrigatório.")]
    [Range(0, int.MaxValue, ErrorMessage = "O % de multa deve ser maior ou igual a 0.")]
    public decimal PercentualMulta { get; set; }

    [Required(ErrorMessage = "Parcelas da dívida é um campo obrigatório.")]
    public List<Parcela> ParcelasEmAtraso { get; set; } = new();
    
   
}