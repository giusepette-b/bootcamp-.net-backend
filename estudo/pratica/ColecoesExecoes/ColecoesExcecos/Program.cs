using System;
using System.Collections.Generic;
using ExcecoesColecoes.Models;


namespace ExcecoesColecoes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== EXCEÇÕES E COLEÇÕES EM C# ===\n");

            // 1. Tratamento básico de exceções
            Console.WriteLine("1. TRATAMENTO BÁSICO DE EXCEÇÕES:");
            ExcecoesBasicas.Demonstrar();
            Console.WriteLine();

            // 2. Exceções personalizadas
            Console.WriteLine("2. EXCEÇÕES PERSONALIZADAS:");
            ExcecoesPersonalizadas.Demonstrar();
            Console.WriteLine();

            // 3. Coleções genéricas
            Console.WriteLine("3. COLEÇÕES GENÉRICAS:");
            ColecoesGenericas.Demonstrar();
            Console.WriteLine();

            // 4. Coleções especializadas
            Console.WriteLine("4. COLEÇÕES ESPECIALIZADAS:");
            ColecoesEspecializadas.Demonstrar();
            Console.WriteLine();

            // 5. Manipulação segura com exceções
            Console.WriteLine("5. MANIPULAÇÃO SEGURA COM EXCEÇÕES:");
            ManipulacaoSegura.Demonstrar();

            // 6. Métodos de coleções genéricas
            Console.WriteLine("6. MÉTODOS DE COLEÇÕES GENÉRICAS:");
            ColecoesGenericasMetodos.DemonstrarMetodos();
            Console.WriteLine();

            // 7. Métodos de coleções especializadas
            Console.WriteLine("7. MÉTODOS DE COLEÇÕES ESPECIALIZADAS:");
            ColecoesEspecializadasMetodos.DemonstrarMetodos();
        }
    }
}