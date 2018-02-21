using ContatoAPI.Application.Contatos.Commands.CreateContato;
using ContatoAPI.Tools.Domain.Notifications.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContatoAPI.Application.Contatos.Commands.CreateContato.Rules
{
    public interface ICreateContatoRule
    {
        bool IsValid(CreateContatoModel model, ICommand command);
    }
}
