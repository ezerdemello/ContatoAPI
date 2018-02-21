
using ContatoAPI.Application.Contatos.Queries.GetContatoList;
using ContatoAPI.Application.Interfaces;
using ContatoAPI.Domain.Contatos;
using MongoDB.Bson;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Xunit;

namespace ContatoAPI.Application.Tests.Contatos.Queries.GetContatoList
{

    public class GetContatoListQueryTests
    {
        private Contato _contatoFromDB;
        private Mock<IContatoRepository> _repository;
        private GetContatoListFilter _filter;
        private GetContatoListQuery _query;            
        private Task<List<Contato>> _resultFromDB;

        const string _str = "teste";

        public GetContatoListQueryTests()
        {
            _contatoFromDB = new Contato();
            _filter = new GetContatoListFilter();
            _repository = new Mock<IContatoRepository>();            
        }


        [Fact]
        public void TestExecuteWithoutValuesShouldReturnListWithZeroItem()
        {
            _resultFromDB = Task.FromResult(new List<Contato> { });

            _repository.Setup(x => x.GetByFilters(It.IsAny<List<Expression<Func<Contato, bool>>>>(), It.IsAny<int>(), It.IsAny<int>()))
                .Returns(_resultFromDB);

            _query = new GetContatoListQuery(_repository.Object); 

            //Act
            var result = _query.Execute(_filter).Result;
            
            //Assert
            Assert.Empty(result);                    
        }    

        [Fact]
        public void TestExecuteWithOneValueShouldReturnListWithOneItem()
        {
            //Arrange      
            var contato1 = new Contato { id = ObjectId.GenerateNewId(), nome = _str, canal = _str, valor = _str, obs = _str };

            _resultFromDB = Task.FromResult(new List<Contato> { contato1 });

            _repository.Setup(x => x.GetByFilters(It.IsAny<List<Expression<Func<Contato, bool>>>>(), It.IsAny<int>(), It.IsAny<int>()))
                .Returns(_resultFromDB);

            _query = new GetContatoListQuery(_repository.Object); 

            //Act
            var result = _query.Execute(_filter).Result;
            
            //Assert
            Assert.Single(result);                    

        }    
        
        [Theory]
        [InlineData("598086a56f725c9a24b9bc14", "ezer", "E-mail", "teste@email.com", "testando 1")]
        [InlineData("59e4ed15caa8988d58d59d6c", "samara", "Telefone", "2127061105", "testando 2")]
        [InlineData("5a0ae7017670892628c7061f", "sara", "Celular", "21981699756", "testando 3")]
        public void TestExecuteWithOneValueShouldReturnOneItemWithSameValues(string id, string nome, string canal, string valor, string obs)
        {
            //Arrange            
            _contatoFromDB = new Contato();
            _contatoFromDB.id = new ObjectId(id);
            _contatoFromDB.nome = nome;
            _contatoFromDB.canal = canal;
            _contatoFromDB.valor = valor;
            _contatoFromDB.obs = obs;

            _resultFromDB = Task.FromResult(new List<Contato> { _contatoFromDB });

            _repository.Setup(x => x.GetByFilters(It.IsAny<List<Expression<Func<Contato, bool>>>>(), It.IsAny<int>(), It.IsAny<int>()))
            .Returns(_resultFromDB);

            _query = new GetContatoListQuery(_repository.Object); 

            //Act
            var result = _query.Execute(_filter).Result;
            
            //Assert
            Assert.Equal(id, result.First().id);
            Assert.Equal(nome, result.First().nome);
            Assert.Equal(canal, result.First().canal);
            Assert.Equal(valor, result.First().valor);
            Assert.Equal(obs, result.First().obs);

        }    

    }
    
}