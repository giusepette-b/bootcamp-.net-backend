using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OperadoresAritmeticos.ArithmeticOperations
{
    public static class SubtracaoExample
    {
        public static void DemonstrarSubtracao()
        {
            Console.WriteLine("➖ OPERADOR DE SUBTRAÇÃO (-)");
            Console.WriteLine("===========================");

            int a = 20, b = 8;
            int resultado = a - b;
            Console.WriteLine($"{a} - {b} = {resultado}");

            // Subtração com negativos
            double x = 10.5, y = 15.3;
            double resultadoNegativo = x - y;
            Console.WriteLine($"{x} - {y} = {resultadoNegativo}");

            // Subtração com zero
            Console.WriteLine($"5 - 0 = {5 - 0}");
        }

        public static double Subtrair(double a, double b) => a - b;
    }
}