using System;


namespace ContatoAPI.Application.Contatos.Queries.GetContatoDetail
{
    public class GetContatoDetailModel
    {
        public GetContatoDetailModel()
        {
            
        }

        public string id { get; set; }
        public string nome { get; set; }
        public string canal { get; set; }
        public string valor { get; set; }
        public string obs { get; set; }
        
    }

}