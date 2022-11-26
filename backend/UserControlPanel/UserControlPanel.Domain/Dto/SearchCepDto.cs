using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace UserControlPanel.Domain.Dto
{
    public class SearchCepDto
    {
        public SearchCepDto()
        {

        }
        [JsonProperty("cep")]
        public string Cep { get; set; }

        [JsonProperty("logradouro")]
        public string Street { get; set; }

        [JsonProperty("complemento")]
        public string Complement { get; set; }

        [JsonProperty("bairro")]
        public string Neighbourhood { get; set; }

        [JsonProperty("localidade")]
        public string City { get; set; }

        [JsonProperty("uf")]
        public string State { get; set; }

        [JsonProperty("ibge")]
        public string Ibge { get; set; }

        [JsonProperty("gia")]
        public string Gia { get; set; }

        [JsonProperty("ddd")]
        public int Ddd { get; set; }

        [JsonProperty("siafi")]
        public string Siafi { get; set; }
    }
}
