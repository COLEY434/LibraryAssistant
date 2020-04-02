using LibraryAssistant.Data;
using LibraryAssistant.Domain.Models;
using LibraryAssistant.Resources.Request;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAssistant.Domain.Repositories.BookRepository
{
    public class BookRepository : IBookRespository
    {
        private readonly LibraryAssistantDbContext _context;
        public BookRepository(LibraryAssistantDbContext context)
        {
            _context = context;
        }

        public async Task CreateBookAsync(Book bookInfo)
        {
           await _context.Books.AddAsync(bookInfo);
        }

        public async Task<Book> GetBookByIdAsync(int id)
        {
            return await _context.Books.FindAsync(id);
        }
        public async Task<IEnumerable<Book>> GetBooksAsync()
        {
            return await _context.Books.AsNoTracking().OrderBy(x => x.Published_Year).ToListAsync();
        }

        public async Task<IEnumerable<Book>> SearchBookAsync(BookSearchRequest searchRequest)
        {
            return await _context.Books.AsNoTracking().Where(x => x.Title.Contains(searchRequest.Title) || x.ISBN.Contains(searchRequest.ISBN) || x.Availability_Status == searchRequest.Availability).ToListAsync();
        }
    }
}
