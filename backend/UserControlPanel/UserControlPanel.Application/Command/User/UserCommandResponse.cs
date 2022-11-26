using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserControlPanel.Application.Command.User
{
    public class UserCommandResponse
    {
        public UserCommandResponse(bool isSucess, string message)
        {
            IsSucess = isSucess;
            Message = message;
        }

        public bool IsSucess { get; set; }
        public string Message { get; set; }
    }
}
