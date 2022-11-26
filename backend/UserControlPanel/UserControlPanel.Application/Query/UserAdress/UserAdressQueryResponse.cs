﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserControlPanel.Application.Query.UserAdress
{
    public class UserAdressQueryResponse
    {
        public UserAdressQueryResponse()
        {

        }
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
    }
}
