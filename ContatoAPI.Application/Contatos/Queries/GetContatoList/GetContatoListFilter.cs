using System;

namespace  ContatoAPI.Application.Contatos.Queries.GetContatoList
{

    public class GetContatoListFilter 
    {
        
        public GetContatoListFilter()
        {
            
        }


        public int page { get; set; }

        public int size { get; set; }

    }

}