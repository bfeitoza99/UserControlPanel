using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserControlPanel.Domain.Entities.User
{
    public class UserGender : BaseEntity
    {
        public string Description { get; set; }
        public string Initials { get; set; }
    }
}
