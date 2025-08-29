using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoopsRepeticao.LoopExamples
{
    public static class ExerciciosInterativos
    {
        public static void ContagemRegressiva()
        {
            Console.WriteLine("⏰ CONTAGEM REGRESSIVA");
            Console.Write("Digite o número inicial: ");
            if (int.TryParse(Console.ReadLine(), out int inicio) && inicio > 0)
            {
                Console.WriteLine($"Contagem regressiva de {inicio} até 0:");
                for (int i = inicio; i >= 0; i--)
                {
                    Console.WriteLine($"{i}...");
                    System.Threading.Thread.Sleep(1000); // Pausa de 1 segundo
                }
                Console.WriteLine("🎉 Feliz Ano Novo!");
            }
            else
            {
                Console.WriteLine("Número inválido!");
            }
        }

        public static void TabuadaInterativa()
        {
            Console.WriteLine("🧮 TABUADA INTERATIVA");
            Console.Write("Digite o número para a tabuada: ");

            if (int.TryParse(Console.ReadLine(), out int numero))
            {
                Console.WriteLine($"\nTabuada do {numero}:");
                for (int i = 1; i <= 10; i++)
                {
                    Console.WriteLine($"{numero} x {i} = {numero * i}");
                }
            }
            else
            {
                Console.WriteLine("Número inválido!");
            }
        }

        public static void AdivinheONumero()
        {
            Console.WriteLine("🎯 ADIVINHE O NÚMERO");
            Random random = new Random();
            int numeroSecreto = random.Next(1, 101);
            int tentativas = 0;
            int palpite;

            Console.WriteLine("Estou pensando em um número entre 1 e 100...");

            do
            {
                Console.Write("Seu palpite: ");
                tentativas++;

                if (!int.TryParse(Console.ReadLine(), out palpite))
                {
                    Console.WriteLine("Digite um número válido!");
                    continue;
                }

                if (palpite < numeroSecreto)
                {
                    Console.WriteLine("📈 Muito baixo! Tente mais alto.");
                }
                else if (palpite > numeroSecreto)
                {
                    Console.WriteLine("📉 Muito alto! Tente mais baixo.");
                }
                else
                {
                    Console.WriteLine($"🎉 Parabéns! Você acertou em {tentativas} tentativas!");
                }

            } while (palpite != numeroSecreto);
        }

        public static void CalculadoraMedia()
        {
            Console.WriteLine("📊 CALCULADORA DE MÉDIA");
            List<double> notas = new List<double>();
            string entrada;

            Console.WriteLine("Digite as notas (ou 'calcular' para terminar):");

            do
            {
                Console.Write("Nota: ");
                entrada = Console.ReadLine();

                if (entrada.ToLower() == "calcular")
                {
                    break;
                }

                if (double.TryParse(entrada, out double nota) && nota >= 0 && nota <= 10)
                {
                    notas.Add(nota);
                    Console.WriteLine($"Nota {nota} adicionada. Total: {notas.Count} notas");
                }
                else
                {
                    Console.WriteLine("Nota inválida! Digite entre 0 e 10.");
                }

            } while (true);

            if (notas.Count > 0)
            {
                double soma = 0;
                foreach (double nota in notas)
                {
                    soma += nota;
                }
                double media = soma / notas.Count;

                Console.WriteLine($"\n📈 Estatísticas:");
                Console.WriteLine($"Total de notas: {notas.Count}");
                Console.WriteLine($"Soma: {soma:F2}");
                Console.WriteLine($"Média: {media:F2}");

                if (media >= 7) Console.WriteLine("✅ Aprovado!");
                else if (media >= 5) Console.WriteLine("📋 Recuperação");
                else Console.WriteLine("❌ Reprovado");
            }
            else
            {
                Console.WriteLine("Nenhuma nota foi informada.");
            }
        }
    }
}