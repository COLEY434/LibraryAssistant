using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAssistant.Resources.Response
{
    public class AuthenticationResultResponse
    {
        public bool Success { get; set; }

        public int StatusCodes { get; set; }

        public string Token { get; set; }

        public IEnumerable<string> ErrorMessages { get; set; }
    }
}
