export interface ParcelaAtraso {
  numeroParcela?: number;
  parcelasDivida?: number;
  qtdParcelas?: number;
  dataVencimento: string | Date;
  valorParcela: number;
  valorParcelaAtualizada?: number;
  valorJuros?: number;
  valorMulta?: number;
}
