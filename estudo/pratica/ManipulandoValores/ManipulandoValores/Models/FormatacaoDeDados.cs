using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManipulandoValores.Models

{
    public static class FormatacaoDados
    {
        public static void Demonstrar()
        {
            Console.WriteLine("=== FORMATAÇÃO DE DADOS EM C# ===\n");

            // Dados de exemplo
            var produtos = new List<Produto>
            {
                new Produto { Id = 1, Nome = "Notebook Gamer", Preco = 3549.99m, DataFabricacao = new DateTime(2024, 1, 15), Estoque = 12 },
                new Produto { Id = 2, Nome = "Mouse Sem Fio", Preco = 89.90m, DataFabricacao = new DateTime(2024, 3, 10), Estoque = 45 },
                new Produto { Id = 3, Nome = "Teclado Mecânico", Preco = 299.50m, DataFabricacao = new DateTime(2024, 2, 20), Estoque = 8 },
                new Produto { Id = 4, Nome = "Monitor 24\"", Preco = 899.00m, DataFabricacao = new DateTime(2023, 12, 5), Estoque = 15 }
            };

            // 1. Formatação básica de strings
            Console.WriteLine("1. FORMATAÇÃO BÁSICA DE STRINGS:");
            Console.WriteLine(string.Format("Produto: {0}, Preço: {1:C}", produtos[0].Nome, produtos[0].Preco));
            Console.WriteLine($"Produto: {produtos[1].Nome}, Preço: {produtos[1].Preco:C}");
            Console.WriteLine();

            // 2. Formatação de números
            Console.WriteLine("2. FORMATAÇÃO DE NÚMEROS:");
            foreach (var produto in produtos)
            {
                Console.WriteLine($"{produto.Nome,-20} | {produto.Preco,10:C} | {produto.Preco,10:N2} | {produto.Estoque,5:D3} unidades");
            }
            Console.WriteLine();

            // 3. Formatação de datas
            Console.WriteLine("3. FORMATAÇÃO DE DATAS:");
            foreach (var produto in produtos)
            {
                Console.WriteLine($"{produto.Nome,-15} | Fabricação: {produto.DataFabricacao:dd/MM/yyyy} | {produto.DataFabricacao:dddd} | {produto.DataFabricacao:HH:mm:ss}");
                Console.WriteLine($"               Formato longo: {produto.DataFabricacao:D}");
                Console.WriteLine($"               Formato curto: {produto.DataFabricacao:d}");
            }
            Console.WriteLine();

            // 4. Formatação personalizada
            Console.WriteLine("4. FORMATAÇÃO PERSONALIZADA:");
            Console.WriteLine($"Preço formatado: {1234.567m:###,##0.00}");
            Console.WriteLine($"Número telefone: {11987654321:###-####-####}");
            Console.WriteLine($"Porcentagem: {0.4567:P2}");
            Console.WriteLine($"Valor hexadecimal: {255:X}");
            Console.WriteLine();

            // 5. Formatação com diferentes culturas
            Console.WriteLine("5. FORMATAÇÃO COM DIFERENTES CULTURAS:");
            decimal valor = 1234.56m;

            Console.WriteLine($"Brasil (pt-BR): {valor.ToString("C", new CultureInfo("pt-BR"))}");
            Console.WriteLine($"EUA (en-US): {valor.ToString("C", new CultureInfo("en-US"))}");
            Console.WriteLine($"Europa (de-DE): {valor.ToString("C", new CultureInfo("de-DE"))}");
            Console.WriteLine($"Japão (ja-JP): {valor.ToString("C", new CultureInfo("ja-JP"))}");
            Console.WriteLine();

            // 6. Formatação condicional
            Console.WriteLine("6. FORMATAÇÃO CONDICIONAL:");
            foreach (var produto in produtos)
            {
                string statusEstoque = produto.Estoque switch
                {
                    > 20 => "✅ Estoque bom",
                    > 10 => "⚠️  Estoque médio",
                    > 0 => "❌ Estoque baixo",
                    _ => "🚫 Esgotado"
                };

                string precoCategoria = produto.Preco switch
                {
                    > 1000 => "🟪 Premium",
                    > 500 => "🟩 Intermediário",
                    _ => "🟦 Básico"
                };

                Console.WriteLine($"{produto.Nome,-20} | {statusEstoque,-20} | {precoCategoria,-15} | {produto.Preco:C}");
            }
            Console.WriteLine();

            // 7. Formatação de coleções
            Console.WriteLine("7. FORMATAÇÃO DE COLEÇÕES:");
            string produtosFormatados = string.Join("\n  ", produtos.Select(p =>
                $"{p.Nome} - {p.Preco:C} (Estoque: {p.Estoque})"));
            Console.WriteLine("Lista de produtos:\n  " + produtosFormatados);
            Console.WriteLine();

            // 8. Métodos ToString personalizados
            Console.WriteLine("8. ToString() PERSONALIZADO:");
            foreach (var produto in produtos)
            {
                Console.WriteLine(produto.ToString());
            }
            Console.WriteLine();

            // 9. Formatação com alinhamento
            Console.WriteLine("9. FORMATAÇÃO COM ALINHAMENTO:");
            Console.WriteLine("┌─────────────────────┬──────────────┬──────────────┐");
            Console.WriteLine("│ Nome                │ Preço        │ Estoque      │");
            Console.WriteLine("├─────────────────────┼──────────────┼──────────────┤");

            foreach (var produto in produtos)
            {
                Console.WriteLine($"│ {produto.Nome,-20} │ {produto.Preco,12:C} │ {produto.Estoque,12} │");
            }

            Console.WriteLine("└─────────────────────┴──────────────┴──────────────┘");
            Console.WriteLine();

            // 10. Formatação de dados complexos
            Console.WriteLine("10. FORMATAÇÃO DE DADOS COMPLEXOS:");
            var relatorio = produtos.Select(p => new
            {
                p.Nome,
                PrecoFormatado = p.Preco.ToString("C", new CultureInfo("pt-BR")),
                DataFormatada = p.DataFabricacao.ToString("yyyy-MM-dd"),
                Status = p.Estoque > 10 ? "Disponível" : "Baixo Estoque"
            });

            foreach (var item in relatorio)
            {
                Console.WriteLine($"{item.Nome} | {item.PrecoFormatado} | {item.DataFormatada} | {item.Status}");
            }
        }
    }

    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public DateTime DataFabricacao { get; set; }
        public int Estoque { get; set; }

        // ToString personalizado
        public override string ToString()
        {
            return $"{Nome} - {Preco:C} (Fabricado em: {DataFabricacao:dd/MM/yyyy}, Estoque: {Estoque})";
        }

        // Método de formatação customizado
        public string ToString(string format)
        {
            return format.ToUpper() switch
            {
                "RESUMIDO" => $"{Nome} - {Preco:C}",
                "DETALHADO" => $"{Nome} | Preço: {Preco:C} | Fabricação: {DataFabricacao:dd/MM/yyyy} | Estoque: {Estoque}",
                "CSV" => $"{Id};{Nome};{Preco};{DataFabricacao:yyyy-MM-dd};{Estoque}",
                "JSON" => $"{{ \"id\": {Id}, \"nome\": \"{Nome}\", \"preco\": {Preco}, \"estoque\": {Estoque} }}",
                _ => ToString()
            };
        }
    }
}