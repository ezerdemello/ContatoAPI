
using System;
using ContatoAPI.Domain.Common;

namespace ContatoAPI.Domain.Contatos
{


    public class Contato : Entity
    {
        public Contato()
        {
            
        }        
        
        public string nome { get; set; }

        public string canal { get; set; }

        public string valor { get; set; }

        public string obs { get; set; }

    }

}


