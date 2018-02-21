using ContatoAPI.Tools.Domain.Notifications.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ContatoAPI.Application.Contatos.Commands.CreateContato
{
    public interface ICreateContatoCommand : ICommand
    {
        Task Execute(CreateContatoModel model);
    }
}
