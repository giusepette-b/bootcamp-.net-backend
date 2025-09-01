using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace NugetSerializacaoAtributos.Models
{
    public static class NewtonsoftJsonDemo
    {
        public static void Demonstrar()
        {
            Console.WriteLine("=== NEWTONSOFT.JSON (JSON.NET) ===\n");
            
            // Caminho do arquivo JSON que será criado/lido
            string caminhoArquivo = "dados_produtos.json";
            
            // ==================================================================
            // 1. CRIANDO DADOS PARA SERIALIZAR
            // ==================================================================
            Console.WriteLine("1. CRIANDO DADOS PARA SERIALIZAR:");
            
            var produtos = new List<ProdutoNewtonsoft>
            {
                new ProdutoNewtonsoft 
                { 
                    Id = 1, 
                    Nome = "Notebook Gamer", 
                    Preco = 3549.99m,
                    Categoria = "Eletrônicos",
                    DataFabricacao = new DateTime(2024, 1, 15),
                    Especificacoes = new Dictionary<string, string>
                    {
                        ["Processador"] = "Intel i7",
                        ["Memória"] = "16GB RAM",
                        ["Armazenamento"] = "512GB SSD"
                    }
                },
                new ProdutoNewtonsoft 
                { 
                    Id = 2, 
                    Nome = "Mouse Sem Fio", 
                    Preco = 89.90m,
                    Categoria = "Periféricos",
                    DataFabricacao = new DateTime(2024, 3, 10),
                    Especificacoes = new Dictionary<string, string>
                    {
                        ["Tipo"] = "Óptico",
                        ["Conexão"] = "Bluetooth",
                        ["Bateria"] = "2 anos"
                    }
                }
            };

            // Exibir dados originais
            foreach (var produto in produtos)
            {
                Console.WriteLine($"   {produto.Nome} - {produto.Preco:C}");
            }

            // ==================================================================
            // 2. SERIALIZAÇÃO PARA JSON (OBJETO → STRING JSON)
            // ==================================================================
            Console.WriteLine("\n2. SERIALIZAÇÃO PARA JSON:");
            
            // Serialização básica
            string json = JsonConvert.SerializeObject(produtos);
            Console.WriteLine("JSON básico:");
            Console.WriteLine(json);

            // Serialização com formatação
            string jsonFormatado = JsonConvert.SerializeObject(produtos, Formatting.Indented);
            Console.WriteLine("\nJSON formatado:");
            Console.WriteLine(jsonFormatado);

            // ==================================================================
            // 3. ESCRITA EM ARQUIVO (JSON → ARQUIVO .JSON)
            // ==================================================================
            Console.WriteLine("\n3. ESCRITA EM ARQUIVO:");
            
            // Escrever JSON formatado no arquivo
            File.WriteAllText(caminhoArquivo, jsonFormatado);
            Console.WriteLine($"✅ Arquivo salvo: {Path.GetFullPath(caminhoArquivo)}");
            
            // Verificar se arquivo foi criado
            if (File.Exists(caminhoArquivo))
            {
                Console.WriteLine($"   Tamanho do arquivo: {new FileInfo(caminhoArquivo).Length} bytes");
            }

            // ==================================================================
            // 4. LEITURA DE ARQUIVO (ARQUIVO .JSON → STRING JSON)
            // ==================================================================
            Console.WriteLine("\n4. LEITURA DE ARQUIVO:");
            
            // Ler conteúdo do arquivo
            string jsonDoArquivo = File.ReadAllText(caminhoArquivo);
            Console.WriteLine("Conteúdo do arquivo lido:");
            Console.WriteLine(jsonDoArquivo);

            // ==================================================================
            // 5. DESSERIALIZAÇÃO (STRING JSON → OBJETO)
            // ==================================================================
            Console.WriteLine("\n5. DESSERIALIZAÇÃO:");
            
            // Desserializar de volta para lista de objetos
            List<ProdutoNewtonsoft> produtosDesserializados = 
                JsonConvert.DeserializeObject<List<ProdutoNewtonsoft>>(jsonDoArquivo);
            
            Console.WriteLine("Produtos desserializados:");
            foreach (var produto in produtosDesserializados)
            {
                Console.WriteLine($"   {produto.Nome} - {produto.Preco:C}");
            }

            // ==================================================================
            // 6. CONFIGURAÇÕES AVANÇADAS DO NEWTONSOFT.JSON
            // ==================================================================
            Console.WriteLine("\n6. CONFIGURAÇÕES AVANÇADAS:");
            
            var settings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                ContractResolver = new CamelCasePropertyNamesContractResolver(), // camelCase
                NullValueHandling = NullValueHandling.Ignore, // Ignorar valores nulos
                DateFormatString = "dd/MM/yyyy HH:mm:ss", // Formato de data
                Culture = System.Globalization.CultureInfo.InvariantCulture // Cultura invariante
            };

            // Serializar com configurações customizadas
            string jsonCustomizado = JsonConvert.SerializeObject(produtos[0], settings);
            Console.WriteLine("JSON com configurações customizadas:");
            Console.WriteLine(jsonCustomizado);

            // ==================================================================
            // 7. ATRIBUTOS DO NEWTONSOFT.JSON
            // ==================================================================
            Console.WriteLine("\n7. ATRIBUTOS DO JSON.NET:");
            
            var produtoComAtributos = new ProdutoComAtributosNewtonsoft
            {
                Id = 100,
                Nome = "Smartphone Premium",
                Preco = 2999.99m,
                IgnorarEsteCampo = "Este será ignorado",
                DataCriacao = DateTime.Now
            };

            string jsonComAtributos = JsonConvert.SerializeObject(produtoComAtributos, Formatting.Indented);
            Console.WriteLine("JSON com atributos personalizados:");
            Console.WriteLine(jsonComAtributos);

            // ==================================================================
            // 8. MANIPULAÇÃO DE ERROS E EXCEÇÕES
            // ==================================================================
            Console.WriteLine("\n8. MANIPULAÇÃO DE ERROS:");
            
            try
            {
                // JSON inválido para testar tratamento de erro
                string jsonInvalido = "{'Nome': 'Teste', 'Preco': 'invalido'}";
                var produtoInvalido = JsonConvert.DeserializeObject<ProdutoNewtonsoft>(jsonInvalido);
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"❌ Erro de desserialização: {ex.Message}");
            }

            // ==================================================================
            // 9. SERIALIZAÇÃO/DESSERIALIZAÇÃO DE TIPOS COMPLEXOS
            // ==================================================================
            Console.WriteLine("\n9. TIPOS COMPLEXOS:");
            
            // Serializar objeto complexo
            var pedido = new Pedido
            {
                Id = 1001,
                Cliente = "João Silva",
                Itens = produtos,
                DataPedido = DateTime.Now
            };

            string jsonPedido = JsonConvert.SerializeObject(pedido, Formatting.Indented);
            Console.WriteLine("JSON de pedido complexo:");
            Console.WriteLine(jsonPedido);

            // Desserializar objeto complexo
            var pedidoDesserializado = JsonConvert.DeserializeObject<Pedido>(jsonPedido);
            Console.WriteLine($"Pedido desserializado: #{pedidoDesserializado.Id} - {pedidoDesserializado.Cliente}");

            // ==================================================================
            // 10. COMPARAÇÃO COM SYSTEM.TEXT.JSON (NATIVO)
            // ==================================================================
            Console.WriteLine("\n10. COMPARAÇÃO COM SYSTEM.TEXT.JSON:");
            Console.WriteLine("   ✅ Newtonsoft.Json: Mais features, mais maduro");
            Console.WriteLine("   ✅ System.Text.Json: Mais rápido, nativo do .NET");
            Console.WriteLine("   ✅ Newtonsoft: Melhor para cenários complexos");
            Console.WriteLine("   ✅ System.Text.Json: Melhor para performance");

            // ==================================================================
            // 11. LIMPEZA - EXCLUIR ARQUIVO TEMPORÁRIO (OPCIONAL)
            // ==================================================================
            Console.WriteLine("\n11. LIMPEZA:");
            // File.Delete(caminhoArquivo); // Descomente para excluir o arquivo
            Console.WriteLine($"   Arquivo mantido para referência: {caminhoArquivo}");
        }
    }

    // ==================================================================
    // CLASSES PARA SERIALIZAÇÃO COM NEWTONSOFT.JSON
    // ==================================================================

    public class ProdutoNewtonsoft
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public string Categoria { get; set; }
        public DateTime DataFabricacao { get; set; }
        public Dictionary<string, string> Especificacoes { get; set; }
    }

    public class ProdutoComAtributosNewtonsoft
    {
        [JsonProperty("id")] // Customizar nome da propriedade no JSON
        public int Id { get; set; }
        
        [JsonProperty("nomeProduto")]
        public string Nome { get; set; }
        
        [JsonIgnore] // Ignorar esta propriedade na serialização
        public string IgnorarEsteCampo { get; set; }
        
        [JsonProperty("preco")]
        public decimal Preco { get; set; }
        
        [JsonProperty("dataCriacao")]
        public DateTime DataCriacao { get; set; }
    }

    public class Pedido
    {
        public int Id { get; set; }
        public string Cliente { get; set; }
        public List<ProdutoNewtonsoft> Itens { get; set; }
        public DateTime DataPedido { get; set; }
        public decimal Total => CalcularTotal();

        private decimal CalcularTotal()
        {
            decimal total = 0;
            foreach (var item in Itens)
            {
                total += item.Preco;
            }
            return total;
        }
    }
}