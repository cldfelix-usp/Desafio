import { ParcelaAtraso } from "./parcela-atraso";

export interface TituloDevedor {
  id?: string;
  numeroTitulo: string;
  nomeDevedor: string;
  cpfDevedor?: string;
  parcelasEmAtraso: ParcelaAtraso[];
  qtdParcelas?: number;
  valorOriginal?: number;
  valorAtualizado?: number;
  diasEmAtrazo?: number;
  percentualJuros: number;
  percentualMulta: number;
}
