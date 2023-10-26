using Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entidades
{
    [Table("Receita")]
    public class Receita : Base
    {
        public decimal Valor { get; set; }
        public int Mes { get; set; }
        public int Ano { get; set; }

        public EnumTipoReceita TipoReceita { get; set; }

        public DateTime DataCadastro { get; set; }

        public DateTime DataAlteracao { get; set; }

        [ForeignKey("Categoria")]
        [Column(Order = 1)]
        public int IdCategoria { get; set; }
        //public virtual Categoria Categoria { get; set; }
    }
}
