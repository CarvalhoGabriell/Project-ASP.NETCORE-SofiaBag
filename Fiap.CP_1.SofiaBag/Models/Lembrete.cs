using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.CP_1.SofiaBag.Models
{
    [Table("TB_LEMBRETE")]
    public class Lembrete
    {
        [HiddenInput]
        public int LembreteId { get; set; }

        [Display(Name = "Nome do Lembrete")] [MaxLength(12)]
        public string Nome { get; set; }

        [Display(Name = "Data do Lembrete")]
        public DateTime DtLembrete { get; set; }

        public bool Status { get; set; }
    }
}
