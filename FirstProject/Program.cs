using FirstProject.Entities;
using FirstProject.Entities.Enums;
using FirstProject.Entities.Exceptions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace FirstProject {
    class Program {
        static void Main(string[] args) {
            //ExSaidaDados();
            //ExEntradaDados();
            //ExVetores();
            //ExEnumsComp();
            //ExEnumsFinal();
            //ExHerancaAbstrata();
            ExExcecoes();
        }

        // EXERCICIO DIRECTORY
        private static void ExDirectory() {
            string path = @"c:\temp\myfolder";

            try {
                IEnumerable<string> folder = Directory.EnumerateDirectories(path, "*.*", SearchOption.AllDirectories);
                Console.WriteLine("FOLDERS: ");
                foreach (var f in folder) {
                    Console.WriteLine(f);
                }

                IEnumerable<string> files = Directory.EnumerateFiles(path, "*.*", SearchOption.AllDirectories);
                Console.WriteLine("FILES: ");
                foreach (var f in files) {
                    Console.WriteLine(f);
                }
                Directory.CreateDirectory(path + "\\newfolder");
            }
            catch (IOException ex) {
                Console.WriteLine("An error occurred");
                Console.WriteLine(ex.Message);
            }
        }

        // EXERCICIO STREAMWRITTER
        private static void ExStreamWritter() {
            string sourcePath = @"c:\temp\file1.txt";
            string targetPath = @"c:\temp\file2.txt";

            try {
                string[] lines = File.ReadAllLines(sourcePath);
                using(StreamWriter sw = File.AppendText(targetPath)) {
                    foreach (var line in lines) {
                        sw.WriteLine(line.ToUpper());
                    }
                }
            }
            catch (IOException ex) {
                Console.WriteLine("An error occurred");
                Console.WriteLine(ex.Message);
            }
        }

        // EXERCICIO USING
        private static void ExUsing() {
            string path = @"c:\temp\file1.txt";
            try {
                using (StreamReader sr = File.OpenText(path)) {
                    while (!sr.EndOfStream) {
                        string line = sr.ReadLine();
                        Console.WriteLine(line);
                    }
                }

            }
            catch (IOException e) {
                Console.WriteLine("An error occurred");
                Console.WriteLine(e.Message);
            }
        }

        // EXERCICIO STREAM
        private static void ExStream() {
            string path = @"c:\temp\file1.txt";
            StreamReader sr = null;
            try {
                sr = File.OpenText(path);
                while (!sr.EndOfStream) {
                    string line = sr.ReadLine();
                    Console.WriteLine(line);
                }
            }
            catch (IOException ex) {
                Console.WriteLine("An error occurred");
                Console.WriteLine(ex.Message);
            }
            finally {
                if (sr != null) {
                    sr.Close();
                }
            }
        }

        // EXERCICIO FILE
        private static void ExFile() {
            string sourcePath = @"c:\temp\file1.txt";
            string targetPath = @"c:\temp\file2.txt";

            try {
                FileInfo fileInfo = new FileInfo(sourcePath);
                fileInfo.CopyTo(targetPath);
                string[] lines = File.ReadAllLines(sourcePath);
                foreach (var item in lines) {
                    Console.WriteLine(item);
                }
            }
            catch (IOException ex) {
                Console.WriteLine("An error occurred");
                Console.WriteLine(ex.Message);
            }
        }

        // EXERCICIO EXCECOES
        private static void ExExcecoes() {
            try {
                Console.WriteLine("Enter account data");
                Console.Write("Number: ");
                int number = int.Parse(Console.ReadLine());
                Console.Write("Holder: ");
                string holder = Console.ReadLine();
                Console.Write("Initial Balance: ");
                double balance = double.Parse(Console.ReadLine());
                Console.Write("Withdraw Limit: ");
                double withdrawLimit = double.Parse(Console.ReadLine());

                Account account = new Account(number, holder, withdrawLimit, balance);

                Console.WriteLine();

                Console.Write("Enter amount for withdraw: ");
                double amount = double.Parse(Console.ReadLine());
                account.Withdraw(amount);

                Console.WriteLine("New balance: " + account.Balance);
            }
            catch (DomainException ex) {
                Console.WriteLine("Withdraw error: " + ex.Message);
            }
        }

        // EXERCICIO HERANÇA E CLASSES ABSTRATAS
        private static void ExHerancaAbstrata() {
            Console.Write("Enter the number of tax payers: ");
            int n = int.Parse(Console.ReadLine());

            List<TaxPayer> taxPayers = new List<TaxPayer>();

            for (int i = 0; i < n; i++) {
                Console.WriteLine($"Tax payer #{i + 1} data: ");
                Console.Write("Individual or company (i/c)? ");
                char ic = char.Parse(Console.ReadLine());
                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Write("Annual income: ");
                double annualIncome = double.Parse(Console.ReadLine());
                if (ic == 'i') {
                    Console.Write("Health expenditures: ");
                    double health = double.Parse(Console.ReadLine());
                    TaxPayer ind = new Individual(name, annualIncome, health);
                    taxPayers.Add(ind);
                }
                else {
                    Console.Write("Number of employees: ");
                    int nEmployees = int.Parse(Console.ReadLine());
                    TaxPayer comp = new Company(name, annualIncome, nEmployees);
                    taxPayers.Add(comp);
                }
            }

            double total = 0;

            Console.WriteLine("TAXES PAID: ");
            foreach (var payer in taxPayers) {
                Console.WriteLine(payer.Name + ": $ " + payer.CalculateTax());
                total += payer.CalculateTax();
            }

            Console.WriteLine("TOTAL TAXES: $" + total);
        }

        // EXERCICIO ENUMS E COMPOSICAO FINAL
        private static void ExEnumsFinal() {
            Console.WriteLine("Enter Client Data: ");
            Console.Write("Name: ");
            string clientName = Console.ReadLine();
            Console.Write("Email: ");
            string clientEmail = Console.ReadLine();
            Console.Write("Birth Date (MM/DD/YYYY): ");
            DateTime birthDate = DateTime.Parse(Console.ReadLine());

            Client client = new Client(clientName, clientEmail, birthDate);

            Console.WriteLine("Enter order data: ");
            Console.Write("Status: ");
            OrderStatus status = Enum.Parse<OrderStatus>(Console.ReadLine());
            Console.Write("How many items in this order? ");
            int nItems = int.Parse(Console.ReadLine());

            Order order = new Order(status, client);

            for (int i = 0; i < nItems; i++) {
                Console.WriteLine($"Enter #{i + 1} item data: ");
                Console.Write("Product Name: ");
                string prodName = Console.ReadLine();
                Console.Write("Product Price: ");
                double prodPrice = double.Parse(Console.ReadLine());
                Console.Write("Quantity: ");
                int quantity = int.Parse(Console.ReadLine());

                Product product = new Product(prodName, prodPrice);
                OrderItem orderItem = new OrderItem(quantity, product.Price, product);

                order.AddItem(orderItem);
            }

            Console.WriteLine();
            Console.WriteLine("ORDER SUMMARY: ");
            Console.WriteLine("Order moment: " + order.Moment);
            Console.WriteLine("Order status: " + order.Status);
            Console.WriteLine("Client: " + order.Client);
            Console.WriteLine("Order Items: ");

            foreach (var item in order.Items) {
                Console.WriteLine(item);
            }

            Console.WriteLine("Total Price: " + order.Total());
        }

        // EXERCICIO ENUMS E COMPOSICAO
        private static void ExEnumsComp() {
            Console.Write("Enter Department's name: ");
            string deptName = Console.ReadLine();
            Console.WriteLine("Enter Worker Data");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Level (Junior/MidLevel/Senior): ");
            WorkerLevel level = Enum.Parse<WorkerLevel>(Console.ReadLine());
            Console.Write("Base Salary: ");
            double baseSalary = double.Parse(Console.ReadLine());

            Department dept = new Department(deptName);
            Worker worker = new Worker(name, level, baseSalary, dept);

            Console.Write("How many contracts for this worker? ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++) {
                Console.WriteLine($"Enter #{i} contract data: ");
                Console.Write("Date (DD/MM/YYYY): ");
                DateTime date = DateTime.Parse(Console.ReadLine());
                Console.Write("Value per hour: ");
                double valuePerHour = double.Parse(Console.ReadLine());
                Console.Write("Duration (hours): ");
                int hours = int.Parse(Console.ReadLine());
                HourContract contract = new HourContract(date, valuePerHour, hours);
                worker.AddContract(contract);
            }
            Console.WriteLine();
            Console.Write("Enter month and year to calculate income (MM/YYYY): ");
            string monthYear = Console.ReadLine();
            int month = int.Parse(monthYear.Substring(0, 2));
            int year = int.Parse(monthYear.Substring(3));
            Console.WriteLine("Name: " + worker.Name);
            Console.WriteLine("Department: " + worker.Department.Name);
            Console.WriteLine("Income for " + monthYear + ": " + worker.Income(year, month));
        }

        //  EXERCICIO DE SAIDA DE DADOS
        private static void ExSaidaDados() {

            string produto1 = "Computador";
            string produto2 = "Mesa de Escritório";

            byte idade = 30;
            int codigo = 5290;
            char genero = 'M';

            double preco1 = 2100.0;
            double preco2 = 650.50;
            double medida = 53.234567;

            Console.WriteLine("Produtos:");
            Console.WriteLine(produto1 + ", cujo preço é " + preco1 + "€");
            Console.WriteLine(produto2 + ", cujo preço é " + preco2 + "€");

            Console.WriteLine("Registo: " + idade + " anos de idade, codigo " + codigo + " e género: " + genero);

            Console.WriteLine("Medida com oito casas decimais: " + medida.ToString("F8"));
            Console.WriteLine("Arredondado (três casas decimais): " + medida.ToString("F3"));
            Console.WriteLine("Separador decimal invariant culture: " + medida.ToString("F3", CultureInfo.InvariantCulture));
        }

        // EXERCICIO DE ENTRADA DE DADOS
        private static void ExEntradaDados() {

            Console.WriteLine("Insira o seu nome completo: ");
            string nome = Console.ReadLine();

            Console.WriteLine("Quantos quartos tem a sua casa?");
            int quartos = int.Parse(Console.ReadLine());

            Console.WriteLine("Insira o preço de um produto: ");
            double preco = double.Parse(Console.ReadLine());

            Console.WriteLine("Insira o seu nome, idade e altura (mesma linha): ");
            string[] dados = Console.ReadLine().Split(' ');

            string nome2 = dados[0];
            int idade2 = int.Parse(dados[1]);
            double altura = double.Parse(dados[2]);

            Console.WriteLine(nome);
            Console.WriteLine(quartos);
            Console.WriteLine(preco);
            Console.WriteLine(nome2);
            Console.WriteLine(idade2);
            Console.WriteLine(altura);
        }

        // EXERCICIO VETORES 
        private static void ExVetores() {

            Console.Write("How many rooms would you like to rent? ");
            int n = int.Parse(Console.ReadLine());

            Student[] students = new Student[10];

            for (int i = 0; i < n; i++) {
                Console.WriteLine("Rent #" + (i + 1) + ":");
                Console.Write("Name: ");
                string name = Console.ReadLine();

                Console.Write("Email: ");
                string email = Console.ReadLine();

                Console.Write("Room number: ");
                int room = int.Parse(Console.ReadLine());

                students[room] = new Student(name, email);
            }

            Console.WriteLine("Occupied Rooms: ");
            for (int i = 0; i < students.Length; i++) {
                if (students[i] != null) {
                    Console.WriteLine(i + ": " + students[i]);
                }
            }
        }
    }
}
