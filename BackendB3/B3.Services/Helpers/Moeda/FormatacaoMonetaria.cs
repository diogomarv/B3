using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B3.Services.Helpers.Moeda
{
    public static class FormatacaoMonetaria
    {
        public static string FormatarValor(decimal valor)
        {
            return valor.ToString("C", CultureInfo.GetCultureInfo("pt-BR"));
        }
    }
}
