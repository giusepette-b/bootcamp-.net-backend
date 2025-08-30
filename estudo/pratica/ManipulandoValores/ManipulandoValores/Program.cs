using System;
using System.Collections.Generic;
using System.Linq;

namespace ManipulacaoDados
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== MANIPULAÇÃO DE DADOS EM C# ===\n");

            // 1. Arrays e Listas
            Console.WriteLine("1. ARRAYS E LISTAS:");
            ArraysListas.Demonstrar();
            Console.WriteLine();

            // 2. Dicionários
            Console.WriteLine("2. DICIONÁRIOS:");
            Dicionarios.Demonstrar();
            Console.WriteLine();

            // 3. LINQ - Consultas
            Console.WriteLine("3. LINQ - CONSULTAS:");
            LinqConsultas.Demonstrar();
            Console.WriteLine();

            // 4. Manipulação com métodos
            Console.WriteLine("4. MÉTODOS DE MANIPULAÇÃO:");
            MetodosManipulacao.Demonstrar();
            Console.WriteLine();

            // 5. Dados complexos
            Console.WriteLine("5. DADOS COMPLEXOS:");
            DadosComplexos.Demonstrar();
        }
    }
}