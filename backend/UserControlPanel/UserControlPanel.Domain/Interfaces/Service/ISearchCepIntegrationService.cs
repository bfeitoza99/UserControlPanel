using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserControlPanel.Domain.Dto;

namespace UserControlPanel.Domain.Interfaces.Service
{
    public interface ISearchCepIntegrationService
    {
        Task<SearchCepDto> GetAdress(string cep);
    }
}
