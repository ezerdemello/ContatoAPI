using AutoMoq;
using ContatoAPI.Application.Contatos.Commands.UpdateContato;
using ContatoAPI.Application.Contatos.Commands.UpdateContato.Rules;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ContatoAPI.Application.Tests.Contatos.Commands.UpdateContato.Rules
{
    public class CheckIfValorIsAnTelefoneOrCelularRuleTests
    {
        private CheckIfValorIsAnTelefoneOrCelularRule _rule;
        private UpdateContatoModel _model;
        private AutoMoqer _mocker;

        public CheckIfValorIsAnTelefoneOrCelularRuleTests()
        {
            _rule = new CheckIfValorIsAnTelefoneOrCelularRule();
            _model = new UpdateContatoModel();
            _mocker = new AutoMoqer();
        }


        [Theory]
        //[InlineData("Celular", "2198169956", false)]
        [InlineData("Celular", "21981699756", true)]
        [InlineData("Telefone", "212706110", false)]
        [InlineData("Telefone", "21270611000", false)]
        [InlineData("Telefone", "2127061105", true)]
        public void TestIsValid(string canal, string valor, bool expected)
        {
            //Assert
            _model.canal = canal;
            _model.valor = valor;

            var command = _mocker.Create<UpdateContatoCommand>();

            //Act
            var result = _rule.IsValid(_model, command);

            Assert.Equal(result, expected);
        }
    }
}
