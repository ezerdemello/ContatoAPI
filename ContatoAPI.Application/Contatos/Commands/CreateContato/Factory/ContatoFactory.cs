using System;
using System.Collections.Generic;
using System.Text;
using ContatoAPI.Domain.Contatos;
using MongoDB.Bson;

namespace ContatoAPI.Application.Contatos.Commands.CreateContato.Factory
{
    public class ContatoFactory : IContatoFactory
    {
        public Contato Create(string nome, string canal, string valor, string obs)
        {
            var result = new Contato();

            result.id = ObjectId.GenerateNewId();
            result.nome = nome;
            result.canal = canal;
            result.valor = valor;
            result.obs = obs;
            
            return result;
        }
    }
}
