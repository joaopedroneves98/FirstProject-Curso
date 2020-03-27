using FirstProject.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FirstProject.Entities {
    class PayPalService : IPaymentService {
        public double PaymentFee(double value) {
            return value * 0.02;
        }

        public double Tax(double value, int months) {
            return value * 0.01 * months;
        }
    }
}
