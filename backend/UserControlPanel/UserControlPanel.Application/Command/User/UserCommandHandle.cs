using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserControlPanel.Application.Query.UserAdress;
using UserControlPanel.Domain.Entities.User;
using UserControlPanel.Domain.Interfaces.Repository;

namespace UserControlPanel.Application.Command.User
{
    public class UserCommandHandle : IRequestHandler<UserCommandRequest, UserCommandResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UserCommandHandle(IUserRepository userRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<UserCommandResponse> Handle(UserCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var user = _mapper.Map<Domain.Entities.User.User>(request);

                _userRepository.Save(user);

                await _unitOfWork.Commit();

                return new UserCommandResponse(true, "Usuário adicionado com sucesso!");                
            }
            catch (Exception ex)
            {
                return new UserCommandResponse(false, "Ocorreu um erro ao adicionar o usuário, tente novamente.");
            }
        }
    }
}
