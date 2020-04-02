using LibraryAssistant.Domain.Models;
using LibraryAssistant.Resources.Request;
using LibraryAssistant.Resources.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAssistant.Services.BookService
{
    public interface IBookService
    {
        Task<BookCreateErrorOrSuccessResponse> AddbookAsync(Book bookInfo);

        Task<BookListSuccessORErrorResponse> GetBooksAsync();

        Task<BookListSuccessORErrorResponse> GetBookdetailsAsync(int id);

        Task<BookListSuccessORErrorResponse> SearchBookAsync(BookSearchRequest searchrequest);

    }
}
