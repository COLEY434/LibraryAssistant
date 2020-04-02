using LibraryAssistant.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAssistant.Domain.Repositories.CheckoutRepository
{
    public interface ICheckoutRespository
    {
        Task CheckOutBookAsync(Checkout checkoutInfo);
    }
}
