using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OperadoresAritmeticos.ArithmeticOperations
{
    public static class AdicaoExample
    {
        public static void DemonstrarAdicao()
        {
            Console.WriteLine("➕ OPERADOR DE ADIÇÃO (+)");
            Console.WriteLine("========================");

            int a = 10, b = 5;
            int resultado = a + b;
            Console.WriteLine($"{a} + {b} = {resultado}");

            // Adição com diferentes tipos
            double x = 15.5, y = 3.2;
            double resultadoDouble = x + y;
            Console.WriteLine($"{x} + {y} = {resultadoDouble}");

            // Concatenação de strings (sobrecarga do +)
            string nome = "João", sobrenome = "Silva";
            string nomeCompleto = nome + " " + sobrenome;
            Console.WriteLine($"Nome: {nomeCompleto}");
        }

        public static double Somar(double a, double b) => a + b;
    }
}