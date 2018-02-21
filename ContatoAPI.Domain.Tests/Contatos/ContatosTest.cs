using ContatoAPI.Domain.Contatos;
using MongoDB.Bson;
using System;
using Xunit;

namespace ContatoAPI.Domain.Tests.Contatos
{
    public class ContatoTests
    {
        
        private Contato _contato;
        const string _str = "fdsfsd";

        public ContatoTests()
        {
            _contato = new Contato();
        } 

        [Fact]
        public void TestGetAndSetNome()
        {
            _contato.nome = _str;
            Assert.Equal(_contato.nome, _str);
        }

        [Fact]
        public void TestGetAndSetCanal()
        {
            _contato.canal = _str;
            Assert.Equal(_contato.canal, _str);
        }

        [Fact]
        public void TestGetAndSetValor()
        {
            _contato.valor = _str;
            Assert.Equal(_contato.valor, _str);
        }
        
        [Fact]
        public void TestGetAndSetObs()
        {
            _contato.obs = _str;
            Assert.Equal(_contato.obs, _str);
        }

    }
}