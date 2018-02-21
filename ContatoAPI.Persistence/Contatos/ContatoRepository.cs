
using ContatoAPI.Application.Interfaces;
using ContatoAPI.Domain.Contatos;
using ContatoAPI.Persistence.Shared;
using ContatoAPI.Persistence.Contatos;

using System;


namespace ContatoAPI.Persistence.Contatos
{

    public class ContatoRepository : Repository<Contato>, IContatoRepository
    {
        public ContatoRepository(IDatabaseContext database)
        : base(database) { }
    }

}