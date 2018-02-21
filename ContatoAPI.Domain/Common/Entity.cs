using System;
using MongoDB.Bson;

namespace ContatoAPI.Domain.Common
{


    public class Entity
    {
        public Entity()
        {
            
        }

        public ObjectId id { get; set; }

    }

}
