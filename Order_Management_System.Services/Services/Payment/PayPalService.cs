using Microsoft.Extensions.Options;
using Order_Management_System.CORE.Contracts.Services.Payments;
using Order_Management_System.Services.Services.Payment.PayPal;
using PayPal.Api ;
using PayPalCheckoutSdk.Core;
using PayPalCheckoutSdk.Orders;

namespace Order_Management_System.Services.Services.Payment
{
    public class PayPalService : IPayPalService
    {
        private readonly IOptionsSnapshot<PaypalOptions> _paypalOptions;
        public ClientCredentials clientCredentials ;
        private readonly PayPalHttpClient _Client;
        private readonly PayPalEnvironment _Environment;

        public PayPalService(IOptionsSnapshot<PaypalOptions> paypalOptions)
        {
            _paypalOptions = paypalOptions;
            var clientId = _paypalOptions.Value.ClientID;
            var clientSecret = _paypalOptions.Value.ClientSecret;
            var environment = _paypalOptions.Value.Environment;
            _Environment = environment == "SandBox" ? new SandboxEnvironment(clientId, clientSecret)
                                            : new LiveEnvironment(clientId, clientSecret);
            _Client = new PayPalHttpClient(_Environment);
                
        }

        //public Task<Order> CreatePaymentAsync(Order orderRequest)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<Order> CapturePaymentAsync(string orderId)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
