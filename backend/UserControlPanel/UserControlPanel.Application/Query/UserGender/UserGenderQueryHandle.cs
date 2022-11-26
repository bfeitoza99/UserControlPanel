using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserControlPanel.Application.Query.UserAdress;
using UserControlPanel.Domain.Interfaces.Repository;

namespace UserControlPanel.Application.Query.UserGender
{
    public class UserGenderQueryHandle : IRequestHandler<UserGenderQueryRequest, UserGenderQueryResponse>
    {
        private readonly IUserGenderRepository _userGenderRepository;
        private readonly IMapper _mapper;
        public UserGenderQueryHandle(IUserGenderRepository userGenderRepository, IMapper mapper)
        {
            _userGenderRepository = userGenderRepository;
            _mapper = mapper;
        }
        public async Task<UserGenderQueryResponse> Handle(UserGenderQueryRequest request, CancellationToken cancellationToken)
        {
            var response = new UserGenderQueryResponse();

            var genders = await _userGenderRepository.Find();

            response.UserGenders = _mapper.Map<List<UserGenderResponse>>(genders);

            return response;
        }
    }
}
