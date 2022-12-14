using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using UserControlPanel.CrossCutting.DependencyInjection;
using UserControlPanel.Domain.Dto;
using UserControlPanel.Domain.HttpClientInstance;
using UserControlPanel.Domain.Interfaces.Service;

namespace UserControlPanel.Application.Service
{
    [Injectable(typeof(ISearchCepIntegrationService))]
    public class SearchCepIntegrationService : ISearchCepIntegrationService
    {


        public async Task<SearchCepDto> GetAdress(string cep)
        {
            try
            {
                HttpResponseMessage response = new HttpResponseMessage();

                using (var client = HttpClientInstance.GetHttpClientInstance())
                {
                    response = await client.GetAsync($"https://viacep.com.br/ws/{cep}/json/");
                }

                return JsonConvert.DeserializeObject<SearchCepDto>(response.Content.ReadAsStringAsync().Result);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            
        }        
    }
}
