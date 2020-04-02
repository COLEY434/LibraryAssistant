using LibraryAssistant.Resources.Request;
using LibraryAssistant.Resources.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAssistant.Services.CheckoutService
{
    public interface ICheckoutService
    {
         Task<CheckoutResponse> CheckoutBooksAsync(CheckoutRequest checkoutRequest, string UserId);
    }
}
