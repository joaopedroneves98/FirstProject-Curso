using System;
using System.Collections.Generic;
using System.Text;

namespace FirstProject.Entities.Interfaces {
    interface IPaymentService {
        double PaymentFee(double value);

        double Tax(double value, int months);
    }
}
