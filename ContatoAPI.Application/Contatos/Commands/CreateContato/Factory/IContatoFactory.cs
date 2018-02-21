using ContatoAPI.Domain.Contatos;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContatoAPI.Application.Contatos.Commands.CreateContato.Factory
{
    public interface IContatoFactory
    {
        Contato Create(string nome, string canal, string value, string obs);
    }
}
