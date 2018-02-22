using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using ContatoAPI.Application.Contatos.Commands.CreateContato;
using ContatoAPI.Tools.Domain.Notifications.Interfaces;
using ContatoAPI.Tools.Domain.Notifications.Model;

namespace ContatoAPI.Application.Contatos.Commands.CreateContato.Rules
{
    public class CheckIfValorIsAnEmailRule : ICreateContatoRule
    {
        public bool IsValid(CreateContatoModel model, ICommand command)
        {
            if (string.IsNullOrEmpty(model.canal) || string.IsNullOrEmpty(model.valor))
                return true;

            if (model.canal.Equals("E-mail"))
            {
                var regex = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
                Match match = Regex.Match(model.valor, regex, RegexOptions.IgnoreCase);
                if (!match.Success)
                {
                    command.AddNotification(new Notification { key = "valor", value = "O valor informado não corresponde a um E-mail" });
                    return false;
                }
            }

            return true;

        }
    }
}
