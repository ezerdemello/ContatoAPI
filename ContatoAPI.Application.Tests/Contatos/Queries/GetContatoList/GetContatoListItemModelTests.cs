using ContatoAPI.Application.Contatos.Queries.GetContatoList;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace ContatoAPI.Application.Tests.Contatos.Queries.GetContatoList
{
    public class GetContatoListItemModelTests
    {
        //private ObjectId _id;
        private GetContatoListItemModel _model;
        const string _str = "testeesd";

        public GetContatoListItemModelTests()
        {
            //_id = ObjectId.GenerateNewId();
            _model = new GetContatoListItemModel();
        } 

        [Fact]
        public void TestGetAnsSetId()
        {
            _model.id = _str; 
            Assert.Equal(_str, _model.id);           
        }

        [Fact]
        public void TestGetAndSetNome()
        {
            _model.nome = _str; 
            Assert.Equal(_str, _model.nome);           
        }

        [Fact]
        public void TestGetAndSetCanal()
        {
            _model.canal = _str; 
            Assert.Equal(_str, _model.canal);           
        }

        [Fact]
        public void TestGetAndSetValor()
        {
            _model.valor = _str; 
            Assert.Equal(_str, _model.valor);           
        }

        [Fact]
        public void TestGetAndSetObs()
        {
            _model.obs = _str; 
            Assert.Equal(_str, _model.obs);           
        }

    }
}