using AutoMoq;
using ContatoAPI.Application.Contatos.Commands.CreateContato;
using ContatoAPI.Application.Contatos.Commands.CreateContato.Rules;
using ContatoAPI.Tools.Domain.Notifications.Interfaces;
using ContatoAPI.Tools.Domain.Notifications.Model;
using Moq;
using System;
using Xunit;

namespace ContatoAPI.Application.Tests.Contatos.Commands.CreateContato.Rules
{
    public class CheckIfCanalIsValidRuleTests
    {
        private CheckIfCanalIsValidRule _rule;
        private CreateContatoModel _model;
        private AutoMoqer _mocker; 


        public CheckIfCanalIsValidRuleTests()
        {
            _rule = new CheckIfCanalIsValidRule();
            _model = new CreateContatoModel();
            _mocker = new AutoMoqer();
        }

        [Theory]
        [InlineData("Celular", true)]
        [InlineData("E-mail", true)]
        [InlineData("Telefone", true)]
        [InlineData("Telefonefdsfs", false)]
        public void TestIsValid(string canal, bool expected)
        {
            _model.canal = canal;

            var command = _mocker.Create<CreateContatoCommand>();

            _rule = new CheckIfCanalIsValidRule();

            //Act
            var result =  _rule.IsValid(_model, command);

            Assert.Equal(result, expected);

        }

    }

}