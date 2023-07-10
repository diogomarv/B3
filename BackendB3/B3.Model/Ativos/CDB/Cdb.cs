using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B3.Model.Ativos.CDB
{
    public class Cdb
    {
        public decimal RendimentoBruto { get; set; }
        public decimal RendimentoLiquido { get; set; }
        public decimal ValorFinalBruto { get; set; }
        public decimal ValorFinalLiquido { get; set; }
        public decimal DescontoImpostoRenda { get; set; }
        public decimal AliquotaImpostoRenda { get; set; }

        public Cdb()
        {
                
        }
       
    }
}
