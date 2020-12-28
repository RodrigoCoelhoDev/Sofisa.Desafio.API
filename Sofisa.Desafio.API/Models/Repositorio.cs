using System;

namespace Sofisa.Desafio.API.Models
{
    public class Repositorio
    {
        public int id { get; set; }
        public string name { get; set; }
        public string full_name { get; set; }
        public string description { get; set; }
        public string language { get; set; }
        public DateTime updated_at { get; set; }
    }
}
