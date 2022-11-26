using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserControlPanel.Domain.Entities.User;

namespace UserControlPanel.Application.Command.User
{
    public class UserCommandRequest :IRequest<UserCommandResponse>
    {
        public UserCommandRequest()
        {

        }
        public string Cpf { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string Number { get; set; }
        public string Email { get; set; }       
        public int UserGenderId { get; set; }

        #region Adress
        public string Cep { get; set; }
        public string Street { get; set; }
        public string Complement { get; set; }
        public string Neighbourhood { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Ibge { get; set; }
        public string Gia { get; set; }
        public int Ddd { get; set; }
        public string Siafi { get; set; }

        #endregion

    }
}
