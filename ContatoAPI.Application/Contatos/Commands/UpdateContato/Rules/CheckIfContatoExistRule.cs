using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ContatoAPI.Application.Interfaces;
using ContatoAPI.Tools.Domain.Notifications.Interfaces;
using ContatoAPI.Tools.Domain.Notifications.Model;

namespace ContatoAPI.Application.Contatos.Commands.UpdateContato.Rules
{
    public class CheckIfContatoExistRule : IUpdateContatoRule
    {
        private readonly IContatoRepository _repository;

        public CheckIfContatoExistRule(IContatoRepository repository)
        {
            _repository = repository;
        }

        public bool IsValid(UpdateContatoModel model, ICommand command)
        {
            if (string.IsNullOrEmpty(model.id))
                return true;

            var resultFrom = _repository.Get(model.id).Result;
            if (resultFrom == null)
            {
                command.AddNotification(new Notification { key = "id", value = "O Contato informado não existe" });
                return false;
            }

            return true;

        }
    }
}
