using ContatoAPI.Domain.Common;
using MongoDB.Bson;
using System;
using Xunit;

namespace ContatoAPI.Domain.Tests.Common
{
    public class EntityTest
    {

        private ObjectId _id;
        private Entity _entity;

        public EntityTest()
        {
            _id = ObjectId.GenerateNewId();
            _entity = new Entity();
        } 

        [Fact]
        public void TestGetAnsSetId()
        {
            _entity.id = _id;
            Assert.Equal(_id, _entity.id);
        }

    }
}