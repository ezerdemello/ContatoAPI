using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ContatoAPI.Application.Contatos.Commands.UpdateContato.Rules;
using ContatoAPI.Application.Interfaces;
using ContatoAPI.Tools.Domain.Notifications.Interfaces;
using ContatoAPI.Tools.Domain.Notifications.Model;

namespace ContatoAPI.Application.Contatos.Commands.UpdateContato
{
    public class UpdateContatoCommand : IUpdateContatoCommand
    {

        private readonly IContatoRepository _repository;
        private readonly IEnumerable<IUpdateContatoRule> _rules;

        public UpdateContatoCommand(IContatoRepository repository,
            IEnumerable<IUpdateContatoRule> rules)
        {
            _repository = repository;
            _rules = rules;
        }

        public List<Notification> NotificationsList { get; set; }

        public async Task Execute(UpdateContatoModel model)
        {
            if (!this.RequerimentoIsValid(model))
                return;

            var contato = await _repository.Get(model.id);

            contato.nome = model.nome;
            contato.canal = model.canal;
            contato.valor = model.valor;
            contato.obs = model.obs;


        }

        public List<Notification> GetNotifications()
        {
            return this.GetNotificationsList();
        }

        public bool HasNotifications()
        {
            return this.ContainsNotifications();
        }

        private bool RequerimentoIsValid(UpdateContatoModel model)
        {
            try
            {
                var result = true;

                if (!this.ModelValidate(model))
                    result = false;

                if (result)
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
