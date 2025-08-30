using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManipulandoValores.Models

{
    public static class MetodosManipulacao
    {
        public static void Demonstrar()
        {
            List<int> numeros = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            List<string> palavras = new List<string> { "casa", "carro", "computador", "cachorro", "gato" };

            // Transformação com Select
            var quadrados = numeros.Select(n => n * n).ToList();
            Console.WriteLine("Quadrados: " + string.Join(", ", quadrados));

            var tamanhosPalavras = palavras.Select(p => $"{p} ({p.Length} letras)").ToList();
            Console.WriteLine("Palavras: " + string.Join(", ", tamanhosPalavras));

            // Filtro com Where
            var pares = numeros.Where(n => n % 2 == 0).ToList();
            var palavrasComC = palavras.Where(p => p.StartsWith("c")).ToList();

            Console.WriteLine("\nNúmeros pares: " + string.Join(", ", pares));
            Console.WriteLine("Palavras com 'c': " + string.Join(", ", palavrasComC));

            // Agregação
            int soma = numeros.Aggregate((acc, n) => acc + n);
            string concatenado = palavras.Aggregate((acc, p) => acc + ", " + p);

            Console.WriteLine($"\nSoma total: {soma}");
            Console.WriteLine($"Concatenado: {concatenado}");

            // Métodos úteis
            bool todosPares = numeros.All(n => n % 2 == 0);
            bool algumPar = numeros.Any(n => n % 2 == 0);
            bool contem5 = numeros.Contains(5);

            Console.WriteLine($"\nTodos são pares? {todosPares}");
            Console.WriteLine($"Algum é par? {algumPar}");
            Console.WriteLine($"Contém 5? {contem5}");

            // Skip e Take (paginação)
            var pagina1 = numeros.Skip(0).Take(3).ToList();
            var pagina2 = numeros.Skip(3).Take(3).ToList();

            Console.WriteLine($"Página 1: {string.Join(", ", pagina1)}");
            Console.WriteLine($"Página 2: {string.Join(", ", pagina2)}");

            // Distinct
            List<int> comDuplicatas = new List<int> { 1, 2, 2, 3, 4, 4, 4, 5 };
            var semDuplicatas = comDuplicatas.Distinct().ToList();
            Console.WriteLine($"\nCom duplicatas: {string.Join(", ", comDuplicatas)}");
            Console.WriteLine($"Sem duplicatas: {string.Join(", ", semDuplicatas)}");
        }
    }
}