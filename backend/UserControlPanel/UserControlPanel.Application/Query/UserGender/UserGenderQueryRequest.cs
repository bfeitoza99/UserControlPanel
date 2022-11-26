using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserControlPanel.Application.Query.UserGender
{
    public class UserGenderQueryRequest : IRequest<UserGenderQueryResponse>
    {
        public UserGenderQueryRequest()
        {

        }
    }
}
