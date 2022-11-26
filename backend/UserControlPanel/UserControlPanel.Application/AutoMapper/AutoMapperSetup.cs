using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserControlPanel.Application.Command.User;
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

            #region CommandToEntity 
            CreateMap<UserCommandRequest, User>()
                .ForPath(x=> x.UserAdress.Cep, y=> y.MapFrom(z=> z.Cep))
                .ForPath(x=> x.UserAdress.Street, y=> y.MapFrom(z=> z.Street))
                .ForPath(x=> x.UserAdress.Complement, y=> y.MapFrom(z=> z.Complement))
                .ForPath(x=> x.UserAdress.Neighbourhood, y=> y.MapFrom(z=> z.Neighbourhood))
                .ForPath(x=> x.UserAdress.City, y=> y.MapFrom(z=> z.City))
                .ForPath(x=> x.UserAdress.State, y=> y.MapFrom(z=> z.State))
                .ForPath(x=> x.UserAdress.Ibge, y=> y.MapFrom(z=> z.Ibge))
                .ForPath(x=> x.UserAdress.Gia, y=> y.MapFrom(z=> z.Gia))
                .ForPath(x=> x.UserAdress.Ddd, y=> y.MapFrom(z=> z.Ddd))
                .ForPath(x=> x.UserAdress.Siafi, y=> y.MapFrom(z=> z.Siafi));

            CreateMap<UserCommandRequest, UserAdress>();
            #endregion
        
        }
    }
}
