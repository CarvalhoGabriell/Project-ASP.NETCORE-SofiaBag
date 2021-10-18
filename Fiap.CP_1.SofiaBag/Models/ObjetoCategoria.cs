using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.CP_1.SofiaBag.Models
{
    [Table("TB_OBJETOS_CATEGORIAS")]
    public class ObjetoCategoria
    {
        public Objetos Objeto { get; set; }

        public int CodigoId { get; set; }


        public Categoria Categoria{ get; set; }

        public int CategoriaId { get; set; }
    }

}
