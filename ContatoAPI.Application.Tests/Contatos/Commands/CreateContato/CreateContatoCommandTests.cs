using Xunit;
using AutoMoq;
using ContatoAPI.Application.Contatos.Commands.CreateContato;
using System;
using ContatoAPI.Application.Interfaces;
using ContatoAPI.Application.Contatos.Commands.CreateContato.Factory;
using ContatoAPI.Application.Contatos.Commands.CreateContato.Rules;
using Moq;
using ContatoAPI.Tools.Domain.Notifications.Interfaces;
using System.Collections.Generic;
using ContatoAPI.Domain.Contatos;

namespace ContatoAPI.Application.Tests.Contatos.Commands.CreateContato
{

    public class CreateContatoCommandTests
    {
        private AutoMoqer _mocker;
        private Contato _entity;
        private CreateContatoModel _model;
        private CreateContatoCommand _command;

        const string _str = "teste";


        public CreateContatoCommandTests()
        {
            _mocker = new AutoMoqer();
            _entity = new Contato { canal = _str, nome = _str, valor = _str, obs = _str };
            _model = new CreateContatoModel();

        }


        [Fact]
        public void TestExecuteWithoutCanalNullSholdNotInvokeAllMethods()
        {
            //Arrange
            _model.canal = null;
            _model.nome = _str;
            _model.valor = _str;
            _model.obs = _str;

            _mocker.GetMock<IContatoRepository>();

            _mocker.GetMock<IContatoFactory>();

            _mocker.GetMock<ICreateContatoRule>()
                .Setup(x => x.IsValid(It.IsAny<CreateContatoModel>(), It.IsAny<ICommand>()))
                .Returns(true);

            _command = _command = new CreateContatoCommand(
                    _mocker.Resolve<IContatoRepository>(),
                    _mocker.Resolve<IContatoFactory>(),
                    new List<ICreateContatoRule> { _mocker.Resolve<ICreateContatoRule>() }
                );

            //Act
            _command.Execute(_model).Wait();

            //Assert
            _mocker.Verify<IContatoFactory>(x => x.Create(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()), Times.Never(), "Não foi possivel completar a execução");
            _mocker.Verify<IContatoRepository>(x => x.Add(It.IsAny<Contato>()), Times.Never(), "Não foi possivel completar a execução");

        }

        [Fact]
        public void TestExecuteWithNomeNullSholdNotInvokeAllMethods()
        {
            //Arrange
            _model.canal = _str;
            _model.nome = null;
            _model.valor = _str;
            _model.obs = _str;

            _mocker.GetMock<IContatoRepository>();

            _mocker.GetMock<IContatoFactory>();

            _mocker.GetMock<ICreateContatoRule>()
                .Setup(x => x.IsValid(It.IsAny<CreateContatoModel>(), It.IsAny<ICommand>()))
                .Returns(true);

            _command = _command = new CreateContatoCommand(
                    _mocker.Resolve<IContatoRepository>(),
                    _mocker.Resolve<IContatoFactory>(),
                    new List<ICreateContatoRule> { _mocker.Resolve<ICreateContatoRule>() }
                );

            //Act
            _command.Execute(_model).Wait();

            //Assert
            _mocker.Verify<IContatoFactory>(x => x.Create(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()), Times.Never(), "Não foi possivel completar a execução");
            _mocker.Verify<IContatoRepository>(x => x.Add(It.IsAny<Contato>()) , Times.Never(), "Não foi possivel completar a execução");

        }

        [Fact]
        public void TestExecuteWithValorNullSholdNotInvokeAllMethods()
        {
            //Arrange
            _model.canal = _str;
            _model.nome = _str;
            _model.valor = null;
            _model.obs = _str;

            _mocker.GetMock<IContatoRepository>();

            _mocker.GetMock<IContatoFactory>();

            _mocker.GetMock<ICreateContatoRule>()
                .Setup(x => x.IsValid(It.IsAny<CreateContatoModel>(), It.IsAny<ICommand>()))
                .Returns(true);

            _command = _command = new CreateContatoCommand(
                    _mocker.Resolve<IContatoRepository>(),
                    _mocker.Resolve<IContatoFactory>(),
                    new List<ICreateContatoRule> { _mocker.Resolve<ICreateContatoRule>() }
                );

            //Act
            _command.Execute(_model).Wait();

            //Assert
            _mocker.Verify<IContatoFactory>(x => x.Create(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()), Times.Never(), "Não foi possivel completar a execução");
            _mocker.Verify<IContatoRepository>(x => x.Add(It.IsAny<Contato>()), Times.Never(), "Não foi possivel completar a execução");

        }

        [Fact]
        public void TestExecuteWithAllValuesOkAndOneRuleFalseSholdNotInvokeAllMethods()
        {
            //Arrange
            _model.canal = _str;
            _model.nome = _str;
            _model.valor = _str;
            _model.obs = _str;

            _mocker.GetMock<ICreateContatoRule>()
                .Setup(x => x.IsValid(It.IsAny<CreateContatoModel>(), It.IsAny<ICommand>()))
                .Returns(false);

            _mocker.GetMock<IContatoFactory>()
                .Setup(x => x.Create(_str, _str, _str, _str)).Returns(_entity);

            _mocker.GetMock<IContatoRepository>();
            
            _command = _command = new CreateContatoCommand(
                    _mocker.Resolve<IContatoRepository>(),
                    _mocker.Resolve<IContatoFactory>(),
                    new List<ICreateContatoRule> { _mocker.Resolve<ICreateContatoRule>() }
                );

            //Act
            _command.Execute(_model).Wait();

            //Assert
            _mocker.Verify<IContatoFactory>(x => x.Create(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()), Times.Never(), "Não foi possivel completar a execução");
            _mocker.Verify<IContatoRepository>(x => x.Add(It.IsAny<Contato>()), Times.Never(), "Não foi possivel completar a execução");

        }

        [Fact]
        public void TestExecuteWithAllValuesAndRulesOkSholdInvokeAllMethods()
        {
            //Arrange
            _model.canal = _str;
            _model.nome = _str;
            _model.valor = _str;
            _model.obs = _str;

            _mocker.GetMock<ICreateContatoRule>()
                .Setup(x => x.IsValid(It.IsAny<CreateContatoModel>(), It.IsAny<CreateContatoCommand>()))
                .Returns(true);

            _mocker.GetMock<IContatoFactory>()
                .Setup(x => x.Create(_str, _str, _str, _str)).Returns(_entity);

            _mocker.GetMock<IContatoRepository>();
                
            _command = _command = new CreateContatoCommand(
                    _mocker.Resolve<IContatoRepository>(),
                    _mocker.Resolve<IContatoFactory>(),
                    new List<ICreateContatoRule> { _mocker.Resolve<ICreateContatoRule>() }
                );

            //Act
            _command.Execute(_model).Wait();

            //Assert
            _mocker.Verify<IContatoFactory>(x => x.Create(_str, _str, _str, _str), Times.Once(), "");
            _mocker.Verify<IContatoRepository>(x => x.Add(It.IsAny<Contato>()), Times.Once(), "");

        }

    }

}