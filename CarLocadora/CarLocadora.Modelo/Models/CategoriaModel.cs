using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarLocadora.Modelo.Models
{
    public class CategoriaModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } = 0;
        [StringLength (100)]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }
        [Display(Name = "Nome Diária")]
        public decimal ValorDiaria { get; set; }
        public bool Ativo { get; set; }

        [Display(Name = "Data de Inclusão")]
        public DateTime DataInclusao { get; set; }
        [Display(Name = "Data de Alteração")]
        public DateTime? DataAlteracao { get; set; }
    }
}
