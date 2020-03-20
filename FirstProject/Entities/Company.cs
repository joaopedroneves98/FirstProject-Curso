using System;
using System.Collections.Generic;
using System.Text;

namespace FirstProject.Entities {
    class Company : TaxPayer {
        public Company(string name, double anualRent, int numberOfEmployees) : base(name, anualRent) {
            NumberOfEmployees = numberOfEmployees;
        }

        public int NumberOfEmployees { get; set; }

        public override double CalculateTax() {
            double tax = 0.16;
            if (NumberOfEmployees > 10) {
                tax = 0.14;
            }

            return AnualRent * tax;
        }
    }
}
