using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Application.Responses
{
    public class LoginResponse : BaseResponse
    {
        public List<Claim>? Claims { get; set; }
    }
}
