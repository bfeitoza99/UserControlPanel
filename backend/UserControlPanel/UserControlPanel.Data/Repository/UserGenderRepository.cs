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
    [Injectable(typeof(IUserGenderRepository))]
    public class UserGenderRepository :  IUserGenderRepository 
    {
        private readonly UserControlPanelContext _context;

        public UserGenderRepository(UserControlPanelContext context)
        {
            _context = context;
        }

        public async Task<List<UserGender>> Find()
        {
           return await _context.UserGender
                .Where(x=> x.DeletedDate == null)
                .ToListAsync();
        }
        
    }
}
