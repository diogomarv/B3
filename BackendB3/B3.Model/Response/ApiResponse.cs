using B3.Model.Ativos.CDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackendB3.Models.Response
{
    public class ApiResponse <T>
    {
        public bool Sucesso { get; set; }
        public string Titulo { get; set; }
        public string Mensagem { get; set; }
        public T Data { get; set; }

        public ApiResponse(bool sucesso, string titulo, string mensagem, T data)
        {
            Sucesso = sucesso;
            Titulo = titulo;
            Mensagem = mensagem;
            Data = data;
        }
    }
}