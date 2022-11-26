using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserControlPanel.CrossCutting.DependencyInjection;
using UserControlPanel.Domain.Interfaces.Repository;
using UserControlPanel.Domain.Interfaces.Service;

namespace UserControlPanel.Data.Repository
{
    [Injectable(typeof(IUnitOfWork))]
    public class UnitOfWork : IUnitOfWork
    {
        private readonly UserControlPanelContext _context;

        public UnitOfWork(UserControlPanelContext context)
        {
            _context = context; 
        }
        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }
    }
}
