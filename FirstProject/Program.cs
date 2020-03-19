﻿using FirstProject.Entities;
using FirstProject.Entities.Enums;
using System;
using System.Globalization;

namespace FirstProject {
    class Program {
        static void Main(string[] args) {
            //ExSaidaDados();
            //ExEntradaDados();
            //ExVetores();
            ExEnumsComp();
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
