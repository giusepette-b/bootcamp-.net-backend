using System;
using System.Collections.Generic;
using EncapsulamentoAbstracao.Models;

namespace EncapsulamentoAbstracao
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== ENCAPSULAMENTO E ABSTRAÇÃO EM C# ===\n");

            // 1. Demonstração de Encapsulamento
            Console.WriteLine("1. ENCAPSULAMENTO:");
            Encapsulamento.Demonstrar();
            Console.WriteLine();

            // 2. Demonstração de Abstração
            Console.WriteLine("2. ABSTRAÇÃO:");
            Abstracao.Demonstrar();
            Console.WriteLine();

            // 3. Exemplo Integrado
            Console.WriteLine("3. EXEMPLO INTEGRADO:");
            ExemploIntegrado.Demonstrar();
        }
    }
}