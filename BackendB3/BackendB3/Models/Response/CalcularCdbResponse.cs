using B3.Model.Ativos.CDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackendB3.Models.Response
{
    public class CalcularCdbResponse
    {
        public bool Sucesso { get; set; }
        public string Mensagem { get; set; }
        public Cdb CdbInfo { get; set; }

        public CalcularCdbResponse(bool success, string message, Cdb cdbInfo)
        {
            Sucesso = success;
            Mensagem = message;
            CdbInfo = cdbInfo;
        }
    }
}