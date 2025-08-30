using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManipulandoValores.Models

{
    public static class LinqConsultas
    {
        public static void Demonstrar()
        {
            List<Produto> produtos = new List<Produto>
            {
                new Produto { Id = 1, Nome = "Notebook", Preco = 2500.00m, Categoria = "Eletrônicos" },
                new Produto { Id = 2, Nome = "Mouse", Preco = 50.00m, Categoria = "Eletrônicos" },
                new Produto { Id = 3, Nome = "Mesa", Preco = 500.00m, Categoria = "Móveis" },
                new Produto { Id = 4, Nome = "Cadeira", Preco = 300.00m, Categoria = "Móveis" },
                new Produto { Id = 5, Nome = "Teclado", Preco = 120.00m, Categoria = "Eletrônicos" }
            };

            // Filtro simples
            var eletronicos = produtos.Where(p => p.Categoria == "Eletrônicos").ToList();
            Console.WriteLine("Eletrônicos:");
            foreach (var item in eletronicos)
            {
                Console.WriteLine($"- {item.Nome}: {item.Preco:C}");
            }

            // Ordenação
            var ordenadosPorPreco = produtos.OrderBy(p => p.Preco).ToList();
            Console.WriteLine("\nOrdenados por preço:");
            foreach (var item in ordenadosPorPreco)
            {
                Console.WriteLine($"- {item.Nome}: {item.Preco:C}");
            }

            // Agregação
            decimal totalEletronicos = produtos
                .Where(p => p.Categoria == "Eletrônicos")
                .Sum(p => p.Preco);

            decimal precoMedio = produtos.Average(p => p.Preco);
            decimal precoMaximo = produtos.Max(p => p.Preco);

            Console.WriteLine($"\nTotal eletrônicos: {totalEletronicos:C}");
            Console.WriteLine($"Preço médio: {precoMedio:C}");
            Console.WriteLine($"Preço máximo: {precoMaximo:C}");

            // Group By
            var porCategoria = produtos.GroupBy(p => p.Categoria);
            Console.WriteLine("\nProdutos por categoria:");
            foreach (var grupo in porCategoria)
            {
                Console.WriteLine($"\nCategoria: {grupo.Key}");
                foreach (var produto in grupo)
                {
                    Console.WriteLine($"- {produto.Nome}: {produto.Preco:C}");
                }
            }

            // Projeção (Select)
            var nomesPrecos = produtos.Select(p => new { p.Nome, p.Preco }).ToList();
            Console.WriteLine("\nNomes e preços:");
            foreach (var item in nomesPrecos)
            {
                Console.WriteLine($"{item.Nome}: {item.Preco:C}");
            }
        }
    }

    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public string Categoria { get; set; }
    }
}