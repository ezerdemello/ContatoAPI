using AutoMoq;
using ContatoAPI.Application.Contatos.Commands.UpdateContato;
using ContatoAPI.Application.Contatos.Commands.UpdateContato.Rules;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ContatoAPI.Application.Tests.Contatos.Commands.UpdateContato.Rules
{
    public class CheckIfCanalIsValidRuleTests
    {

        private AutoMoqer _mocker;
        private UpdateContatoModel _model;
        private CheckIfCanalIsValidRule _rule;
        private UpdateContatoCommand _command;

        public CheckIfCanalIsValidRuleTests()
        {

            _mocker = new AutoMoqer();
            _model = new UpdateContatoModel();
            _rule = new CheckIfCanalIsValidRule();
            _command = _mocker.Create<UpdateContatoCommand>();

        }

        [Theory]
        [InlineData(null, true)]
        [InlineData("", true)]
        [InlineData("Celular", true)]
        [InlineData("E-mail", true)]
        [InlineData("Telefone", true)]
        [InlineData("fadsfade", false)]
        public void TestIsValid(string canal, bool expected)
        {
            //Arrange
            _model.canal = canal;

            //Act
            var result = _rule.IsValid(_model, _command);

            Assert.Equal(result, expected);

        }
    }
}
