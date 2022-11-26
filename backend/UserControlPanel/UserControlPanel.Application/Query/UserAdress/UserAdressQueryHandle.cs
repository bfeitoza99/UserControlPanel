using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserControlPanel.Domain.Interfaces.Service;

namespace UserControlPanel.Application.Query.UserAdress
{
    public class UserAdressQueryHandle : IRequestHandler<UserAdressQueryRequest, UserAdressQueryResponse>
    {
        public UserAdressQueryHandle(ISearchCepIntegrationService searchCepIntegrationService, IMapper mapper)
        {
            _searchCepIntegrationService = searchCepIntegrationService;
            _mapper = mapper;
        }

        private readonly ISearchCepIntegrationService _searchCepIntegrationService;
        private readonly IMapper _mapper;

        public async Task<UserAdressQueryResponse> Handle(UserAdressQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var response = new UserAdressQueryResponse();               

                response = _mapper.Map<UserAdressQueryResponse>(await _searchCepIntegrationService.GetAdress(request.Cep));

                return response;
            }
            catch (Exception ex)
            {

                throw new Exception("Ocorreu um erro ao buscar o Endereço, contate um administrador do sistema!");
            }
        }
    }
}
