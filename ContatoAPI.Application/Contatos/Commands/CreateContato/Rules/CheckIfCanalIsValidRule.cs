using System;
using System.Collections.Generic;
using System.Text;
using ContatoAPI.Tools.Domain.Notifications.Interfaces;
using ContatoAPI.Tools.Domain.Notifications.Model;

namespace ContatoAPI.Application.Contatos.Commands.CreateContato.Rules
{
    public class CheckIfCanalIsValidRule : ICreateContatoRule
    {
        public bool IsValid(CreateContatoModel model, ICommand command)
        {
            if (string.IsNullOrEmpty(model.canal))
                return true;

            if (!model.canal.Equals("Celular") && !model.canal.Equals("E-mail") && !model.canal.Equals("Telefone"))
            {
                command.AddNotification(new Notification { key = "canal", value = string.Format("Apenas Celular, E-mail e Telefone são considerados válidos como canal.", model.canal) });
                return false;
            }

            return true;
        }
    }
}
