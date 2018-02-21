using ContatoAPI.Tools.Domain.Notifications.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ContatoAPI.Application.Contatos.Commands.DeleteContato
{
    public interface IDeleteContatoCommand : ICommand
    {
        Task Execute(string model);
    }
}
