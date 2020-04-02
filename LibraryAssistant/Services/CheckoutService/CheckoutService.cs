using AutoMapper;
using LibraryAssistant.Data;
using LibraryAssistant.Domain.Models;
using LibraryAssistant.Domain.Repositories.BookRepository;
using LibraryAssistant.Domain.Repositories.CheckoutRepository;
using LibraryAssistant.Resources.Request;
using LibraryAssistant.Resources.Response;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace LibraryAssistant.Services.CheckoutService
{
    public class CheckoutService : ICheckoutService
    {
        private readonly LibraryAssistantDbContext _context;
        private readonly IBookRespository _bookRespository;
        private readonly ICheckoutRespository _checkOutRepository;
        private readonly IUnitOfWork _unitOfWork;
      
        public CheckoutService(ICheckoutRespository checkOutRepository, IUnitOfWork unitOfWork, LibraryAssistantDbContext context, IBookRespository bookRespository)
        {
            _checkOutRepository = checkOutRepository;
            _unitOfWork = unitOfWork;
            _context = context;
            _bookRespository = bookRespository;
        }

        public async Task<CheckoutResponse> CheckoutBooksAsync(CheckoutRequest checkoutRequest, string UserId)
        {
            var CheckOut_Date = DateTime.Now;
            var ReturnDate = CheckOut_Date;
         
            for (int i = 1; i <= 10; i++)
            {
                if (ReturnDate.DayOfWeek == DayOfWeek.Saturday)
                {
                    ReturnDate = ReturnDate.AddDays(2);
                }

                ReturnDate = ReturnDate.AddDays(1);
            }

            var CheckOutInfo = new Checkout
            {
                FullName = checkoutRequest.FullName,
                Email = checkoutRequest.Email,
                PhoneNumber = checkoutRequest.PhoneNumber,
                NIN = checkoutRequest.NIN,
                CheckOut_Date = CheckOut_Date,
                Return_Date = ReturnDate,
                UserId = UserId,
                BookId = checkoutRequest.BookId
            };

            
            try
            {
                var book = await _context.Books.FindAsync(checkoutRequest.BookId);

                book.Availability_Status = false;

                _context.Books.Update(book);
                await _checkOutRepository.CheckOutBookAsync(CheckOutInfo);
                await _unitOfWork.CompleteAsync();

                return new CheckoutResponse
                {
                    StatusCodes = StatusCodes.Status200OK,
                    Success = true,
                    Message = "Book checked out successfully"
                };
            }
            catch (Exception ex)
            {
                return new CheckoutResponse
                {
                    StatusCodes = StatusCodes.Status500InternalServerError,
                    Success = false,
                    Message = ex.Message
                };
            }
            
         }
    }
}
