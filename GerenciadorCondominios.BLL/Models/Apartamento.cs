﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorCondominios.BLL.Models
{
    public class Apartamento
    {
        public int ApartamentoId { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]       
        [Range(0, 1000, ErrorMessage = "Valor inválido")]
        [Display(Name = "Número")]
        public int Numero { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [Range(0, 10, ErrorMessage = "Valor inválido")]
        public int Andar { get; set; }
        public string Foto { get; set; }
        public int MoradorId { get; set; }

        public virtual Usuario Morador { get; set; }
        public int ProprietarioId { get; set; }
        public virtual Usuario Proprietario { get; set; }
    }
}
