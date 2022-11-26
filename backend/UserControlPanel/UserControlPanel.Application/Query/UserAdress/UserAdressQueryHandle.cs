using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserControlPanel.Domain.Interfaces;

namespace UserControlPanel.Application.Query.UserAdress
{
    public class UserAdressQueryHandle : IRequestHandler<UserAdressQueryRequest, UserAdressQueryResponse>
    {
        public UserAdressQueryHandle(ISearchCepIntegrationService searchCepIntegrationService)
        {
            _searchCepIntegrationService = searchCepIntegrationService;
        }

        private readonly ISearchCepIntegrationService _searchCepIntegrationService;
        
        public async Task<UserAdressQueryResponse> Handle(UserAdressQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var response = new UserAdressQueryResponse();

                var responseIntegration = await _searchCepIntegrationService.GetAdress(request.Cep);

                return response;
            }
            catch (Exception)
            {

                throw new Exception("Ocorreu um erro ao buscar o Enderaço, contate um administrador do sistema!");
            }
        }
    }
}
