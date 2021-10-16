using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.CP_1.SofiaBag.Models
{
    [Table("TB_OBJETOS")]
    public class Objetos
    {
        [HiddenInput][Key]
        public int CodigoId { get; set; }

        public string Nome { get; set; }

        public bool Ativo { get; set; }
        [Display(Name ="Descrição")]
        public string Descricao { get; set; }

        [Display(Name ="Categoria")]
        public Categoria Tipo { get; set; }

        [DataType(DataType.Date), Display(Name ="Data de Cadastro")]
        public DateTime DtCadastro { get; set; }

        [Display(Name ="Cores")]
        public string Cor { get; set; }
    }

    public enum Categoria {
        Pessoal, Trabalho, Escola, Faculdade,Essenciais, Lazer, Alimento
    }
}
