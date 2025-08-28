using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OperadoresAritmeticos.ArithmeticOperations
{
    public static class DivisaoExample
    {
        public static void DemonstrarDivisao()
        {
            Console.WriteLine("➗ OPERADOR DE DIVISÃO (/)");
            Console.WriteLine("=========================");

            // Divisão inteira vs decimal
            int a = 10, b = 3;
            int divisaoInteira = a / b;
            Console.WriteLine($"Divisão inteira: {a} / {b} = {divisaoInteira}");

            double divisaoDecimal = (double)a / b;
            Console.WriteLine($"Divisão decimal: {a} / {b} = {divisaoDecimal:F2}");

            // Divisão por zero
            try
            {
                double resultado = 10 / 0.0;
                Console.WriteLine($"10 / 0 = {resultado}"); // Infinity
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("❌ Erro: Divisão por zero!");
            }
        }

        public static double Dividir(double a, double b)
        {
            if (b == 0) throw new DivideByZeroException("Divisão por zero não permitida");
            return a / b;
        }
    }
}