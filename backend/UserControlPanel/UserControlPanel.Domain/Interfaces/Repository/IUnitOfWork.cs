using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserControlPanel.Domain.Interfaces.Repository
{
    public interface IUnitOfWork
    {
        Task Commit();
    }
}
