using System;
using System.Collections.Generic;
using ClassesAbstratasInterfaces.Models;

namespace ClassesAbstratasInterfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== CLASSES ABSTRATAS E INTERFACES EM C# ===\n");

            // 1. Demonstração de Classes Abstratas
            Console.WriteLine("1. CLASSES ABSTRATAS:");
            ClassesAbstratas.Demonstrar();
            Console.WriteLine();

            // 2. Demonstração de Interfaces
            Console.WriteLine("2. INTERFACES:");
            Interfaces.Demonstrar();
            Console.WriteLine();

            // 3. Exemplo Integrado
            Console.WriteLine("3. EXEMPLO INTEGRADO:");
            ExemploIntegrado.Demonstrar();
        }
    }
}