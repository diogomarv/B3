using B3.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B3.Model.Ativos.CDB
{
    public static class Aliquotas
    {
        public static decimal AteSeisMeses { get; set; } = 0.225m;
        public static decimal AteUmAno { get; set; } = 0.20m;
        public static decimal AteDoisAnos { get; set; } = 0.175m;
        public static decimal MaisDeDoisAnos { get; set; } = 0.15m;

        public static decimal ObterTaxaPercentualImpostoDeRendaPorTempo(ETempoInvestimento tempoInvestimento)
        {

            Dictionary<ETempoInvestimento, decimal> taxaPorTempo = new Dictionary<ETempoInvestimento, decimal>()
                {
                    { ETempoInvestimento.MaisDeDoisAnos, MaisDeDoisAnos },
                    { ETempoInvestimento.AteDoisAnos, AteDoisAnos },
                    { ETempoInvestimento.AteUmAno, AteUmAno },
                    { ETempoInvestimento.AteSeisMeses, AteSeisMeses }
                };

            if (taxaPorTempo.TryGetValue(tempoInvestimento, out decimal taxa))
            {
                return taxa;
            }

            // Retorna um valor padrão, caso o tempo de investimento não esteja no dicionário
            return AteSeisMeses; 
        }

    }
}
