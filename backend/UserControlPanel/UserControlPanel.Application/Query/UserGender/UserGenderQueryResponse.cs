using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserControlPanel.Application.Query.UserGender
{
    public class UserGenderQueryResponse
    {
        public UserGenderQueryResponse()
        {

        }

        public List<UserGenderResponse> UserGenders { get; set; }


    }

    public class UserGenderResponse
    {
        public UserGenderResponse()
        {

        }
        public int Id { get; set; }
        public string Description { get; set; }
        public string Initials { get; set; }
    }
}
