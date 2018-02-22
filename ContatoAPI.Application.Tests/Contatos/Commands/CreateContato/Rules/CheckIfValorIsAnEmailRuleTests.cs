using AutoMoq;
using ContatoAPI.Application.Contatos.Commands.CreateContato;
using ContatoAPI.Application.Contatos.Commands.CreateContato.Rules;
using ContatoAPI.Tools.Domain.Notifications.Interfaces;
using Moq;
using System;
using Xunit;

namespace ContatoAPI.Application.Tests.Contatos.Commands.CreateContato.Rules
{
    public class CheckIfValorIsAnEmailRuleTests
    {
        private CheckIfValorIsAnEmailRule _rule;
        private CreateContatoModel _model;
        private AutoMoqer _mocker;

        public CheckIfValorIsAnEmailRuleTests()
        {
            _rule = new CheckIfValorIsAnEmailRule();
            _model = new CreateContatoModel();
            _mocker = new AutoMoqer();
        }

        [Theory]
        [InlineData("E-mail", "teste@email", false)]
        [InlineData("E-mail", "teste", false)]
        [InlineData("E-mail", null, true)]
        [InlineData(null, "E-mail", true)]
        [InlineData(null, null, true)]
        [InlineData("E-mail", "teste@email.com", true)]
        public void TestIsValid(string canal, string valor, bool expected)
        {
            //Assert
            _model.canal = canal;
            _model.valor = valor;

            var command = _mocker.Create<CreateContatoCommand>();

            //Act
            var result = _rule.IsValid(_model, command);

            Assert.Equal(result, expected);
        }

    }

}