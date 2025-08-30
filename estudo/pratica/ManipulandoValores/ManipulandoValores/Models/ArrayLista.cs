using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManipulandoValores.Models

{
    public static class ArraysListas
    {
        public static void Demonstrar()
        {
            // Arrays
            int[] numerosArray = new int[5] { 1, 2, 3, 4, 5 };
            string[] nomesArray = { "Ana", "João", "Maria", "Pedro" };

            Console.WriteLine("Array de números: " + string.Join(", ", numerosArray));
            Console.WriteLine("Array de nomes: " + string.Join(", ", nomesArray));

            // Listas
            List<int> numerosLista = new List<int> { 10, 20, 30, 40, 50 };
            List<string> nomesLista = new List<string> { "Carlos", "Juliana", "Fernanda" };

            // Adicionando elementos
            numerosLista.Add(60);
            numerosLista.AddRange(new[] { 70, 80, 90 });
            nomesLista.Insert(1, "Ricardo");

            Console.WriteLine("\nLista de números: " + string.Join(", ", numerosLista));
            Console.WriteLine("Lista de nomes: " + string.Join(", ", nomesLista));

            // Removendo elementos
            numerosLista.Remove(30);
            numerosLista.RemoveAt(0);
            nomesLista.RemoveAll(n => n.StartsWith("J"));

            Console.WriteLine("\nApós remoções:");
            Console.WriteLine("Números: " + string.Join(", ", numerosLista));
            Console.WriteLine("Nomes: " + string.Join(", ", nomesLista));

            // Buscas
            bool contem40 = numerosLista.Contains(40);
            int primeiroMaior50 = numerosLista.Find(n => n > 50);
            List<int> todosMaiores40 = numerosLista.FindAll(n => n > 40);

            Console.WriteLine($"\nContém 40? {contem40}");
            Console.WriteLine($"Primeiro maior que 50: {primeiroMaior50}");
            Console.WriteLine($"Todos maiores que 40: {string.Join(", ", todosMaiores40)}");
        }
    }
}