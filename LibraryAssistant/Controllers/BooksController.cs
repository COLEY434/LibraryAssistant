using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LibraryAssistant.Domain.Models;
using LibraryAssistant.Extensions;
using LibraryAssistant.Resources.Request;
using LibraryAssistant.Services.BookService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAssistant.Controllers
{
    [Route("api/book")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookservice;
        private readonly IMapper _mapper;
        public BooksController(IBookService bookservice, IMapper mapper)
        {
            _bookservice = bookservice;
            _mapper = mapper;
        }
        
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateBookAsync(BookCreateRequest createRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
                
            }

            var headers = Request.Headers;
            var Username = string.Empty;
            byte Admin = 0;


            if (headers.ContainsKey("Username"))
            {
                if (headers.TryGetValue("Username", out var traceValue))
                {
                    Username = traceValue;                  
                }
            }

            if (headers.ContainsKey("Admin"))
            {
                if(headers.TryGetValue("Admin", out var traceValue2))
                {
                    Admin = Convert.ToByte(traceValue2);
                }
            }

            if (Username != "user")
            {
                return Ok(new {ErrorMessage = "You are not authenticated", StatusCodes = StatusCodes.Status401Unauthorized});
            }

            if(Admin != 1)
            {
               return Ok(new { ErrorMessage = "You are not authorized to register a book", StatusCodes = StatusCodes.Status401Unauthorized });
            }

            var bookInfo = new BookCreateRequestModified
            {
                Title = createRequest.Title,
                ISBN = createRequest.ISBN,
                Cover_Price = createRequest.Cover_Price,
                Published_Year = createRequest.Published_Year,
                Availability_Status = true
            };
            var book = _mapper.Map<BookCreateRequestModified, Book>(bookInfo);
            var result = await _bookservice.AddbookAsync(book);


            return Ok(result);
        }
   
        [HttpGet]
        [Route("get-books")]
        public async Task<IActionResult> GetBooksAsync()
        {
            var Books = await _bookservice.GetBooksAsync();

            return Ok(Books);

        }

        [HttpGet]
        [Route("search")]
        public async Task<IActionResult> SearchBooksAsync(BookSearchRequest searchRequest)
        {
            var Books = await _bookservice.SearchBookAsync(searchRequest);

            return Ok(Books);

        }

        [HttpGet]
        [Route("get-single/{id}")]
        public async Task<IActionResult> GetBooksAsync(int id)
        {
            var Books = await _bookservice.GetBookdetailsAsync(id);

            return Ok(Books);

        }
    }
}