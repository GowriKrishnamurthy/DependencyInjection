using System;
using System.Collections.Generic;
using System.Text;

namespace DependencyInjection
{
    public class PaymentService
    {
        public void ChargeCreditCard(string creditCardNumber, string expiryDate)
        {
            if (creditCardNumber == null) throw new ArgumentNullException("Invalid credit card");
            if (expiryDate == null) throw new ArgumentNullException("Invalid expiry date");
        }
    }
}
