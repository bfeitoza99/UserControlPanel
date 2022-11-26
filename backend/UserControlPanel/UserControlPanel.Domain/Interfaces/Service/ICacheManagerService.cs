using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserControlPanel.Domain.Interfaces.Service
{
    public interface ICacheManagerService
    {
         object Get(string key);

        void Set(string key, object value );

    }
}
