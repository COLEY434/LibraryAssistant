using LibraryAssistant.Domain.Models;
using LibraryAssistant.Resources.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAssistant.Domain.Repositories.BookRepository
{
    public interface IBookRespository
    {
        Task CreateBookAsync(Book bookInfo);

        Task<IEnumerable<Book>> GetBooksAsync();

        Task<Book> GetBookByIdAsync(int id);

        Task<IEnumerable<Book>> SearchBookAsync(BookSearchRequest searchRequest);
    }
}
