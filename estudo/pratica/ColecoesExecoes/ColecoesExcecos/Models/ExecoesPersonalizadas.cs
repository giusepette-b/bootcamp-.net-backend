using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExcecoesColecoes.Models
{
    public static class ExcecoesPersonalizadas
    {
        public static void Demonstrar()
        {
            // 1. Exceção personalizada básica
            Console.WriteLine("=== EXCEÇÃO PERSONALIZADA BÁSICA ===");
            try
            {
                var produto = new Produto("", -10.0m);
            }
            catch (ProdutoInvalidoException ex)
            {
                Console.WriteLine($"Erro de produto: {ex.Message}");
                Console.WriteLine($"Código do erro: {ex.CodigoErro}");
            }

            // 2. Exceção com inner exception
            Console.WriteLine("\n=== EXCEÇÃO COM INNER EXCEPTION ===");
            try
            {
                ProcessarPedido(0);
            }
            catch (PedidoException ex)
            {
                Console.WriteLine($"Erro no pedido: {ex.Message}");
                Console.WriteLine($"Inner exception: {ex.InnerException?.Message}");
            }

            // 3. Validação com múltiplos erros
            Console.WriteLine("\n=== VALIDAÇÃO COM MÚLTIPLOS ERROS ===");
            try
            {
                ValidarUsuario("", "short", -25);
            }
            catch (ValidacaoException ex)
            {
                Console.WriteLine($"Erros de validação:");
                foreach (var erro in ex.Erros)
                {
                    Console.WriteLine($"- {erro}");
                }
            }

            // 4. Custom exception com dados adicionais
            Console.WriteLine("\n=== EXCEÇÃO COM DADOS ADICIONAIS ===");
            try
            {
                ConectarBanco("servidor_inexistente");
            }
            catch (DatabaseException ex)
            {
                Console.WriteLine($"Erro de banco: {ex.Message}");
                Console.WriteLine($"Servidor: {ex.Servidor}");
                Console.WriteLine($"Código: {ex.CodigoErro}");
                Console.WriteLine($"Hora: {ex.HoraErro:HH:mm:ss}");
            }
        }

        private static void ProcessarPedido(int pedidoId)
        {
            try
            {
                if (pedidoId <= 0)
                    throw new ArgumentException("ID do pedido inválido");

                // Simulação de outro erro
                throw new InvalidOperationException("Erro ao acessar database");
            }
            catch (Exception ex)
            {
                throw new PedidoException("Falha ao processar pedido", ex);
            }
        }

        private static void ValidarUsuario(string nome, string senha, int idade)
        {
            var erros = new List<string>();

            if (string.IsNullOrEmpty(nome))
                erros.Add("Nome é obrigatório");

            if (senha.Length < 6)
                erros.Add("Senha deve ter pelo menos 6 caracteres");

            if (idade < 0)
                erros.Add("Idade não pode ser negativa");

            if (erros.Count > 0)
                throw new ValidacaoException("Validação falhou", erros);
        }

        private static void ConectarBanco(string servidor)
        {
            if (servidor != "localhost")
                throw new DatabaseException("Falha na conexão", "DB_001", servidor);
        }
    }

    // Exceções personalizadas
    public class ProdutoInvalidoException : Exception
    {
        public string CodigoErro { get; }

        public ProdutoInvalidoException(string message, string codigoErro = "PROD_001")
            : base(message)
        {
            CodigoErro = codigoErro;
        }
    }

    public class PedidoException : Exception
    {
        public PedidoException(string message) : base(message) { }
        public PedidoException(string message, Exception inner) : base(message, inner) { }
    }

    public class ValidacaoException : Exception
    {
        public List<string> Erros { get; }

        public ValidacaoException(string message, List<string> erros) : base(message)
        {
            Erros = erros;
        }
    }

    public class DatabaseException : Exception
    {
        public string CodigoErro { get; }
        public string Servidor { get; }
        public DateTime HoraErro { get; }

        public DatabaseException(string message, string codigoErro, string servidor)
            : base(message)
        {
            CodigoErro = codigoErro;
            Servidor = servidor;
            HoraErro = DateTime.Now;
        }
    }

    public class Produto
    {
        public string Nome { get; }
        public decimal Preco { get; }

        public Produto(string nome, decimal preco)
        {
            if (string.IsNullOrEmpty(nome))
                throw new ProdutoInvalidoException("Nome do produto é obrigatório", "PROD_002");

            if (preco <= 0)
                throw new ProdutoInvalidoException("Preço deve ser positivo", "PROD_003");

            Nome = nome;
            Preco = preco;
        }
    }
}