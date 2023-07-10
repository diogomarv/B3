export interface ApiResponse {
    Titulo: string;
    Mensagem: string;
    Sucesso: boolean;
    Data: ApiResponseData;
}

interface ApiResponseData {
    RendimentoBruto: number;
    RendimentoLiquido: number;
    ValorFinalBruto: number;
    ValorFinalLiquido: number;
    DescontoImpostoRenda: number;
    AliquotaImpostoRenda: number;
  }