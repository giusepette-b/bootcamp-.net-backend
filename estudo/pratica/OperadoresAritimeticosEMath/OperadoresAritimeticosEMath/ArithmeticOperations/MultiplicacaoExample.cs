using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OperadoresAritmeticos.ArithmeticOperations
{
    public static class MultiplicacaoExample
    {
        public static void DemonstrarMultiplicacao()
        {
            Console.WriteLine("✖️  OPERADOR DE MULTIPLICAÇÃO (*)");
            Console.WriteLine("================================");

            int a = 7, b = 6;
            int resultado = a * b;
            Console.WriteLine($"{a} * {b} = {resultado}");

            // Multiplicação com decimais
            double x = 2.5, y = 4.2;
            double resultadoDouble = x * y;
            Console.WriteLine($"{x} * {y} = {resultadoDouble}");

            // Multiplicação por zero
            Console.WriteLine($"15 * 0 = {15 * 0}");

            // Multiplicação por 1 (elemento neutro)
            Console.WriteLine($"42 * 1 = {42 * 1}");
        }

        public static double Multiplicar(double a, double b) => a * b;
    }
}