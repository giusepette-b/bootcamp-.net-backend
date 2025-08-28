using System;
using OperadoresAritmeticos.ArithmeticOperations;
using OperadoresAritmeticosEMath.ArithmeticOperations;

namespace OperadoresAritmeticos
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("🧮 CALCULADORA DIDÁTICA - OPERADORES ARITMÉTICOS");
            Console.WriteLine("===============================================\n");

            // Demonstração dos operadores
            DemonstrarOperadoresBasicos();

            // Calculadora interativa
            ExecutarCalculadora();

            // Operadores avançados
            DemonstrarOperadoresAvancados();

            Console.WriteLine("\n" + new string('═', 60));
            MathTrigExample.DemonstrarFuncoesTrigonometricas();

            Console.WriteLine("\n" + new string('═', 60));
            MathTrigExample.DemonstrarMathAvancado();
        }

        static void DemonstrarOperadoresBasicos()
        {
            Console.WriteLine("📚 DEMONSTRAÇÃO DOS OPERADORES BÁSICOS");
            Console.WriteLine("======================================");

            AdicaoExample.DemonstrarAdicao();
            Console.WriteLine();

            SubtracaoExample.DemonstrarSubtracao();
            Console.WriteLine();

            MultiplicacaoExample.DemonstrarMultiplicacao();
            Console.WriteLine();

            DivisaoExample.DemonstrarDivisao();
            Console.WriteLine();

            ModuloExample.DemonstrarModulo();
            Console.WriteLine();
        }

        static void ExecutarCalculadora()
        {
            Console.WriteLine("🎮 MODO CALCULADORA INTERATIVA");
            Console.WriteLine("==============================");

            bool continuar = true;

            while (continuar)
            {
                Console.WriteLine("\nEscolha uma operação:");
                Console.WriteLine("1 ➕ Adição");
                Console.WriteLine("2 ➖ Subtração");
                Console.WriteLine("3 ✖️  Multiplicação");
                Console.WriteLine("4 ➗ Divisão");
                Console.WriteLine("5 🔍 Módulo (Resto)");
                Console.WriteLine("6 🧠 Todas as Operações");
                Console.WriteLine("0 ❌ Sair");

                Console.Write("\nDigite sua opção: ");
                string opcao = Console.ReadLine();

                if (opcao == "0")
                {
                    continuar = false;
                    continue;
                }

                // Obter inputs do usuário
                double num1 = LerNumero("Digite o primeiro número: ");
                double num2 = LerNumero("Digite o segundo número: ");

                Console.WriteLine();

                // Executar operação escolhida
                switch (opcao)
                {
                    case "1":
                        CalculadoraAvancada.CalcularAdicao(num1, num2);
                        break;
                    case "2":
                        CalculadoraAvancada.CalcularSubtracao(num1, num2);
                        break;
                    case "3":
                        CalculadoraAvancada.CalcularMultiplicacao(num1, num2);
                        break;
                    case "4":
                        CalculadoraAvancada.CalcularDivisao(num1, num2);
                        break;
                    case "5":
                        CalculadoraAvancada.CalcularModulo(num1, num2);
                        break;
                    case "6":
                        CalculadoraAvancada.CalcularTodasOperacoes(num1, num2);
                        break;
                    default:
                        Console.WriteLine("❌ Opção inválida!");
                        break;
                }

                Console.WriteLine("\n" + new string('═', 50));
            }

            Console.WriteLine("\nObrigado por usar a calculadora! 👋");
        }

        static void DemonstrarOperadoresAvancados()
        {
            Console.WriteLine("\n⚡ OPERADORES AVANÇADOS");
            Console.WriteLine("======================");

            IncrementoExample.DemonstrarIncremento();
            Console.WriteLine();

            // Demonstração de precedência
            Console.WriteLine("🔢 PRECEDÊNCIA DE OPERADORES");
            Console.WriteLine("============================");

            double resultado = 10 + 5 * 2; // 10 + (5 * 2) = 20
            Console.WriteLine($"10 + 5 * 2 = {resultado}");

            resultado = (10 + 5) * 2; // (10 + 5) * 2 = 30
            Console.WriteLine($"(10 + 5) * 2 = {resultado}");
        }

        // Método auxiliar para ler números
        static double LerNumero(string mensagem)
        {
            while (true)
            {
                Console.Write(mensagem);
                string input = Console.ReadLine();

                if (double.TryParse(input, out double numero))
                {
                    return numero;
                }

                Console.WriteLine("❌ Valor inválido! Digite um número.");
            }
        }


    }
}