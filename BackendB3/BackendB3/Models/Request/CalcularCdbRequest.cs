using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BackendB3.Models.Request
{
    public class CalcularCdbRequest
    {
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "O valor inicial deve ser maior que zero.")]
        public decimal Valor { get; set; }

        [Required(ErrorMessage = "O prazo é obrigatório.")]
        [Range(2, int.MaxValue, ErrorMessage = "O prazo deve ser maior que 1 mês.")]
        public uint QtdMeses { get; set; }
    }
}