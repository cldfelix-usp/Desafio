using System.IO.Pipes;

namespace Shared.DataTransferObjects;

public class ParcelaDtoResponse
{
    public int NumeroParcela { get; set; }
    public DateTime DataVencimento { get; set; }
    public decimal ValorParcela { get; set; }
    public decimal ValorParcelaAtualizada { get; private set; }
    public decimal ValorJuros { get;  private set; }
    public decimal ValorMulta { get; private set; }

    private void CalcularJuros (int qtdDiasEmAtrazo, decimal juros) {
        var jurosPorDia = ((juros/100)/ 30) * qtdDiasEmAtrazo;
        ValorJuros = ((int)(qtdDiasEmAtrazo / 30) * juros / 100) * ValorParcela;
    }

    private void CalcularMulta(decimal multa)
    {
        ValorMulta = (multa / 100) * ValorParcela;
    }
    
    private void CalcularValorAtualizado()
    {
        ValorParcelaAtualizada = ValorParcela + ValorJuros + ValorMulta;
    }


    public void CalcularNovosValores(decimal juros, decimal multa)
    {
        var dataHoje = DateTime.Now;
        var qtdDiasEmAtrazo = (dataHoje - DataVencimento).Days;
        
        CalcularJuros(qtdDiasEmAtrazo, juros);
        CalcularMulta(multa);
        CalcularValorAtualizado();
        

    }
    
    
}