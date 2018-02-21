using System;
using System.Collections.Generic;
using System.Text;
using ContatoAPI.Application.Interfaces;
using ContatoAPI.Tools.Domain.Notifications.Interfaces;
using ContatoAPI.Tools.Domain.Notifications.Model;

namespace ContatoAPI.Application.Contatos.Commands.DeleteContato.Rules
{
    public class CheckIfContatoExistRule : IDeleteContatoRule
    {

        private readonly IContatoRepository _repository;

        public CheckIfContatoExistRule(IContatoRepository repository)
        {
            _repository = repository;
        }

        public bool IsValid(string model, ICommand command)
        {
            if (string.IsNullOrEmpty(model))
                return true;

            var resultFrom = _repository.Get(model).Result;
            if (resultFrom == null)
            {
                command.AddNotification(new Notification { key = "id", value = "O Contato informado não existe" });
                return false;
            }

            return true;
        }
    }
}
