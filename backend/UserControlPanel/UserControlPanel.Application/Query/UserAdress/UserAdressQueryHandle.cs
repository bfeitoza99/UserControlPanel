using AutoMapper;
using MediatR;
using Newtonsoft.Json;
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
        public UserAdressQueryHandle(ISearchCepIntegrationService searchCepIntegrationService, IMapper mapper, ICacheManagerService cacheManager)
        {
            _searchCepIntegrationService = searchCepIntegrationService;
            _mapper = mapper;
            _cacheManager = cacheManager;
        }

        private readonly ISearchCepIntegrationService _searchCepIntegrationService;
        private readonly IMapper _mapper;
        private readonly ICacheManagerService _cacheManager;

        public async Task<UserAdressQueryResponse> Handle(UserAdressQueryRequest request,  CancellationToken cancellationToken)
        {
            try
            {
                var response = new UserAdressQueryResponse();


                var cacheAddres = _cacheManager.Get(request.Cep);

                if (cacheAddres != null)
                    return cacheAddres as UserAdressQueryResponse;


                response = _mapper.Map<UserAdressQueryResponse>(await _searchCepIntegrationService.GetAdress(request.Cep));
                _cacheManager.Set(request.Cep,response);

                return response;
            }
            catch (Exception ex)
            {

                throw new Exception("Endereço não encontrado, verifique CEP digitado!");
            }
        }
    }
}
