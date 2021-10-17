using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.CP_1.SofiaBag.Models
{
    [Table("TB_CATEGORIA")]
    public class Categoria
    {
        [HiddenInput]
        public int CategoriaId { get; set; }

        public string Nome { get; set; }

        [MaxLength(30)]
        public string Descricao { get; set; }

        [DataType(DataType.Date)] [Display(Name ="Data Cadastro")]
        public DateTime DtCadastro { get; set; }

    }
}
