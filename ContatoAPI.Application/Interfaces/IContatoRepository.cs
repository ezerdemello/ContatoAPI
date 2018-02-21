using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ContatoAPI.Domain.Contatos;

namespace ContatoAPI.Application.Interfaces
{
    public interface IContatoRepository : IRepository<Contato>
    {
        
    }

}