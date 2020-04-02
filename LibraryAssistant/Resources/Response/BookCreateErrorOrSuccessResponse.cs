using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAssistant.Resources.Response
{
    public class BookCreateErrorOrSuccessResponse
    {
        public bool Success { get; set; }

        public int Statuscode { get; set; }

        public string ErrorMessage { get; set; }


    }
}
