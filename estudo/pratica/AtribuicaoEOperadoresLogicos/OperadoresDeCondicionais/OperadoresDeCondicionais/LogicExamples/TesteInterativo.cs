using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OperadoresLogicos.LogicExamples
{
    public static class TesteInterativo
    {
        public static void ExecutarTeste()
        {
            Console.WriteLine("🎮 Teste Interativo - Digite valores true/false");

            Console.Write("Valor 1 (true/false): ");
            bool valor1 = LerBooleano();

            Console.Write("Valor 2 (true/false): ");
            bool valor2 = LerBooleano();

            Console.WriteLine($"\nAND ({valor1} && {valor2}): {valor1 && valor2}");
            Console.WriteLine($"OR ({valor1} || {valor2}): {valor1 || valor2}");
            Console.WriteLine($"NOT (!{valor1}): {!valor1}");
            Console.WriteLine($"XOR ({valor1} ^ {valor2}): {valor1 ^ valor2}");
        }

        private static bool LerBooleano()
        {
            while (true)
            {
                string input = Console.ReadLine().ToLower();
                if (input == "true") return true;
                if (input == "false") return false;
                Console.Write("Digite 'true' ou 'false': ");
            }
        }
    }
}