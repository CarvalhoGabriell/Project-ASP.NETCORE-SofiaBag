using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.CP_1.SofiaBag.Models
{
    [Table("T_USUARIO")]
    public class Usuario
    {
        [HiddenInput]
        public int UsuarioId { get; set; }

        [Display(Name ="Nome Completo"), MaxLength(100), Required]
        public string NomeCompleto { get; set; }

        [Display(Name ="Nome da sua Mochila")] [Required,MaxLength(40)]
        public string NomeMochila { get; set; }

        public int Idade { get; set; }

        [Display(Name ="Data Nascimento")] [DataType(DataType.Date), Required]
        public DateTime DtNascimento { get; set; }

        [Display(Name = "Gênero")]
        public Genero Sexo { get; set; }

        // RELACIONAMENTO 1:N
        public virtual ICollection<Objetos> Objetos { get; set; }
    }
    public enum Genero
    {
        Masculino, Feminino, Neutro, Outros
    }
}
