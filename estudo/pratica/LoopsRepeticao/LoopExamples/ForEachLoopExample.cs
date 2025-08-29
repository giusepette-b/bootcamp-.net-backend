using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoopsRepeticao.LoopExamples
{
    public static class ForEachLoopExample
    {
        public static void DemonstrarForEachLoop()
        {
            Console.WriteLine("🔄 FOREACH LOOP - Iteração sobre coleções");
            Console.WriteLine("========================================");

            // Array de inteiros
            Console.WriteLine("📊 Array de números:");
            int[] numeros = { 1, 2, 3, 4, 5 };

            foreach (int numero in numeros)
            {
                Console.WriteLine($"Número: {numero}");
            }

            // Lista de strings
            Console.WriteLine("\n📝 Lista de nomes:");
            List<string> nomes = new List<string> { "Ana", "João", "Maria", "Pedro" };

            foreach (string nome in nomes)
            {
                Console.WriteLine($"Nome: {nome}");
            }

            // Dicionário
            Console.WriteLine("\n📚 Dicionário de notas:");
            Dictionary<string, double> notas = new Dictionary<string, double>
            {
                { "Matemática", 8.5 },
                { "Português", 9.0 },
                { "História", 7.5 }
            };

            foreach (KeyValuePair<string, double> materia in notas)
            {
                Console.WriteLine($"{materia.Key}: {materia.Value}");
            }

            // String como array de char
            Console.WriteLine("\n🔤 Iterando sobre string:");
            string texto = "CSharp";

            foreach (char letra in texto)
            {
                Console.WriteLine($"Letra: {letra}");
            }

            // Exemplo prático: soma de elementos
            Console.WriteLine("\n🧮 Soma de elementos da lista:");
            List<double> precos = new List<double> { 10.5, 20.3, 15.7, 8.9 };
            double total = 0;

            foreach (double preco in precos)
            {
                total += preco;
                Console.WriteLine($"Adicionando R$ {preco:F2}, Total: R$ {total:F2}");
            }

            Console.WriteLine($"💵 Total final: R$ {total:F2}");
        }
    }
}