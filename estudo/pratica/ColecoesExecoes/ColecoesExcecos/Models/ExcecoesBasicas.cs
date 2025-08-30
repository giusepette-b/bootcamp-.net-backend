using System;
using System.IO;

namespace ExcecoesColecoes.Models
{
    public static class ExcecoesBasicas
    {

        public static void Demonstrar()
        {
            // 1. Try-Catch básico
            Console.WriteLine("=== TRY-CATCH BÁSICO ===");
            try
            {
                int[] numeros = { 1, 2, 3 };
                Console.WriteLine(numeros[5]); // IndexOutOfRangeException
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine($"Erro de índice: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro genérico: {ex.Message}");
            }

            // 2. Finally
            Console.WriteLine("\n=== BLOCO FINALLY ===");
            FileStream file = null;
            try
            {
                file = File.Open("arquivo_inexistente.txt", FileMode.Open);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"Arquivo não encontrado: {ex.Message}");
            }
            finally
            {
                file?.Close();
                Console.WriteLine("Recursos liberados no finally");
            }

            // 3. Divisão por zero
            Console.WriteLine("\n=== DIVISÃO POR ZERO ===");
            try
            {
                int resultado = Dividir(10, 0);
                Console.WriteLine($"Resultado: {resultado}");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine($"Erro de divisão: {ex.Message}");
            }

            // 4. Formato inválido
            Console.WriteLine("\n=== FORMATO INVÁLIDO ===");
            try
            {
                Console.Write("Digite um número: ");
                string input = Console.ReadLine();
                int numero = int.Parse(input);
                Console.WriteLine($"Número digitado: {numero}");
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Formato inválido: {ex.Message}");
            }
            catch (OverflowException ex)
            {
                Console.WriteLine($"Número muito grande: {ex.Message}");
            }

            // 5. Throw exception
            Console.WriteLine("\n=== LANÇAMENTO DE EXCEÇÃO ===");
            try
            {
                ValidarIdade(15);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Validação falhou: {ex.Message}");
            }
        }

        private static int Dividir(int a, int b)
        {
            if (b == 0)
                throw new DivideByZeroException("Divisor não pode ser zero");
            return a / b;
        }

        private static void ValidarIdade(int idade)
        {
            if (idade < 18)
                throw new ArgumentException("Idade mínima é 18 anos");
            Console.WriteLine("Idade válida");
        }
    }
}