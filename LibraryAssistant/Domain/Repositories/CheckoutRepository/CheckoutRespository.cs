using LibraryAssistant.Data;
using LibraryAssistant.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAssistant.Domain.Repositories.CheckoutRepository
{
    public class CheckoutRespository : ICheckoutRespository
    {
        private readonly LibraryAssistantDbContext _context;

        public CheckoutRespository(LibraryAssistantDbContext context)
        {
            _context = context;
        }

        public async Task CheckOutBookAsync(Checkout checkoutInfo)
        {
            await _context.Checkouts.AddAsync(checkoutInfo);
        }
    }
}
