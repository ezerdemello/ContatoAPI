using ContatoAPI.Domain.Common;

using System;
using System.Collections.Generic;
using System.Text;

using MongoDB.Driver;

namespace ContatoAPI.Persistence.Shared
{
    public interface IDatabaseContext
    {
        IMongoCollection<T> Collection<T>() where T : Entity;
    }
}