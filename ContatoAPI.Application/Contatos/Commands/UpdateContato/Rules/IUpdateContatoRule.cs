using ContatoAPI.Tools.Domain.Notifications.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContatoAPI.Application.Contatos.Commands.UpdateContato.Rules
{
    public interface IUpdateContatoRule
    {
        bool IsValid(UpdateContatoModel model, ICommand command);
    }
}
