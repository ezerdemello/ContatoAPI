using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ContatoAPI.Application.Contatos.Commands.CreateContato
{
    public class CreateContatoModel
    {
        [Required(ErrorMessage = "Informe o nome.")]
        public string nome { get; set; }

        [Required(ErrorMessage = "Informe o canal.")]
        public string canal { get; set; }

        [Required(ErrorMessage = "Informe o valor.")]
        public string valor { get; set; }

        public string obs { get; set; }
    
    }
}
