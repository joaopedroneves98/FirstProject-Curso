using System;
using System.Collections.Generic;
using System.Text;

namespace FirstProject.Entities {
    class Individual : TaxPayer {
        public Individual(string name, double anualRent, double healthExpenses) : base(name, anualRent) {
            HealthExpenses = healthExpenses;
        }

        public double HealthExpenses { get; set; }

        public override double CalculateTax() {
            double rentTax = 0.15;
            double healthTax = 0;
            if (AnualRent >= 20000) {
                rentTax = 0.25;
            }
            if (HealthExpenses > 0) {
                healthTax = 0.5;
            }
            return (AnualRent * rentTax) - (HealthExpenses * healthTax);
        }
    }
}
