using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserControlPanel.Domain.Entities.User;

namespace UserControlPanel.Domain.Interfaces.Repository
{
    public interface IUserRepository
    {
        void Save(User user);

        Task<User> FindByCpf(string cpf);
    }
}
