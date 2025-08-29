using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoopsRepeticao.LoopExamples
{
    public static class LoopControlExample
    {
        public static void DemonstrarControleLoop()
        {
            Console.WriteLine("⚡ CONTROLE DE LOOPS - break, continue, return");
            Console.WriteLine("==============================================");

            // break - saída antecipada
            Console.WriteLine("🛑 BREAK - Saindo do loop antecipadamente:");
            for (int i = 1; i <= 10; i++)
            {
                if (i == 6)
                {
                    Console.WriteLine("Encontrado 6! Saindo...");
                    break;
                }
                Console.WriteLine($"Número: {i}");
            }

            // continue - pulando iteração
            Console.WriteLine("\n⏭️ CONTINUE - Pulando números pares:");
            for (int i = 1; i <= 10; i++)
            {
                if (i % 2 == 0)
                {
                    continue; // Pula números pares
                }
                Console.WriteLine($"Número ímpar: {i}");
            }

            // return - saindo do método
            Console.WriteLine("\n↩️ RETURN - Saindo do método:");
            EncontrarPrimeiroDivisivelPor7();

            // Exemplo prático: busca em lista
            Console.WriteLine("\n🔍 Buscando número em lista:");
            int[] numeros = { 1, 3, 5, 7, 9, 11, 13 };
            int alvo = 7;
            bool encontrado = false;

            foreach (int numero in numeros)
            {
                if (numero == alvo)
                {
                    encontrado = true;
                    Console.WriteLine($"✅ Número {alvo} encontrado!");
                    break;
                }
                Console.WriteLine($"Verificando: {numero}");
            }

            if (!encontrado)
            {
                Console.WriteLine($"❌ Número {alvo} não encontrado.");
            }
        }

        private static void EncontrarPrimeiroDivisivelPor7()
        {
            for (int i = 1; i <= 100; i++)
            {
                if (i % 7 == 0)
                {
                    Console.WriteLine($"Primeiro número divisível por 7: {i}");
                    return; // Sai do método completamente
                }
            }
            Console.WriteLine("Nenhum número encontrado.");
        }
    }
}