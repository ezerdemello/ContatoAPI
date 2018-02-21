using System;
using System.Threading.Tasks;

namespace ContatoAPI.Application.Contatos.Queries.GetContatoDetail
{
    public interface IGetContatoDetailQuery
    {
        Task<GetContatoDetailModel> Execute(string id);
    }        

}