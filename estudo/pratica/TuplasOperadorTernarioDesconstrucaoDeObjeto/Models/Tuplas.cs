using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TuplasOperadorTernarioDesconstrucaoDeObjeto.Models

{
    public static class Tuplas
    {
        public static void Demonstrar()
        {
            Console.WriteLine("=== TUPLAS EM C# ===\n");

            // ==================================================================
            // TUPLAS BÁSICAS - Conceito introduzido no C# 7.0
            // ==================================================================
            // Sua declaração consiste em declarar dois tipos de dados diferentes antes entre parênteses.

            // 1. Tupla simples - agrupa múltiplos valores sem criar classe
            (string, int) pessoa1 = ("João", 30);
            Console.WriteLine($"1. Tupla simples: Nome: {pessoa1.Item1}, Idade: {pessoa1.Item2}");

            // 2. Tupla com nomes - mais legível que Item1, Item2
            (string Nome, int Idade) pessoa2 = ("Maria", 25);
            Console.WriteLine($"2. Tupla nomeada: Nome: {pessoa2.Nome}, Idade: {pessoa2.Idade}");

            // 3. Inferência de tipos com var
            var pessoa3 = (Nome: "Pedro", Idade: 35, Ativo: true);
            Console.WriteLine($"3. Tupla com var: {pessoa3.Nome}, {pessoa3.Idade}, Ativo: {pessoa3.Ativo}");

            // ==================================================================
            // MÉTODOS QUE RETORNAM TUPLAS - Muito útil para múltiplos retornos
            // ==================================================================

            // 4. Método retornando tupla
            var resultado = CalcularEstatisticas(10, 20, 30, 40, 50);
            Console.WriteLine($"4. Método com tupla: Média: {resultado.Media}, Soma: {resultado.Soma}, Maior: {resultado.Maior}");

            // 5. Deconstrução direta da tupla retornada
            var (media, soma, maior) = CalcularEstatisticas(5, 15, 25);
            Console.WriteLine($"5. Deconstrução direta: Média: {media}, Soma: {soma}, Maior: {maior}");

            // ==================================================================
            // COMPARAÇÃO E IGUALDADE DE TUPLAS
            // ==================================================================

            // 6. Comparação de tuplas
            var tupla1 = (1, "A");
            var tupla2 = (1, "A");
            var tupla3 = (2, "B");

            Console.WriteLine($"6. Comparação: tupla1 == tupla2: {tupla1 == tupla2}");
            Console.WriteLine($"   Comparação: tupla1 == tupla3: {tupla1 == tupla3}");

            // ==================================================================
            // TUPLAS EM COLETÂNEAS - Listas e Dicionários
            // ==================================================================

            // 7. Lista de tuplas
            var pessoas = new List<(string Nome, int Idade)>
            {
                ("Ana", 28),
                ("Carlos", 32),
                ("Beatriz", 41)
            };

            Console.WriteLine("\n7. Lista de tuplas:");
            foreach (var pessoa in pessoas)
            {
                Console.WriteLine($"   - {pessoa.Nome} ({pessoa.Idade} anos)");
            }

            // 8. Dicionário com tuplas como valor
            var departamentos = new Dictionary<string, (string Gerente, int Funcionarios)>
            {
                ["TI"] = ("João Silva", 15),
                ["RH"] = ("Maria Santos", 8),
                ["Vendas"] = ("Pedro Costa", 12)
            };

            Console.WriteLine("\n8. Dicionário com tuplas:");
            foreach (var depto in departamentos)
            {
                Console.WriteLine($"   {depto.Key}: {depto.Value.Gerente} - {depto.Value.Funcionarios} func.");
            }

            // ==================================================================
            // TUPLAS COM MAIS ELEMENTOS - Até 8 elementos suportados
            // ==================================================================

            // 9. Tupla com vários elementos
            var produto = (Id: 1, Nome: "Notebook", Preco: 2500.99m, Estoque: 15, Categoria: "Eletrônicos");
            Console.WriteLine($"\n9. Tupla complexa: {produto.Nome} - {produto.Preco:C} - Estoque: {produto.Estoque}");

            // ==================================================================
            // DESCONSTRUÇÃO DE TUPLAS - Recupera valores individuais
            // ==================================================================

            // 10. Desconstrução de tupla em variáveis separadas
            var (nome, idade, ativo) = ("Luiz", 45, false);
            Console.WriteLine($"10. Desconstrução: Nome: {nome}, Idade: {idade}, Ativo: {ativo}");

            // 11. Desconstrução ignorando elementos com _
            var (_, _, apenasAtivo) = pessoa3; // Ignora Nome e Idade, pega apenas Ativo
            Console.WriteLine($"11. Desconstrução parcial: Apenas Ativo: {apenasAtivo}");
        }

        // ==================================================================
        // MÉTODO QUE RETORNA UMA TUPLA - Útil para retornar múltiplos valores
        // ==================================================================
        private static (double Media, int Soma, int Maior) CalcularEstatisticas(params int[] numeros)
        {
            if (numeros == null || numeros.Length == 0)
                return (0, 0, 0);

            int soma = 0;
            int maior = int.MinValue;

            foreach (var num in numeros)
            {
                soma += num;
                if (num > maior) maior = num;
            }

            double media = (double)soma / numeros.Length;

            return (media, soma, maior);
        }
    }
}