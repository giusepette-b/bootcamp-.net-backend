using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OperadoresAritmeticos.ArithmeticOperations
{
    public static class IncrementoExample
    {
        public static void DemonstrarIncremento()
        {
            Console.WriteLine("⚡ OPERADORES DE INCREMENTO (++/--)");
            Console.WriteLine("==================================");

            // Pré-incremento vs Pós-incremento
            int a = 5;
            Console.WriteLine($"Valor inicial: a = {a}");
            Console.WriteLine($"Pré-incremento: ++a = {++a}"); // 6
            Console.WriteLine($"Após pré-incremento: a = {a}"); // 6

            int b = 5;
            Console.WriteLine($"\nValor inicial: b = {b}");
            Console.WriteLine($"Pós-incremento: b++ = {b++}"); // 5
            Console.WriteLine($"Após pós-incremento: b = {b}"); // 6

            // Decremento
            int c = 8;
            Console.WriteLine($"\nValor inicial: c = {c}");
            Console.WriteLine($"Pré-decremento: --c = {--c}"); // 7
            Console.WriteLine($"Pós-decremento: c-- = {c--}"); // 7
            Console.WriteLine($"Valor final: c = {c}"); // 6
        }
    }
}