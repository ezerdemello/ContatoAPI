using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace  ContatoAPI.Application.Contatos.Queries.GetContatoList
{

    public interface IGetContatoListQuery 
    {
        //Task<List<GetContatoListItemModel>> Execute(GetContatoListFilter model);
        Task<List<GetContatoListItemModel>> Execute(GetContatoListFilter model);
    }

}