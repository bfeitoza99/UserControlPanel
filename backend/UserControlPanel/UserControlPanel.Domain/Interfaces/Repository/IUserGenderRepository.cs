using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserControlPanel.Domain.Entities.User;

namespace UserControlPanel.Domain.Interfaces.Repository
{
    public interface IUserGenderRepository
    {
        Task<List<UserGender>> Find();
    }
}
