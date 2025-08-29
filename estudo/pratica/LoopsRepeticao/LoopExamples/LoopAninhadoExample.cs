using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoopsRepeticao.LoopExamples
{
    public static class LoopAninhadoExample
    {
        public static void DemonstrarLoopsAninhados()
        {
            Console.WriteLine("🔄 LOOPS ANINHADOS - Loops dentro de loops");
            Console.WriteLine("==========================================");

            // Tabuada
            Console.WriteLine("🧮 Tabuada 1 a 3:");
            for (int i = 1; i <= 3; i++)
            {
                Console.WriteLine($"\nTabuada do {i}:");
                for (int j = 1; j <= 10; j++)
                {
                    Console.WriteLine($"{i} x {j} = {i * j}");
                }
            }

            // Padrão de asteriscos
            Console.WriteLine("\n⭐ Padrão de asteriscos:");
            for (int linha = 1; linha <= 5; linha++)
            {
                for (int coluna = 1; coluna <= linha; coluna++)
                {
                    Console.Write("* ");
                }
                Console.WriteLine();
            }

            // Matriz
            Console.WriteLine("\n📊 Matriz 3x3:");
            int[,] matriz = new int[3, 3];
            int valor = 1;

            for (int linha = 0; linha < 3; linha++)
            {
                for (int coluna = 0; coluna < 3; coluna++)
                {
                    matriz[linha, coluna] = valor++;
                    Console.Write($"{matriz[linha, coluna]:00} ");
                }
                Console.WriteLine();
            }

            // Loop triplo (raro, mas possível)
            Console.WriteLine("\n🔢 Combinações únicas (x, y, z):");
            for (int x = 0; x < 2; x++)
            {
                for (int y = 0; y < 2; y++)
                {
                    for (int z = 0; z < 2; z++)
                    {
                        Console.WriteLine($"({x}, {y}, {z})");
                    }
                }
            }
        }
    }
}