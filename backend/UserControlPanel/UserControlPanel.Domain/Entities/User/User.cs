using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace UserControlPanel.Domain.Entities.User
{
    public class User : BaseEntity
    {
        public User()
        {

        }
        public string Cpf { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string Number { get; set; }
        public string Email { get; set; }
        public int UserAdressId { get; set; }
        public UserAdress UserAdress { get; set; }
        public int UserGenderId { get; set; }
        public UserGender UserGender { get; set; }
        
    }
}
