using ContatoAPI.Application.Contatos.Queries.GetContatoList;
using System;
using Xunit;

namespace ContatoAPI.Application.Tests.Contatos.Queries.GetContatoList
{
    public class GetContatoListFilterTests
    {
        private GetContatoListFilter _filter;
        const int _int = 1;

        public GetContatoListFilterTests()
        {
            _filter = new GetContatoListFilter();
        } 

        [Fact]
        public void TestGetAnsSetPage()
        {
            _filter.page = _int;                
            Assert.Equal(_int, _filter.page);
        }

        [Fact]
        public void TestGetAnsSetSize()
        {
            _filter.size = _int;                
            Assert.Equal(_int, _filter.size);
        }

    }
}