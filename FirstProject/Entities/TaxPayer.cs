using System;
using System.Collections.Generic;
using System.Text;

namespace FirstProject.Entities {
    abstract class TaxPayer {
        public string Name { get; set; }
        public double AnualRent { get; set; }

        protected TaxPayer(string name, double anualRent) {
            Name = name;
            AnualRent = anualRent;
        }

        public abstract double CalculateTax();
    }
}
