using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoopsRepeticao.LoopExamples
{
    public static class WhileLoopExample
    {
        public static void DemonstrarWhileLoop()
        {
            Console.WriteLine("🔁 WHILE LOOP - Laço com condição de parada");
            Console.WriteLine("===========================================");

            // Sintaxe básica
            Console.WriteLine("Contagem com while:");
            int contador = 1;
            while (contador <= 5)
            {
                Console.WriteLine($"Contador: {contador}");
                contador++;
            }

            // Validação de entrada do usuário
            Console.WriteLine("\n💡 Validação de entrada (while):");
            int numero;
            Console.Write("Digite um número entre 1 e 10: ");

            while (!int.TryParse(Console.ReadLine(), out numero) || numero < 1 || numero > 10)
            {
                Console.Write("Número inválido! Digite entre 1 e 10: ");
            }
            Console.WriteLine($"Número válido: {numero}");

            // Processamento até condição
            Console.WriteLine("\n🔢 Processamento de números:");
            int soma = 0;
            int numeroAtual = 1;

            while (soma < 50)
            {
                soma += numeroAtual;
                Console.WriteLine($"Adicionando {numeroAtual}, soma: {soma}");
                numeroAtual++;
            }

            // Simulação de jogo
            Console.WriteLine("\n🎮 Simulação de jogo (while):");
            int vida = 100;
            Random random = new Random();

            while (vida > 0)
            {
                int dano = random.Next(5, 15);
                vida -= dano;
                Console.WriteLine($"Leviou {dano} de dano. Vida: {Math.Max(vida, 0)}");

                if (vida <= 0)
                {
                    Console.WriteLine("💀 Game Over!");
                }
            }
        }
    }
}