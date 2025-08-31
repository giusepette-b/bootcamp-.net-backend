using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization; // ✅ DIRETIVA USING FALTANDO
using System.ComponentModel.DataAnnotations; // ✅ Para validação

namespace NugetSerializacaoAtributos.Models
{
    public static class SerializacaoJson
    {
        public static void Demonstrar()
        {
            Console.WriteLine("=== SERIALIZAÇÃO JSON COM SYSTEM.TEXT.JSON ===\n");

            // ==================================================================
            // 1. CRIAÇÃO DE OBJETO PARA SERIALIZAR
            // ==================================================================
            var produto = new Produto
            {
                Id = 1,
                Nome = "Notebook Gamer",
                Preco = 3549.99m,
                DataFabricacao = new DateTime(2024, 1, 15),
                Categoria = "Eletrônicos",
                Especificacoes = new Dictionary<string, string>
                {
                    ["Processador"] = "Intel i7",
                    ["Memória"] = "16GB RAM",
                    ["Armazenamento"] = "512GB SSD"
                }
            };

            // ==================================================================
            // 2. SERIALIZAÇÃO BÁSICA - OBJETO → JSON
            // ==================================================================
            Console.WriteLine("2. SERIALIZAÇÃO BÁSICA:");

            // Serializar para string JSON
            string jsonBasico = JsonSerializer.Serialize(produto);
            Console.WriteLine("JSON Básico:");
            Console.WriteLine(jsonBasico);

            // Serializar com formatação (indentação)
            var opcoes = new JsonSerializerOptions { WriteIndented = true };
            string jsonFormatado = JsonSerializer.Serialize(produto, opcoes);
            Console.WriteLine("\nJSON Formatado:");
            Console.WriteLine(jsonFormatado);

            // ==================================================================
            // 3. DESERIALIZAÇÃO BÁSICA - JSON → OBJETO
            // ==================================================================
            Console.WriteLine("\n3. DESERIALIZAÇÃO BÁSICA:");

            // Desserializar de volta para objeto
            Produto produtoDesserializado = JsonSerializer.Deserialize<Produto>(jsonBasico);
            Console.WriteLine($"Produto desserializado: {produtoDesserializado.Nome} - {produtoDesserializado.Preco:C}");

            // ==================================================================
            // 4. SERIALIZAÇÃO COM OPÇÕES PERSONALIZADAS
            // ==================================================================
            Console.WriteLine("\n4. OPÇÕES PERSONALIZADAS:");

            var opcoesAvancadas = new JsonSerializerOptions
            {
                WriteIndented = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase, // camelCase
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                Converters = { new JsonStringEnumConverter() } // Converter enums para string
            };

            string jsonCamelCase = JsonSerializer.Serialize(produto, opcoesAvancadas);
            Console.WriteLine("JSON com CamelCase:");
            Console.WriteLine(jsonCamelCase);

            // ==================================================================
            // 5. SERIALIZAÇÃO/DESSERIALIZAÇÃO DE COLEÇÕES
            // ==================================================================
            Console.WriteLine("\n5. SERIALIZAÇÃO DE COLEÇÕES:");

            var produtos = new List<Produto>
            {
                new Produto { Id = 1, Nome = "Mouse", Preco = 89.90m },
                new Produto { Id = 2, Nome = "Teclado", Preco = 199.50m },
                new Produto { Id = 3, Nome = "Monitor", Preco = 899.00m }
            };

            string jsonArray = JsonSerializer.Serialize(produtos, opcoes);
            Console.WriteLine("Array de produtos:");
            Console.WriteLine(jsonArray);

            // Desserializar array
            var produtosDesserializados = JsonSerializer.Deserialize<List<Produto>>(jsonArray);
            Console.WriteLine($"\nProdutos desserializados: {produtosDesserializados.Count} itens");

            // ==================================================================
            // 6. SERIALIZAÇÃO PARA ARQUIVO
            // ==================================================================
            Console.WriteLine("\n6. SERIALIZAÇÃO PARA ARQUIVO:");

            string caminhoArquivo = "produto.json";

            // Serializar para arquivo
            File.WriteAllText(caminhoArquivo, jsonFormatado);
            Console.WriteLine($"JSON salvo em: {Path.GetFullPath(caminhoArquivo)}");

            // Desserializar de arquivo
            string jsonDoArquivo = File.ReadAllText(caminhoArquivo);
            Produto produtoDoArquivo = JsonSerializer.Deserialize<Produto>(jsonDoArquivo);
            Console.WriteLine($"Produto do arquivo: {produtoDoArquivo.Nome}");

            // ==================================================================
            // 7. SERIALIZAÇÃO COM ATRIBUTOS PERSONALIZADOS
            // ==================================================================
            Console.WriteLine("\n7. SERIALIZAÇÃO COM ATRIBUTOS:");

            var produtoComAtributos = new ProdutoComAtributos
            {
                Id = 100,
                Nome = "Smartphone",
                Preco = 1999.99m,
                IgnorarEsteCampo = "Este será ignorado na serialização"
            };

            string jsonComAtributos = JsonSerializer.Serialize(produtoComAtributos, opcoes);
            Console.WriteLine("JSON com atributos personalizados:");
            Console.WriteLine(jsonComAtributos);

            // ==================================================================
            // 8. MANIPULAÇÃO DE DATAS E VALORES ESPECIAIS
            // ==================================================================
            Console.WriteLine("\n8. MANIPULAÇÃO DE DATAS:");

            var produtoComData = new Produto
            {
                Nome = "Produto com Data",
                Preco = 100.00m,
                DataFabricacao = DateTime.Now
            };

            // Serializar com tratamento especial para datas
            var opcoesData = new JsonSerializerOptions
            {
                WriteIndented = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                Converters = { new DateTimeConverter() } // Converter customizado
            };

            string jsonComData = JsonSerializer.Serialize(produtoComData, opcoesData);
            Console.WriteLine("JSON com data customizada:");
            Console.WriteLine(jsonComData);
        }
    }

    // ==================================================================
    // CLASSE DE MODELO BÁSICA
    // ==================================================================
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public string Categoria { get; set; }
        public DateTime DataFabricacao { get; set; }
        public Dictionary<string, string> Especificacoes { get; set; }
    }

    // ==================================================================
    // CLASSE COM ATRIBUTOS DE SERIALIZAÇÃO
    // ==================================================================
    public class ProdutoComAtributos
    {
        [JsonPropertyName("codigo")] // Customizar nome da propriedade
        public int Id { get; set; }

        [JsonPropertyName("nomeProduto")]
        public string Nome { get; set; }

        [JsonIgnore] // Ignorar esta propriedade na serialização
        public string IgnorarEsteCampo { get; set; }

        [JsonConverter(typeof(DecimalConverter))] // Converter customizado
        public decimal Preco { get; set; }
    }

    // ==================================================================
    // CONVERSOR CUSTOMIZADO PARA DECIMAL
    // ==================================================================
    public class DecimalConverter : JsonConverter<decimal>
    {
        public override decimal Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return reader.GetDecimal();
        }

        public override void Write(Utf8JsonWriter writer, decimal value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString("F2")); // Formato com 2 casas decimais
        }
    }

    // ==================================================================
    // CONVERSOR CUSTOMIZADO PARA DATETIME
    // ==================================================================
    public class DateTimeConverter : JsonConverter<DateTime>
    {
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return DateTime.Parse(reader.GetString());
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString("yyyy-MM-dd HH:mm:ss")); // Formato customizado
        }
    }
}