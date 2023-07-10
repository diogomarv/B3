using B3.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B3.Model.Extensions
{
    public static class ETempoInvestimentoExtensions
    {
        public static ETempoInvestimento TempoInvestimento(this uint value)
        {
            if (value > 24)
            {
                return ETempoInvestimento.MaisDeDoisAnos;
            }
            else if (value > 12)
            {
                return ETempoInvestimento.AteDoisAnos;
            }
            else if (value > 6)
            {
                return ETempoInvestimento.AteUmAno;
            }

            return ETempoInvestimento.AteSeisMeses;
        }
    }
}
