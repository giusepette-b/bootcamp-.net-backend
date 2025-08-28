using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OperadoresAritmeticos.ArithmeticOperations
{
    public static class ModuloExample
    {
        public static void DemonstrarModulo()
        {
            Console.WriteLine("🔍 OPERADOR MÓDULO (RESTO) (%)");
            Console.WriteLine("==============================");

            // Resto da divisão
            int a = 17, b = 5;
            int resto = a % b;
            Console.WriteLine($"{a} % {b} = {resto} (porque 17 ÷ 5 = 3 com resto 2)");

            // Verificação de par/ímpar
            int numero = 8;
            Console.WriteLine($"{numero} é {(numero % 2 == 0 ? "par" : "ímpar")}");

            // Módulo com decimais
            double x = 10.7, y = 3.2;
            double restoDecimal = x % y;
            Console.WriteLine($"{x} % {y} = {restoDecimal:F2}");
        }

        public static double CalcularModulo(double a, double b) => a % b;
    }
}