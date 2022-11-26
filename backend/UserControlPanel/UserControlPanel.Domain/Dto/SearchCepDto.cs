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
        [JsonPropertyName("")]
        public string Cep { get; set; }

        [JsonPropertyName("")]
        public string Street { get; set; }

        [JsonPropertyName("")]
        public string Neighbourhood { get; set; }

        [JsonPropertyName("")]
        public string City { get; set; }

        [JsonPropertyName("")]
        public string State { get; set; }

        [JsonPropertyName("")]
        public string Ibge { get; set; }

        [JsonPropertyName("")]
        public string Gia { get; set; }

        [JsonPropertyName("")]
        public int Ddd { get; set; }

        [JsonPropertyName("")]
        public string Siafi { get; set; }
    }
}
