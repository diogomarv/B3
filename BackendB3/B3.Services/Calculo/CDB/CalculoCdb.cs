using B3.Model.Ativos.CDB;
using B3.Model.Enums;
using B3.Model.Extensions;
using B3.Services.Helpers.Moeda;
using BackendB3.Models.Response;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B3.Model.Calculo
{
    public class CalculoCdb
    {
        public ApiResponse<Cdb> CalcularCdb(decimal valorInicial, uint qtdMeses) 
        {

            if (qtdMeses <= 1)
                throw new ArgumentException("A quantidade de meses deve ser superior a 1.", nameof(qtdMeses));

            decimal rendimento = (1 + (TaxasConfig.TaxaCdi * TaxasConfig.TaxaTb));

            Cdb cdb = new Cdb
            {
                ValorFinalBruto = (((valorInicial * rendimento) - valorInicial) * qtdMeses) + valorInicial
            };

            cdb.RendimentoBruto = (cdb.ValorFinalBruto - valorInicial);
            cdb.DescontoImpostoRenda = Aliquotas.ObterTaxaPercentualImpostoDeRendaPorTempo(ETempoInvestimentoExtensions.TempoInvestimento(qtdMeses)) * cdb.RendimentoBruto;
            cdb.AliquotaImpostoRenda = Aliquotas.ObterTaxaPercentualImpostoDeRendaPorTempo(ETempoInvestimentoExtensions.TempoInvestimento(qtdMeses));
            cdb.RendimentoLiquido = cdb.RendimentoBruto - cdb.DescontoImpostoRenda;
            cdb.ValorFinalLiquido = cdb.ValorFinalBruto - cdb.DescontoImpostoRenda;

            return 
                new ApiResponse<Cdb>(
                true, 
                "Cálculo do CDB concluído com sucesso!", 
                $"Depositando {FormatacaoMonetaria.FormatarValor(valorInicial)}, você terá um rendimento líquido de {FormatacaoMonetaria.FormatarValor(cdb.RendimentoLiquido)} ao longo de {qtdMeses} meses. Informações úteis: " +
                $"Valor Final Bruto: {FormatacaoMonetaria.FormatarValor(cdb.ValorFinalBruto)} " +
                $"| Valor Final Líquido: {FormatacaoMonetaria.FormatarValor(cdb.ValorFinalLiquido)}" +
                $"| Rendimento Bruto: {FormatacaoMonetaria.FormatarValor(cdb.RendimentoBruto)} " +
                $"| Descontos de IR: {FormatacaoMonetaria.FormatarValor(cdb.DescontoImpostoRenda)} ", 
                cdb);
        }

    }

}
