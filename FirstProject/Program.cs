using System;
using System.Globalization;

namespace FirstProject
{
    class Program
    {
        static void Main(string[] args)
        {

            //  EXERCICIO DE SAIDA DE DADOS
            //string produto1 = "Computador";
            //string produto2 = "Mesa de Escritório";

            //byte idade = 30;
            //int codigo = 5290;
            //char genero = 'M';

            //double preco1 = 2100.0;
            //double preco2 = 650.50;
            //double medida = 53.234567;

            //Console.WriteLine("Produtos:");
            //Console.WriteLine(produto1 + ", cujo preço é " + preco1 + "€");
            //Console.WriteLine(produto2 + ", cujo preço é " + preco2 + "€");

            //Console.WriteLine("Registo: " + idade + " anos de idade, codigo " + codigo + " e género: " + genero);

            //Console.WriteLine("Medida com oito casas decimais: " + medida.ToString("F8"));
            //Console.WriteLine("Arredondado (três casas decimais): " + medida.ToString("F3"));
            //Console.WriteLine("Separador decimal invariant culture: " + medida.ToString("F3", CultureInfo.InvariantCulture));

            // EXERCICIO DE ENTRADA DE DADOS

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
    }
}
