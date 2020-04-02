using LibraryAssistant.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAssistant.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LibraryAssistantDbContext _context;

        public UnitOfWork(LibraryAssistantDbContext context)
        {
            _context = context;
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
