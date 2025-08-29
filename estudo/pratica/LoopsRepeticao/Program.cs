using System;
using LoopsRepeticao.LoopExamples;

namespace LoopsRepeticao
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("🔁 LAÇOS DE REPETIÇÃO EM C#");
            Console.WriteLine("===========================\n");

            // Demonstração dos principais laços
            DemonstrarLoopsBasicos();

            // Laços de controle e aninhados
            DemonstrarLoopsAvancados();

            // Exercícios interativos
            ExecutarExerciciosInterativos();

            Console.WriteLine("\n🎉 Fim da demonstração de laços de repetição!");
        }

        static void DemonstrarLoopsBasicos()
        {
            Console.WriteLine("📚 LAÇOS BÁSICOS");
            Console.WriteLine("================");

            ForLoopExample.DemonstrarForLoop();
            Console.WriteLine();

            WhileLoopExample.DemonstrarWhileLoop();
            Console.WriteLine();

            DoWhileLoopExample.DemonstrarDoWhileLoop();
            Console.WriteLine();

            ForEachLoopExample.DemonstrarForEachLoop();
            Console.WriteLine();
        }

        static void DemonstrarLoopsAvancados()
        {
            Console.WriteLine("⚡ LAÇOS AVANÇADOS");
            Console.WriteLine("==================");

            LoopControlExample.DemonstrarControleLoop();
            Console.WriteLine();

            LoopAninhadoExample.DemonstrarLoopsAninhados();
            Console.WriteLine();
        }

        static void ExecutarExerciciosInterativos()
        {
            Console.WriteLine("🎮 EXERCÍCIOS INTERATIVOS");
            Console.WriteLine("========================");

            bool continuar = true;

            while (continuar)
            {
                Console.WriteLine("\nEscolha um exercício:");
                Console.WriteLine("1 ➤ Contagem Regressiva");
                Console.WriteLine("2 ➤ Tabuada Interativa");
                Console.WriteLine("3 ➤ Adivinhe o Número");
                Console.WriteLine("4 ➤ Calculadora de Média");
                Console.WriteLine("0 ❌ Sair");

                Console.Write("\nDigite sua opção: ");
                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        ExerciciosInterativos.ContagemRegressiva();
                        break;
                    case "2":
                        ExerciciosInterativos.TabuadaInterativa();
                        break;
                    case "3":
                        ExerciciosInterativos.AdivinheONumero();
                        break;
                    case "4":
                        ExerciciosInterativos.CalculadoraMedia();
                        break;
                    case "0":
                        continuar = false;
                        break;
                    default:
                        Console.WriteLine("❌ Opção inválida!");
                        break;
                }

                if (continuar && opcao != "0")
                {
                    Console.WriteLine("\n" + new string('═', 50));
                }
            }
        }
    }
}