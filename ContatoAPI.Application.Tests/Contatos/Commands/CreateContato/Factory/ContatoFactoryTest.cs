using ContatoAPI.Application.Contatos.Commands.CreateContato.Factory;
using System;
using Xunit;

namespace ContatoAPI.Application.Tests.Contatos.Commands.CreateContato.Factory
{
    public class ContatoFactoryTests
    {


        const string _str = "teste";

        private ContatoFactory _factory;

        public ContatoFactoryTests()
        {
            _factory = new ContatoFactory();
        }

        [Theory]
        [InlineData("nome", "canal", "valor", "obs")]
        [InlineData(null, "canal", "valor", "obs")]
        [InlineData("nome", null, "valor", "obs")]
        [InlineData("nome", "canal", null, "obs")]
        [InlineData("nome", "canal", "valor", null)]
        [InlineData(null, null, null, null)]
        //[Fact]
        //string nome, string canal, string valor, string obs
        public void TestCreateWithoutAnyValue(string nome, string canal,string valor,string obs)
        {
            //Act
            var result = _factory.Create(nome,canal,valor,obs);
            
            //Assert
            Assert.NotNull(result.id);
            Assert.Equal(result.nome, nome);
            Assert.Equal(result.canal, canal);
            Assert.Equal(result.valor, valor);
            Assert.Equal(result.obs, obs);
         
        }

    }

    


}