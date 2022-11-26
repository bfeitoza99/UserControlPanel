using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserControlPanel.Application.Query.UserAdress;
using UserControlPanel.Application.Query.UserGender;
using UserControlPanel.Domain.Dto;
using UserControlPanel.Domain.Entities.User;

namespace UserControlPanel.Application.AutoMapper
{
    public class AutoMapperSetup : Profile
    {
        public AutoMapperSetup()
        {

            #region DtoToHandleResponse
            CreateMap<SearchCepDto, UserAdressQueryResponse>();
            #endregion

            #region EntityToCommand 
            CreateMap<UserGender, UserGenderResponse>();
            #endregion
        }
    }
}
