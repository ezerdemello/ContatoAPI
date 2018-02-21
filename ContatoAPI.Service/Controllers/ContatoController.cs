using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ContatoAPI.Application.Contatos.Queries.GetContatoDetail;
using ContatoAPI.Application.Contatos.Queries.GetContatoList;
using Microsoft.AspNetCore.Authorization;

namespace ContatoAPI.Service.Controllers
{

    [Route("api/[controller]")]
    public class ContatoController : Controller
    {

        private readonly IGetContatoListQuery _queryList;
        private readonly IGetContatoDetailQuery _queryDetail;

        public ContatoController(IGetContatoListQuery queryList,
             IGetContatoDetailQuery queryDetail)
        {
            _queryList = queryList;
            _queryDetail = queryDetail;
        }

        // GET api/values
        
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Get(GetContatoListFilter model)
        {
            var resultFromQuery = await _queryList.Execute(model);
            
            if(resultFromQuery == null)
                return NotFound("Nenhum conteudo encontrado");

            return Ok(resultFromQuery);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> Get(string id)
        {
            var returnFromQuery = await _queryDetail.Execute(id);
            if(returnFromQuery == null)
                return NotFound("Não foi possível encontrar o objeto!");

            return Ok(returnFromQuery);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}