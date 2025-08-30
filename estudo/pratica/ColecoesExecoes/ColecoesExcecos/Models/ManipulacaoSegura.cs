using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ExcecoesColecoes
{
    public static class ManipulacaoSegura
    {
        public static void Demonstrar()
        {
            // 1. Manipulação segura de listas
            Console.WriteLine("=== MANIPULAÇÃO SEGURA DE LISTAS ===");
            var numeros = new List<int> { 1, 2, 3, 4, 5 };

            try
            {
                // Acesso seguro a índices
                int elemento = numeros.ElementAtOrDefault(10);
                Console.WriteLine($"Elemento 10: {elemento} (default: 0)");

                // FirstOrDefault em vez de First
                int primeiroPar = numeros.FirstOrDefault(x => x % 2 == 0);
                Console.WriteLine($"Primeiro par: {primeiroPar}");

                // SingleOrDefault com verificação
                int unico = numeros.SingleOrDefault(x => x == 3);
                if (unico != default)
                    Console.WriteLine($"Elemento único: {unico}");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Erro na operação: {ex.Message}");
            }

            // 2. Manipulação segura de dicionários
            Console.WriteLine("\n=== MANIPULAÇÃO SEGURA DE DICIONÁRIOS ===");
            var dicionario = new Dictionary<string, int>
            {
                ["chave1"] = 100,
                ["chave2"] = 200
            };

            // TryGetValue em vez de acesso direto
            if (dicionario.TryGetValue("chave1", out int valor))
                Console.WriteLine($"Valor da chave1: {valor}");
            else
                Console.WriteLine("Chave1 não encontrada");

            // Add seguro
            if (!dicionario.ContainsKey("chave3"))
                dicionario.Add("chave3", 300);

            // 3. Manipulação de arquivos com exceções
            Console.WriteLine("\n=== MANIPULAÇÃO DE ARQUIVOS COM EXCEÇÕES ===");
            LerArquivoSeguro("arquivo.txt");

            // 4. Validação de entrada do usuário
            Console.WriteLine("\n=== VALIDAÇÃO DE ENTRADA DO USUÁRIO ===");
            ProcessarEntradaUsuario();

            // 5. Rollback automático com using
            Console.WriteLine("\n=== ROLLBACK AUTOMÁTICO ===");
            UsarRecursosComSeguranca();
        }

        private static void LerArquivoSeguro(string caminho)
        {
            try
            {
                if (!File.Exists(caminho))
                    throw new FileNotFoundException("Arquivo não encontrado");

                string[] linhas = File.ReadAllLines(caminho);
                Console.WriteLine($"Linhas lidas: {linhas.Length}");
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Erro de I/O: {ex.Message}");
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine($"Acesso negado: {ex.Message}");
            }
        }

        private static void ProcessarEntradaUsuario()
        {
            try
            {
                Console.Write("Digite um número entre 1-100: ");
                string input = Console.ReadLine();

                if (string.IsNullOrEmpty(input))
                    throw new ArgumentException("Entrada não pode ser vazia");

                if (!int.TryParse(input, out int numero))
                    throw new FormatException("Número inválido");

                if (numero < 1 || numero > 100)
                    throw new ArgumentOutOfRangeException("Número fora do intervalo");

                Console.WriteLine($"Número válido: {numero}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Entrada inválida: {ex.Message}");
            }
        }

        private static void UsarRecursosComSeguranca()
        {
            // Simulação de recursos que precisam de dispose
            var recursos = new List<IDisposable>();

            try
            {
                // Aquisição de recursos
                var recurso1 = new RecursoSimulado("Recurso 1");
                var recurso2 = new RecursoSimulado("Recurso 2");

                recursos.Add(recurso1);
                recursos.Add(recurso2);

                Console.WriteLine("Recursos adquiridos");
                throw new InvalidOperationException("Erro durante o processamento");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
            finally
            {
                // Liberação segura de recursos
                foreach (var recurso in recursos)
                {
                    recurso?.Dispose();
                }
                Console.WriteLine("Recursos liberados");
            }
        }
    }

    public class RecursoSimulado : IDisposable
    {
        public string Nome { get; }

        public RecursoSimulado(string nome)
        {
            Nome = nome;
            Console.WriteLine($"Criado: {Nome}");
        }

        public void Dispose()
        {
            Console.WriteLine($"Disposed: {Nome}");
        }
    }
}