using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Application.Responses
{
    public class BaseResponse
    {
        public BaseResponse()
        {
            Success = true;
            Message = string.Empty;
            ValidationErrors = new List<string>();
        }

        public bool Success { get; set; }
        public string Message { get; set; }
        public List<string> ValidationErrors { get; set; }
    }
}
