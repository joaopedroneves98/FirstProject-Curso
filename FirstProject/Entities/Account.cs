using FirstProject.Entities.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace FirstProject.Entities {
    class Account {

        public int Number { get; set; }
        public string Holder { get; set; }
        public double Balance { get; set; }
        public double WithdrawLimit { get; set; }

        public Account(int number, string holder, double withdrawLimit, double balance) {
            Number = number;
            Holder = holder;
            WithdrawLimit = withdrawLimit;
            Balance = balance;
        }

        public void Deposit(double amount) {
            Balance += amount;
        }

        public void Withdraw(double amount) {
            if (Balance == 0.0) {
                throw new DomainException("Not enough balance");
            }

            if (Balance - amount < 0.0) {
                throw new DomainException("Not enough balance");
            }

            if (amount > WithdrawLimit) {
                throw new DomainException("The amount exceeds the withdraw limit");
            }

            Balance -= amount;
        }
    }
}
