using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace ContatoAPI.Service.Util
{
    public class DBConfiguration
    {
        private string _MONGO_HOST;
        public string MONGO_HOST { get { return _MONGO_HOST; } set { _MONGO_HOST = value; } }
    }
}
