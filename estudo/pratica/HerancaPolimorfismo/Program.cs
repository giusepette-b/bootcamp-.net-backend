using System;
using System.Collections.Generic;
using HerancaPolimorfismo.Models;

namespace HerancaPolimorfismo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== HERANÇA E POLIMORFISMO EM C# ===\n");

            // 1. Demonstração de Herança
            Console.WriteLine("1. HERANÇA:");
            Heranca.Demonstrar();
            Console.WriteLine();

            // 2. Demonstração de Polimorfismo
            Console.WriteLine("2. POLIMORFISMO:");
            Polimorfismo.Demonstrar();
            Console.WriteLine();

            // 3. Exemplo Integrado
            Console.WriteLine("3. EXEMPLO INTEGRADO:");
            ExemploIntegrado.Demonstrar();
        }
    }
}