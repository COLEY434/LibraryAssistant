using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAssistant.Resources.Request
{
    public class BookCreateRequestModified
    {
        public string Title { get; set; }

        public string ISBN { get; set; }

        public DateTime Published_Year { get; set; }

        public decimal Cover_Price { get; set; }

        public bool Availability_Status { get; set; }
    }
}
