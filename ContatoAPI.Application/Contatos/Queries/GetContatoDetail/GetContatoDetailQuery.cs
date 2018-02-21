using System;
using System.Threading.Tasks;
using ContatoAPI.Application.Interfaces;

namespace ContatoAPI.Application.Contatos.Queries.GetContatoDetail
{
    public class GetContatoDetailQuery : IGetContatoDetailQuery
    {

        private readonly IContatoRepository _repository;

        public GetContatoDetailQuery(IContatoRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetContatoDetailModel> Execute(string id)
        {

            var result = new GetContatoDetailModel();

            var resultFromDB = await _repository.Get(id);

            if(resultFromDB == null)
                return null;
            
            result.id = resultFromDB.id.ToString();
            result.nome = resultFromDB.nome;
            result.canal = resultFromDB.canal;
            result.valor = resultFromDB.valor;
            result.obs = resultFromDB.obs;

            return result;
        }
    }
}