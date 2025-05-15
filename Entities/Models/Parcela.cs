using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models;

public class Parcela
{
    [Column("ParcelaId")]
    public Guid Id { get; set; }
	
    [ForeignKey(nameof(Titulo))]
    public Guid TituloId { get; set; }
	
    public Titulo? Titulo { get; set; }
	
    public int QtdParcelas { get; set; }
	
    [Required(ErrorMessage = "Número da parcela é um campo obrigatório.")]
    [Range(1, int.MaxValue, ErrorMessage = "O número da parcela deve ser maior ou igual a 1.")]
    public int NumeroParcela { get; set; }
	
    [Required(ErrorMessage = "Data de vencimento é um campo obrigatório.")]
    public DateTime DataVencimento { get; set; }
	
	
    [Required(ErrorMessage = "Valor da parcela é um campo obrigatório.")]
    [Range(1, int.MaxValue, ErrorMessage = "O valor da parcela deve ser maior ou igual a 1.")]
    public decimal ValorParcela { get; set; }
}