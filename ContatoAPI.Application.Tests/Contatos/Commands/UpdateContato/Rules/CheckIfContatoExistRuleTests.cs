using AutoMoq;
using ContatoAPI.Application.Contatos.Commands.UpdateContato;
using ContatoAPI.Application.Contatos.Commands.UpdateContato.Rules;
using ContatoAPI.Application.Interfaces;
using ContatoAPI.Domain.Contatos;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ContatoAPI.Application.Tests.Contatos.Commands.UpdateContato.Rules
{
    public class CheckIfContatoExistRuleTests
    {
        private AutoMoqer _mocker;
        private UpdateContatoModel _model;
        private CheckIfContatoExistRule _rule;
        private UpdateContatoCommand _command;

        const string _str = "teste";

        public CheckIfContatoExistRuleTests()
        {

            _mocker = new AutoMoqer();
            _model = new UpdateContatoModel();
            _command = _mocker.Create<UpdateContatoCommand>();

        }

        [Fact]
        public void TestIsValidWithNotExistItemShouldReturTrue()
        {
            //Arrange
            _model.id = _str;

            Contato retorno = null;
            Task<Contato> _task = Task.FromResult<Contato>(retorno);

            _mocker.GetMock<IContatoRepository>()
                .Setup(x => x.Get(It.IsAny<string>())).Returns(_task);

            _rule = _mocker.Create<CheckIfContatoExistRule>();

            //Act
            var result = _rule.IsValid(_model, _command);

            //Assert
            Assert.False(result);

        }

        [Fact]
        public void TestIsValidWithNotExistItemShouldReturFalse()
        {
            //Arrange
            _model.id = _str;

            Contato retorno = new Contato();
            Task<Contato> _task = Task.FromResult<Contato>(retorno);

            _mocker.GetMock<IContatoRepository>()
                .Setup(x => x.Get(It.IsAny<string>())).Returns(_task);

            _rule = _mocker.Create<CheckIfContatoExistRule>();

            //Act
            var result = _rule.IsValid(_model, _command);

            //Assert
            Assert.True(result);

        }


    }
}
