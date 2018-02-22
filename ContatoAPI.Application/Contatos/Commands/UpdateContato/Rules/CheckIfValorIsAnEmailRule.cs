using ContatoAPI.Tools.Domain.Notifications.Interfaces;
using ContatoAPI.Tools.Domain.Notifications.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ContatoAPI.Application.Contatos.Commands.UpdateContato.Rules
{
    public class CheckIfValorIsAnEmailRule : IUpdateContatoRule
    {
        public bool IsValid(UpdateContatoModel model, ICommand command)
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
