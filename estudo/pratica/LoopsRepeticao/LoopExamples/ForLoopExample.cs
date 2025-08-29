using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoopsRepeticao.LoopExamples
{
    public static class ForLoopExample
    {
        public static void DemonstrarForLoop()
        {
            Console.WriteLine("🔄 FOR LOOP - Laço com contador controlado");
            Console.WriteLine("==========================================");

            // Sintaxe básica
            Console.WriteLine("Contagem de 1 a 5:");
            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine($"Iteração {i}");
            }

            // Contagem regressiva
            Console.WriteLine("\nContagem regressiva 5 to 1:");
            for (int i = 5; i >= 1; i--)
            {
                Console.WriteLine($"Contagem: {i}");
            }

            // Incremento personalizado
            Console.WriteLine("\nNúmeros pares de 0 a 10:");
            for (int i = 0; i <= 10; i += 2)
            {
                Console.WriteLine($"Par: {i}");
            }

            // Loop com múltiplas variáveis
            Console.WriteLine("\nMultiplas variáveis no for:");
            for (int i = 0, j = 10; i <= 10; i++, j--)
            {
                Console.WriteLine($"i: {i}, j: {j}");
            }

            // Exemplo prático: cálculo fatorial
            Console.WriteLine("\n📊 Cálculo Fatorial (5!):");
            int fatorial = 1;
            for (int n = 1; n <= 5; n++)
            {
                fatorial *= n;
                Console.WriteLine($"{n}! = {fatorial}");
            }
        }

        public static void CalcularFatorial(int numero)
        {
            int resultado = 1;
            for (int i = 1; i <= numero; i++)
            {
                resultado *= i;
            }
            Console.WriteLine($"{numero}! = {resultado}");
        }
    }
}