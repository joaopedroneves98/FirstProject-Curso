using FirstProject.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FirstProject.Entities.Services {
    class ContractService {

        private IPaymentService paymentService;

        public ContractService(IPaymentService paymentService) {
            this.paymentService = paymentService;
        }

        public void ProcessContract(Contract contract, int months) {
            double baseValue = contract.TotalValue / months;
            for (int i = 0; i < months; i++) {
                DateTime newDate = contract.Date.AddMonths(i);
                double tax = baseValue + paymentService.Tax(baseValue, i);
                double finalQuota = tax + paymentService.PaymentFee(tax);
                Installment installment = new Installment(newDate, finalQuota);
                contract.AddInstallments(installment);
            }
        }
    }
}
