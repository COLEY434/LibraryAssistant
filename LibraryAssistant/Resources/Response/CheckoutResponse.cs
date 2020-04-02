using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAssistant.Resources.Response
{
    public class CheckoutResponse
    {
        public bool Success { get; set; }

        public int StatusCodes { get; set; }

        public string Message { get; set; }
    }
}
