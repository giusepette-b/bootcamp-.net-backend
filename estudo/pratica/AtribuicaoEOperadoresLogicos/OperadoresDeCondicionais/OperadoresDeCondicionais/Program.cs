using System;
using OperadoresCondicionais.Condicionais;
using OperadoresLogicos.LogicExamples;

namespace OperadoresCondicionais
{
    class Program
    {
        static void Main(string[] args)
        {
            int valorTeste = 15;
            int temperaturaTeste = 40;
            Console.WriteLine("=== DEMONSTRAÇÃO DE OPERADORES CONDICIONAIS ===\n");

            IfElseExample.Demonstrar();
            Console.WriteLine();

            SwitchCaseExample.Demonstrar();
            Console.WriteLine();

            OperadorTernarioExample.Demonstrar(temperaturaTeste);
            Console.WriteLine();

            PatternMatchingExample.Demonstrar();
            Console.WriteLine();

            NullCoalescingExample.Demonstrar();
            Console.WriteLine();

            IfElseExample.VerificaMaiorQueDez(valorTeste);
            Console.WriteLine();

            Console.WriteLine("=== OPERADORES LÓGICOS EM C# ===\n");
            Console.WriteLine("1. OPERADOR AND (&&)");
            Console.WriteLine("=====================");
            AndOperatorExample.DemonstrarAnd();
            Console.WriteLine();

            Console.WriteLine("2. OPERADOR OR (||)");
            Console.WriteLine("====================");
            OrOperatorExample.DemonstrarOr();
            Console.WriteLine();

            Console.WriteLine("3. OPERADOR NOT (!)");
            Console.WriteLine("====================");
            NotOperatorExample.DemonstrarNot();
            Console.WriteLine();

            Console.WriteLine("4. COMBINAÇÕES DE OPERADORES");
            Console.WriteLine("============================");
            CombinadosExample.DemonstrarCombinados();
            Console.WriteLine();

            Console.WriteLine("5. SHORT-CIRCUIT EVALUATION");
            Console.WriteLine("===========================");
            ShortCircuitExample.DemonstrarShortCircuit();
            Console.WriteLine();

            Console.WriteLine("=== FIM DA DEMONSTRAÇÃO ===");

            // Exemplo interativo
            Console.WriteLine("\n📝 Teste Prático:");
            TesteInterativo.ExecutarTeste();

        }
    }
}