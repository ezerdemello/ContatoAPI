using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using ContatoAPI.Application.Contatos.Commands.CreateContato;
using ContatoAPI.Tools.Domain.Notifications.Interfaces;
using ContatoAPI.Tools.Domain.Notifications.Model;

namespace ContatoAPI.Application.Contatos.Commands.CreateContato.Rules
{
    public class CheckIfValorIsAnTelefoneOrCelularRule : ICreateContatoRule
    {
        public bool IsValid(CreateContatoModel model, ICommand command)
        {
            if (string.IsNullOrEmpty(model.canal) || string.IsNullOrEmpty(model.valor))
                return true;

            if(model.canal.Equals("Telefone") || model.canal.Equals("Celular"))
            {
                var regex = @"^(([1-9]{1}[0-9]{1}[9]{1}[0-9]{4}[0-9]{4})|([1-9]{1}[0-9]{1}[1-8]{1}[0-9]{3}[0-9]{4}))$";
                Match match = Regex.Match(model.valor, regex, RegexOptions.IgnoreCase);
                if (!match.Success)
                {
                    command.AddNotification(new Notification { key = "valor", value = string.Format("O valor não corresponde a um {0}", model.canal) });
                    return false;
                }
            }

            return true;

        }

    }
}
