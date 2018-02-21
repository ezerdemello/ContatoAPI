using System;

namespace  ContatoAPI.Application.Contatos.Queries.GetContatoList
{

    public class GetContatoListItemModel 
    {
        
        public GetContatoListItemModel()
        {
            
        }

        public string id { get; set; }
        public string nome { get; set; }

        public string canal { get; set; }

        public string valor { get; set; }

        public string obs { get; set; }

    }

}