using ContatoAPI.Application.Contatos.Queries.GetContatoDetail;
using ContatoAPI.Application.Interfaces;
using ContatoAPI.Domain.Contatos;
using MongoDB.Bson;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace ContatoAPI.Application.Tests.Contatos.Queries.GetContatoDetail
{   

    public class GetContatoDetailQueryTests
    {
        private Contato _contatoFromDB;
        private Task<Contato> _resultFromDB;
        private Mock<IContatoRepository> _repository;

        private GetContatoDetailQuery _query;

        const string _str = "598086a56f725c9a24b9bc14";

        public GetContatoDetailQueryTests()
        {
            _repository = new Mock<IContatoRepository>();
        }

        [Theory]
        [InlineData("598086a56f725c9a24b9bc14", "ezer", "E-mail", "teste@email.com", "testando 1")]
        [InlineData("59e4ed15caa8988d58d59d6c", "samara", "Telefone", "2127061105", "testando 2")]
        [InlineData("5a0ae7017670892628c7061f", "sara", "Celular", "21981699756", "testando 3")]
        public async void TestExecuteShouldBeReturnWithTrueValue(string id, string nome, string canal, string valor, string obs)
        {
            //Arrange
            _contatoFromDB = new Contato();
            _contatoFromDB.id = new ObjectId(id);
            _contatoFromDB.nome = nome;
            _contatoFromDB.canal = canal;
            _contatoFromDB.valor = valor; 
            _contatoFromDB.obs = obs;
            _resultFromDB = Task.FromResult(_contatoFromDB);
            _repository.Setup(x => x.Get(It.IsAny<string>())).Returns(_resultFromDB);
            _query = new GetContatoDetailQuery(_repository.Object);

            //Act
            var result = await _query.Execute(_str);

            //Assert
            Assert.Equal(id,result.id.ToString());  
            Assert.Equal(nome,result.nome); 
            Assert.Equal(canal,result.canal);
            Assert.Equal(valor,result.valor);
            Assert.Equal(obs,result.obs);              

        }

/*
        [Fact]
        public void TestExecuteSWithoutIdReturnNull()
        {
            //Arrange
            _repository.Setup(x => x.Get(It.IsAny<string>()));
            _query = new GetContatoDetailQuery(_repository.Object);

            //Act
            var result = _query.Execute(_str).Result;

            //Assert
            Assert.Equal(null, result);                

        }
 */
        [Fact]
        public async void TestExecuteShoudReturnWithoutNome()
        {

            //Arrange
            _contatoFromDB = new Contato();
            _contatoFromDB.id = new ObjectId(_str);
            _contatoFromDB.nome = null;
            _contatoFromDB.canal = _str;
            _contatoFromDB.valor = _str; 
            _contatoFromDB.obs = _str;
            _resultFromDB = Task.FromResult(_contatoFromDB);
            _repository.Setup(x => x.Get(It.IsAny<string>())).Returns(_resultFromDB);
            _query = new GetContatoDetailQuery(_repository.Object);

            //Act
            var result = await _query.Execute(_str);

            Assert.Equal(null, result.nome);  

        }

        [Fact]
        public async void TestExecuteShoudReturnWithoutCanal()
        {

            //Arrange
            _contatoFromDB = new Contato();
            _contatoFromDB.id = new ObjectId(_str);
            _contatoFromDB.nome = _str;
            _contatoFromDB.canal = null;
            _contatoFromDB.valor = _str; 
            _contatoFromDB.obs = _str;
            _resultFromDB = Task.FromResult(_contatoFromDB);
            _repository.Setup(x => x.Get(It.IsAny<string>())).Returns(_resultFromDB);
            _query = new GetContatoDetailQuery(_repository.Object);

            //Act
            var result = await _query.Execute(_str);
            
            Assert.Equal(null, result.canal);                    
        }

        [Fact]
        public async void TestExecuteShoudReturnWithoutValor()
        {

            //Arrange
            _contatoFromDB = new Contato();
            _contatoFromDB.id = new ObjectId(_str);
            _contatoFromDB.nome = _str;
            _contatoFromDB.canal = _str;
            _contatoFromDB.valor = null; 
            _contatoFromDB.obs = _str;
            _resultFromDB = Task.FromResult(_contatoFromDB);
            _repository.Setup(x => x.Get(It.IsAny<string>())).Returns(_resultFromDB);
            _query = new GetContatoDetailQuery(_repository.Object);

            //Act
            var reuslt = await _query.Execute(_str);
            
            Assert.Equal(null, reuslt.valor);

        }

        [Fact]
        public async void TestExecuteShoudReturnWithoutObs()
        {
            //Arrange
            _contatoFromDB = new Contato();
            _contatoFromDB.id = new ObjectId(_str);
            _contatoFromDB.nome = _str;
            _contatoFromDB.canal = _str;
            _contatoFromDB.valor = _str; 
            _contatoFromDB.obs = null;
            _resultFromDB = Task.FromResult(_contatoFromDB);
            _repository.Setup(x => x.Get(It.IsAny<string>())).Returns(_resultFromDB);
            _query = new GetContatoDetailQuery(_repository.Object);

            //Act
            var result = await _query.Execute(_str);

            Assert.Equal(null, result.obs);
        }
    }    
}