using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OperadoresAritmeticos.ArithmeticOperations
{
    public static class CalculadoraAvancada
    {
        public static void CalcularAdicao(double a, double b)
        {
            double resultado = a + b;
            Console.WriteLine($"➕ {a} + {b} = {resultado}");
        }

        public static void CalcularSubtracao(double a, double b)
        {
            double resultado = a - b;
            Console.WriteLine($"➖ {a} - {b} = {resultado}");
        }

        public static void CalcularMultiplicacao(double a, double b)
        {
            double resultado = a * b;
            Console.WriteLine($"✖️  {a} × {b} = {resultado}");
        }

        public static void CalcularDivisao(double a, double b)
        {
            if (b == 0)
            {
                Console.WriteLine("❌ Erro: Divisão por zero não é permitida!");
                return;
            }

            double resultado = a / b;
            Console.WriteLine($"➗ {a} ÷ {b} = {resultado:F4}");
        }

        public static void CalcularModulo(double a, double b)
        {
            if (b == 0)
            {
                Console.WriteLine("❌ Erro: Divisão por zero não é permitida!");
                return;
            }

            double resultado = a % b;
            Console.WriteLine($"🔍 {a} % {b} = {resultado} (resto da divisão)");
        }

        public static void CalcularTodasOperacoes(double a, double b)
        {
            Console.WriteLine($"📊 RESULTADOS PARA {a} E {b}:");
            Console.WriteLine($"➕ Soma: {a + b}");
            Console.WriteLine($"➖ Subtração: {a - b}");
            Console.WriteLine($"✖️  Multiplicação: {a * b}");

            if (b != 0)
            {
                Console.WriteLine($"➗ Divisão: {a / b:F4}");
                Console.WriteLine($"🔍 Módulo: {a % b}");
            }
            else
            {
                Console.WriteLine("❌ Divisão e Módulo: Indefinido (divisor zero)");
            }
        }
    }
}