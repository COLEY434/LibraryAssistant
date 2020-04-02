using AutoMapper;
using LibraryAssistant.Domain.Models;
using LibraryAssistant.Domain.Repositories.BookRepository;
using LibraryAssistant.Resources.Request;
using LibraryAssistant.Resources.Response;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAssistant.Services.BookService
{
    public class BookService : IBookService
    {
        private readonly IBookRespository _bookRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public BookService(IBookRespository bookRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BookCreateErrorOrSuccessResponse> AddbookAsync(Book bookInfo)
        {
            try
            {
                await _bookRepository.CreateBookAsync(bookInfo);
                await _unitOfWork.CompleteAsync();

                return new BookCreateErrorOrSuccessResponse
                {
                    Success = true,
                    Statuscode = StatusCodes.Status201Created,
                    ErrorMessage = ""
                };
            }
            catch (Exception ex)
            {
                return new BookCreateErrorOrSuccessResponse
                {
                    Success = false,
                    Statuscode = StatusCodes.Status500InternalServerError,
                    ErrorMessage = $"An error occurred while creating a new book: {ex.Message}"
                };
            }
        }
    
        public async Task<BookListSuccessORErrorResponse> GetBooksAsync()
        {        
            try
            {
                var result = await _bookRepository.GetBooksAsync();

                if (result.Count() == 0)
                {
                    return new BookListSuccessORErrorResponse
                    {
                        Success = true,
                        StatusCodes = StatusCodes.Status200OK,
                        Message = "No books found"
                    };
                }

                var BookDetails = _mapper.Map<IEnumerable<Book>, IEnumerable<BookListResponse>>(result);
                return new BookListSuccessORErrorResponse
                {
                    Success = true,
                    StatusCodes = StatusCodes.Status200OK,
                    Books = BookDetails
                };
            }
            catch (Exception ex)
            {
                return new BookListSuccessORErrorResponse
                {
                    Success = false,
                    StatusCodes = StatusCodes.Status500InternalServerError,
                    Message = ex.Message
                };
            }
        }

        public async Task<BookListSuccessORErrorResponse> GetBookdetailsAsync(int id)
        {
            try
            {
                var result = await _bookRepository.GetBookByIdAsync(id);

                if (result == null)
                {
                    return new BookListSuccessORErrorResponse
                    {
                        Success = true,
                        StatusCodes = StatusCodes.Status200OK,
                        Message = "Not found"
                    };
                }

                var BookDetails = _mapper.Map<Book, BookListResponse>(result);
                return new BookListSuccessORErrorResponse
                {
                    Success = true,
                    StatusCodes = StatusCodes.Status200OK,
                    Books = new List<BookListResponse> { BookDetails }
                };
            }
            catch (Exception ex)
            {
                return new BookListSuccessORErrorResponse
                {
                    Success = false,
                    StatusCodes = StatusCodes.Status500InternalServerError,
                    Message = ex.Message
                };
            }
        }

        public async Task<BookListSuccessORErrorResponse> SearchBookAsync(BookSearchRequest searchRequest)
        {
            try
            {
                var result = await _bookRepository.SearchBookAsync(searchRequest);

                if (result.Count() == 0)
                {
                    return new BookListSuccessORErrorResponse
                    {
                        Success = true,
                        StatusCodes = StatusCodes.Status200OK,
                        Message = "No books found"
                    };
                }

                var BookDetails = _mapper.Map<IEnumerable<Book>, IEnumerable<BookListResponse>>(result);
                return new BookListSuccessORErrorResponse
                {
                    Success = true,
                    StatusCodes = StatusCodes.Status200OK,
                    Books = BookDetails
                };
            }
            catch (Exception ex)
            {
                return new BookListSuccessORErrorResponse
                {
                    Success = false,
                    StatusCodes = StatusCodes.Status500InternalServerError,
                    Message = ex.Message
                };
            }
        }

    }
}
