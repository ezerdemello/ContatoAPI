using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ContatoAPI.Application.Contatos.Queries.GetContatoDetail;
using ContatoAPI.Application.Contatos.Queries.GetContatoList;
using Microsoft.AspNetCore.Authorization;
using ContatoAPI.Application.Contatos.Commands.CreateContato;
using System.Text;
using ContatoAPI.Application.Contatos.Commands.UpdateContato;
using ContatoAPI.Application.Contatos.Commands.DeleteContato;

namespace ContatoAPI.Service.Controllers
{

    [Route("api/[controller]")]
    public class ContatoController : Controller
    {

        private readonly IGetContatoListQuery _queryList;
        private readonly IGetContatoDetailQuery _queryDetail;
        private readonly ICreateContatoCommand _createCommand;
        private readonly IUpdateContatoCommand _updateCommand;
        private readonly IDeleteContatoCommand _deleteCommand;

        

        public ContatoController(IGetContatoListQuery queryList,
             IGetContatoDetailQuery queryDetail,
              ICreateContatoCommand createCommand,
              IUpdateContatoCommand updateCommand,
              IDeleteContatoCommand deleteCommand)
        {
            _queryList = queryList;
            _queryDetail = queryDetail;
            _createCommand = createCommand;
            _updateCommand = updateCommand;
            _deleteCommand = deleteCommand;
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
        [Authorize]
        public async Task<IActionResult> Post([FromBody]CreateContatoModel value)
        {
            await _createCommand.Execute(value);
            if (_createCommand.HasNotifications())
                return BadRequest(_createCommand.GetNotifications());
            
            return Created("", "");
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Put(string id, [FromBody]UpdateContatoModel value)
        {
            value.id = id;
            await _updateCommand.Execute(value);

            if (_createCommand.HasNotifications())
            {
                var notifications = _createCommand.GetNotifications();
                if (notifications.Any(x => x.key.Equals("id")))
                    return NotFound(notifications);
                else
                    return BadRequest(notifications);
            }

            return NoContent();

        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(string id)
        {
            await _deleteCommand.Execute(id);

            if (_createCommand.HasNotifications())
                return NotFound();
            
            return NoContent();

        }
    }
}