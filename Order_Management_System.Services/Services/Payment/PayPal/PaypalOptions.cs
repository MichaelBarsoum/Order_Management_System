using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order_Management_System.Services.Services.Payment.PayPal
{
    public class PaypalOptions
    {
        private readonly IOptions<PaypalOptions> _paypalOptions;

        public string ClientID { get; set; }
        public string ClientSecret { get; set; }
        public PaypalOptions(IOptions<PaypalOptions> paypalOptions)
        {
            _paypalOptions = paypalOptions;
            ClientID = _paypalOptions.Value.ClientID.ToString();
            ClientSecret = _paypalOptions.Value.ClientSecret.ToString();
        }
    }
}
