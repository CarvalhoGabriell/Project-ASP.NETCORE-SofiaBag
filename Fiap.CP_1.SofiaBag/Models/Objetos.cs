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

        [Required]
        public string Nome { get; set; }

        [Required]
        public bool Ativo { get; set; }
        
        [Display(Name ="Descrição")]
        public string Descricao { get; set; }

        [DataType(DataType.Date), Display(Name ="Data de Cadastro"), Required]
        public DateTime DtCadastro { get; set; }

        [Display(Name ="Cores")]
        public string Cor { get; set; }

        // relacionamento N:N
        [Display(Name ="Categoria")]
        public ICollection<ObjetoCategoria> ObjetosCateg { get; set; }

        public int CategoriaId { get; set; }

        // relacionamento 1:1
        public Lembrete Lembrete { get; set; }

        public int? LembreteId { get; set; }

        /*
         * RELACIOAMENTO N:1 DE USUARIOS
         */

        public int UsuarioId { get; set; }

        public Usuario Usuario { get; set; }

    }
}
