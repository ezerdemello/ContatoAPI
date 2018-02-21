using ContatoAPI.Tools.Domain.Notifications.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ContatoAPI.Application.Contatos.Commands.UpdateContato
{
    public interface IUpdateContatoCommand : ICommand
    {
        Task Execute(UpdateContatoModel model);
    }
}
