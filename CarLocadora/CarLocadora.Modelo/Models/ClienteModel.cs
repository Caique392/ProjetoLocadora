﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarLocadora.Modelo.Models
{
    public class ClienteModel : EnderecoModel
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage = "CPF é obrigatorio.")]
        [StringLength(14, MinimumLength = 14, ErrorMessage = "caracteres mínimos 14")]
        public string CPF { get; set; } = string.Empty;
        [Required(ErrorMessage = "RG é obrigatorio.")]
        [StringLength(12, MinimumLength = 5, ErrorMessage = "caracteres mínimo 5 máximo de 30")]
        public string CNH { get; set; } = string.Empty;

        [Display(Name = "Nome completo")]
        [Required(ErrorMessage = "Nome completo é obrigatorio.")]
        [StringLength(150, MinimumLength = 5, ErrorMessage = "caracteres mínimo 5 máximo de 100")]
        public string Nome { get; set; }

        public DateTime DataNascimento { get; set; }
        [StringLength(15, MinimumLength = 0, ErrorMessage = "caracteres mínimo 0 máximo de 15")]
        public string? Telefone { get; set; }

        [Required(ErrorMessage = "Celular é obrigatorio.")]
        [StringLength(15, MinimumLength = 15, ErrorMessage = "caracteres mínimo 15 máximo de 15")]
        public string Celular { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataInclusao { get; set; }
        [Display(Name = "Data de Alteração")]

        public DateTime? DataAlteracao { get; set; }
    }
}