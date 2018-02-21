using ContatoAPI.Application.Contatos.Queries.GetContatoDetail;
using System;
using Xunit;

namespace ContatoAPI.Application.Tests.Contatos.Queries.GetContatoDetail
{
    public class GetContatoDetailModelTests
    {
        
        private GetContatoDetailModel _model;
        const string _str = "testeesd";
        
        public GetContatoDetailModelTests()
        {
            _model = new GetContatoDetailModel();
        }

        
        [Fact]
        public void TestGetAnsSetId()
        {
            _model.id = _str; 
            Assert.Equal(_str, _model.id);           
        }

        [Fact]
        public void TestGetAnsSetNome()
        {
            _model.nome = _str; 
            Assert.Equal(_str, _model.nome);           
        }

        [Fact]
        public void TestGetAnsSetCanal()
        {
            _model.canal = _str; 
            Assert.Equal(_str, _model.canal);           
        }

        [Fact]
        public void TestGetAnsSetValor()
        {
            _model.valor = _str; 
            Assert.Equal(_str, _model.valor);           
        }

        [Fact]
        public void TestGetAnsSetObs()
        {
            _model.obs = _str; 
            Assert.Equal(_str, _model.obs);           
        }
    }        
}