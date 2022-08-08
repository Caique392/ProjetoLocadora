using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarLocadora.Modelo.Models
{
    public class FormasDePagamentoModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage = "Id é obrigatorio.")]
        public int Id { get; set; } = 0;
        [StringLength(150)]
        [Required(ErrorMessage = "Descricao é obrigatorio.")]
        public string Descricao { get; set; }
        public bool Ativo { get; set; }
        [Required(ErrorMessage = "Data Inclusão é obrigatoria.")]

        public DateTime DataInclusao { get; set; }
        public DateTime? DataAlteracao { get; set; }
    }
}
