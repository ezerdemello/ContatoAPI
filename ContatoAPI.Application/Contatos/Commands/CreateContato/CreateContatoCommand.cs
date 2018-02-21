using ContatoAPI.Application.Contatos.Commands.CreateContato.Factory;
using ContatoAPI.Application.Contatos.Commands.CreateContato.Rules;
using ContatoAPI.Application.Contatos.Commands.CreateContato;
using ContatoAPI.Application.Interfaces;
using ContatoAPI.Tools.Domain.Notifications.Interfaces;
using ContatoAPI.Tools.Domain.Notifications.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ContatoAPI.Application.Contatos.Commands.CreateContato
{
    public class CreateContatoCommand : ICreateContatoCommand
    {

        private readonly IContatoRepository _repository;
        private readonly IContatoFactory _modelFactory;
        private readonly IEnumerable<ICreateContatoRule> _rules;

        public CreateContatoCommand(
            IContatoRepository repository,
            IContatoFactory modelFactory,
            IEnumerable<ICreateContatoRule> rules
            )
        {
            _repository = repository;
            _modelFactory = modelFactory;
            _rules = rules;
        }

        public List<Notification> NotificationsList { get; set; }

        public async Task Execute(CreateContatoModel model)
        {
            if (!this.RequerimentoIsValid(model))
                return;

            var contato = _modelFactory.Create(model.nome, model.canal, model.valor, model.obs);
            
            await _repository.Add(contato);                    
        }

        public List<Notification> GetNotifications()
        {
            return this.GetNotificationsList();
        }

        public bool HasNotifications()
        {
            return this.ContainsNotifications();
        }

        private bool RequerimentoIsValid(CreateContatoModel model)
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
