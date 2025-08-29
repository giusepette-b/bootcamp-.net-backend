using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoopsRepeticao.LoopExamples
{
    public static class DoWhileLoopExample
    {
        public static void DemonstrarDoWhileLoop()
        {
            Console.WriteLine("🔃 DO-WHILE LOOP - Executa pelo menos uma vez");
            Console.WriteLine("=============================================");

            // Sintaxe básica
            Console.WriteLine("Contagem com do-while:");
            int contador = 1;
            do
            {
                Console.WriteLine($"Contador: {contador}");
                contador++;
            } while (contador <= 5);

            // Diferença crucial: executa pelo menos uma vez
            Console.WriteLine("\n💡 Execução garantida (pelo menos uma vez):");
            int numero = 10;

            do
            {
                Console.WriteLine($"Número: {numero} (executou mesmo sendo > 5)");
                numero++;
            } while (numero <= 5);

            // Menu interativo
            Console.WriteLine("\n📋 Menu interativo com do-while:");
            string opcao;

            do
            {
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1 - Ver hora atual");
                Console.WriteLine("2 - Ver data atual");
                Console.WriteLine("s - Sair");
                Console.Write("Escolha: ");

                opcao = Console.ReadLine()?.ToLower();

                switch (opcao)
                {
                    case "1":
                        Console.WriteLine($"Hora: {DateTime.Now:HH:mm:ss}");
                        break;
                    case "2":
                        Console.WriteLine($"Data: {DateTime.Now:dd/MM/yyyy}");
                        break;
                    case "s":
                        Console.WriteLine("Saindo...");
                        break;
                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }

            } while (opcao != "s");

            // Validação com execução garantida
            Console.WriteLine("\n🔐 Validação com do-while:");
            string senha;

            do
            {
                Console.Write("Digite a senha (1234): ");
                senha = Console.ReadLine();

                if (senha != "1234")
                {
                    Console.WriteLine("Senha incorreta! Tente novamente.");
                }

            } while (senha != "1234");

            Console.WriteLine("✅ Acesso permitido!");
        }
    }
}