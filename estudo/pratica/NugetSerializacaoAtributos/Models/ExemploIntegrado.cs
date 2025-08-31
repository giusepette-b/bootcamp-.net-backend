using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;


namespace NugetSerializacaoAtributos.Models
{
    public static class ExemploIntegrado
    {
        public static void Demonstrar()
        {
            Console.WriteLine("=== EXEMPLO INTEGRADO: NUGET + SERIALIZAÇÃO + ATRIBUTOS ===\n");

            // ==================================================================
            // 1. CRIAÇÃO DE DADOS COM ATRIBUTOS DE VALIDAÇÃO
            // ==================================================================
            Console.WriteLine("1. CRIAÇÃO COM VALIDAÇÃO:");

            var pedido = new PedidoCompleto
            {
                Id = 1001,
                Cliente = new Cliente
                {
                    Nome = "João Silva",
                    Email = "joao@email.com",
                    Endereco = "Rua das Flores, 123"
                },
                Itens = new List<ItemPedido>
                {
                    new ItemPedido { ProdutoId = 1, Nome = "Mouse", Preco = 89.90m, Quantidade = 2 },
                    new ItemPedido { ProdutoId = 2, Nome = "Teclado", Preco = 199.50m, Quantidade = 1 }
                },
                Status = StatusPedido.Processando,
                DataCriacao = DateTime.Now
            };

            // ==================================================================
            // 2. VALIDAÇÃO DOS DADOS
            // ==================================================================
            Console.WriteLine("2. VALIDAÇÃO AUTOMÁTICA:");

            var resultados = new List<ValidationResult>();
            bool valido = Validator.TryValidateObject(pedido,
                new ValidationContext(pedido), resultados, true);

            Console.WriteLine($"Pedido válido: {valido}");
            if (!valido)
            {
                foreach (var erro in resultados)
                {
                    Console.WriteLine($"   Erro: {erro.ErrorMessage}");
                }
            }

            // ==================================================================
            // 3. SERIALIZAÇÃO PARA JSON
            // ==================================================================
            Console.WriteLine("\n3. SERIALIZAÇÃO JSON:");

            var opcoes = new JsonSerializerOptions
            {
                WriteIndented = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            string json = JsonSerializer.Serialize(pedido, opcoes);
            Console.WriteLine("JSON do pedido:");
            Console.WriteLine(json);

            // ==================================================================
            // 4. DESSERIALIZAÇÃO DE VOLTA PARA OBJETO
            // ==================================================================
            Console.WriteLine("\n4. DESSERIALIZAÇÃO:");

            PedidoCompleto pedidoDesserializado = JsonSerializer.Deserialize<PedidoCompleto>(json);
            Console.WriteLine($"Pedido desserializado: #{pedidoDesserializado.Id}");
            Console.WriteLine($"Cliente: {pedidoDesserializado.Cliente.Nome}");
            Console.WriteLine($"Total: {pedidoDesserializado.CalcularTotal():C}");

            // ==================================================================
            // 5. SIMULAÇÃO DE USO DE PACOTE EXTERNO
            // ==================================================================
            Console.WriteLine("\n5. SIMULAÇÃO DE PACOTE EXTERNO:");

            // Simulando um pacote como AutoMapper ou Dapper
            Console.WriteLine("Simulando mapeamento com AutoMapper...");
            var pedidoResumo = MapearParaResumo(pedido);
            Console.WriteLine($"Resumo: {pedidoResumo.ClienteNome} - {pedidoResumo.Total:C}");

            Console.WriteLine("Simulando consulta com Dapper...");
            var pedidos = ConsultarPedidos();
            Console.WriteLine($"Pedidos encontrados: {pedidos.Count}");

            // ==================================================================
            // 6. EXEMPLO DE CONFIGURAÇÃO
            // ==================================================================
            Console.WriteLine("\n6. CONFIGURAÇÃO COMPLETA:");
            Console.WriteLine("✅ Atributos para validação de dados");
            Console.WriteLine("✅ Serialização JSON nativa");
            Console.WriteLine("✅ Estrutura preparada para pacotes NuGet");
            Console.WriteLine("✅ Código limpo e organizado");
        }

        // Simulação de mapeamento (como AutoMapper faria)
        private static PedidoResumo MapearParaResumo(PedidoCompleto pedido)
        {
            return new PedidoResumo
            {
                PedidoId = pedido.Id,
                ClienteNome = pedido.Cliente.Nome,
                Total = pedido.CalcularTotal(),
                Status = pedido.Status
            };
        }

        // Simulação de consulta (como Dapper faria)
        private static List<PedidoCompleto> ConsultarPedidos()
        {
            return new List<PedidoCompleto> { new PedidoCompleto { Id = 1001 } };
        }
    }

    // ==================================================================
    // CLASSES PARA O EXEMPLO INTEGRADO
    // ==================================================================
    public class PedidoCompleto
    {
        [Required]
        [Range(1, 9999)]
        public int Id { get; set; }

        [Required]
        public Cliente Cliente { get; set; }

        [Required]
        [MinLength(1, ErrorMessage = "Pedido deve ter pelo menos 1 item")]
        public List<ItemPedido> Itens { get; set; }

        public StatusPedido Status { get; set; }

        public DateTime DataCriacao { get; set; }

        public decimal CalcularTotal()
        {
            decimal total = 0;
            foreach (var item in Itens)
            {
                total += item.Preco * item.Quantidade;
            }
            return total;
        }
    }

    public class Cliente
    {
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Nome { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string Endereco { get; set; }
    }

    public class ItemPedido
    {
        [Required]
        public int ProdutoId { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        [Range(0.01, 10000)]
        public decimal Preco { get; set; }

        [Required]
        [Range(1, 100)]
        public int Quantidade { get; set; }
    }

    public class PedidoResumo
    {
        public int PedidoId { get; set; }
        public string ClienteNome { get; set; }
        public decimal Total { get; set; }
        public StatusPedido Status { get; set; }
    }
}