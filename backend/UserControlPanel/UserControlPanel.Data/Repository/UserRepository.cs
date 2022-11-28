using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserControlPanel.CrossCutting.DependencyInjection;
using UserControlPanel.Domain.Entities.User;
using UserControlPanel.Domain.Interfaces.Repository;

namespace UserControlPanel.Data.Repository
{
    [Injectable(typeof(IUserRepository))]
    public class UserRepository : IUserRepository
    {
        private readonly UserControlPanelContext _context;

        public UserRepository(UserControlPanelContext context)
        {
            _context = context;
        }

        public void Save(User user)
        {
            _context.User.Add(user);
        }  
        
        public async Task<User> FindByCpf(string cpf)
        {
           return await _context.User.FirstOrDefaultAsync(x=> x.Cpf == cpf);
        }
    }
}
