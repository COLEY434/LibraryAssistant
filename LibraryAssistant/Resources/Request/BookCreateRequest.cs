using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAssistant.Resources.Request
{
    public class BookCreateRequest
    {
        [Required]
        [MaxLength(30)]
        public string Title { get; set; }

        [Required]
        [MaxLength(30)]
        public string ISBN { get; set; }

        [Required]
        public DateTime Published_Year { get; set; }

        [Required]
        public decimal Cover_Price { get; set; }

    }
}
