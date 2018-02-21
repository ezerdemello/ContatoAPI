using ContatoAPI.Tools.Domain.Notifications.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContatoAPI.Application.Contatos.Commands.DeleteContato.Rules
{
    public interface IDeleteContatoRule
    {
        bool IsValid(string model, ICommand command);
    }
}
