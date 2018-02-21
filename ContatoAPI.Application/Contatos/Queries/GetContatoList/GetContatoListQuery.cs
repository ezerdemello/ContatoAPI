using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

using ContatoAPI.Application.Interfaces;
using ContatoAPI.Domain.Contatos;

namespace  ContatoAPI.Application.Contatos.Queries.GetContatoList
{
    public class GetContatoListQuery : IGetContatoListQuery 
    {
        private readonly IContatoRepository _repositorio;

        public GetContatoListQuery(IContatoRepository repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<List<GetContatoListItemModel>> Execute(GetContatoListFilter model)
        {
            GetContatoListItemModel modelItem;
            var filters = new List<Expression<Func<Contato, bool>>>();
            var result = new List<GetContatoListItemModel>();
            var query = await _repositorio.GetByFilters(filters, model.page, model.size);

            foreach(var item in query)
            {
                modelItem = new GetContatoListItemModel();

                modelItem.id = item.id.ToString();
                modelItem.nome = item.nome;
                modelItem.canal = item.canal;
                modelItem.valor = item.valor;
                modelItem.obs = item.obs;

                result.Add(modelItem);
            }

            return result;
            
        }

    }
}