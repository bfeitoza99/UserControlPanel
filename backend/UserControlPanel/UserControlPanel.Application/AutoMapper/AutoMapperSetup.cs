using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserControlPanel.Application.Query.UserAdress;
using UserControlPanel.Domain.Dto;

namespace UserControlPanel.Application.AutoMapper
{
    public class AutoMapperSetup : Profile
    {
        public AutoMapperSetup()
        {

            #region DtoToHandleResponse
            CreateMap<SearchCepDto, UserAdressQueryResponse>();

            #endregion
        }
    }
}
