using ContatoAPI.Domain.Common;
using ContatoAPI.Domain.Contatos;

using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

using Microsoft.Extensions.Options;

using MongoDB.Driver;

using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;


namespace ContatoAPI.Persistence.Shared
{
    public class DatabaseContext : ContatoAPI.Persistence.Shared.IDatabaseContext
    {

        private readonly IMongoClient _client;
        private readonly IMongoDatabase _database;
        
        private readonly Settings _settings;

        public DatabaseContext(IOptions<Settings> settings)
        {

            _settings = settings.Value;

            try
            {
                // "mongodb://localhost:20000"
                //_client = new MongoClient(Environment.GetEnvironmentVariable("MONGO_HOST"));
                // "Seguros"
                //_database = _client.GetDatabase(Environment.GetEnvironmentVariable("MONGO_DATABASE"));

                _client = new MongoClient(_settings.ConnectionString);
                _database = _client.GetDatabase(_settings.Database);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        } 

        MongoDB.Driver.IMongoCollection<T> IDatabaseContext.Collection<T>()
        {
            return _database.GetCollection<T>(typeof(T).Name);
        }

    }        
}