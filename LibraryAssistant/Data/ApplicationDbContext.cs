using System;
using System.Collections.Generic;
using System.Text;
using LibraryAssistant.Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LibraryAssistant.Data
{
    public class LibraryAssistantDbContext : IdentityDbContext
    {
        public LibraryAssistantDbContext(DbContextOptions<LibraryAssistantDbContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }

        public DbSet<Checkout> Checkouts { get; set; }
    }
}
