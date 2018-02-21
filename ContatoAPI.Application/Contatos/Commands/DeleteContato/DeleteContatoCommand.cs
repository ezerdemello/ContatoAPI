using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ContatoAPI.Application.Contatos.Commands.DeleteContato.Rules;
using ContatoAPI.Application.Interfaces;
using ContatoAPI.Tools.Domain.Notifications.Interfaces;
using ContatoAPI.Tools.Domain.Notifications.Model;

namespace ContatoAPI.Application.Contatos.Commands.DeleteContato
{
    public class DeleteContatoCommand : IDeleteContatoCommand
    {
        
        private readonly IContatoRepository _repository;
        private readonly IEnumerable<IDeleteContatoRule> _rules;

        public DeleteContatoCommand(IContatoRepository repository,
            IEnumerable<IDeleteContatoRule> rules)
        {
            _repository = repository;
            _rules = rules;
        }

        public List<Notification> NotificationsList { get; set; }

        public async Task Execute(string model)
        {
            if (!this.ModelIsValid(model))
                return;

            var contato = await _repository.Get(model);

            await _repository.Remove(contato);
        }

        public List<Notification> GetNotifications()
        {
            return this.GetNotificationsList();
        }

        public bool HasNotifications()
        {
            return this.ContainsNotifications();
        }

        private bool ModelIsValid(string model)
        {
            try
            {
                var result = true;

                foreach (var rule in _rules)
                    if (!rule.IsValid(model, this))
                        result = false;

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
