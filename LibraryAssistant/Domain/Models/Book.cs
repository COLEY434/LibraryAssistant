using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAssistant.Domain.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Title { get; set; }

        [Required]
        [MaxLength(30)]
        public string ISBN { get; set; }

        public DateTime Published_Year { get; set; }

        public decimal Cover_Price { get; set; }

        public bool Availability_Status { get; set; }
    }
}
