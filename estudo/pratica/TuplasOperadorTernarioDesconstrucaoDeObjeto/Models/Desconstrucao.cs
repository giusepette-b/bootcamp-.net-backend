using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TuplasOperadorTernarioDesconstrucaoDeObjeto.Models

{
    public static class Desconstrucao
    {
        public static void Demonstrar()
        {
            Console.WriteLine("=== DESCONSTRUÇÃO DE OBJETOS EM C# ===\n");

            // ==================================================================
            // DESCONSTRUÇÃO BÁSICA - Introduzido no C# 7.0
            // ==================================================================

            // 1. Desconstrução de tupla
            var (nome, idade) = ("Carlos", 30);
            Console.WriteLine($"1. Desconstrução de tupla: Nome: {nome}, Idade: {idade}");

            // ==================================================================
            // DESCONSTRUÇÃO DE OBJETOS PERSONALIZADOS
            // ==================================================================

            // 2. Desconstrução de objeto personalizado
            var pessoa = new Pessoa("Ana", "Silva", 25);
            var (primeiroNome, sobrenome, anos) = pessoa;
            Console.WriteLine($"2. Desconstrução de objeto: {primeiroNome} {sobrenome}, {anos} anos");

            // 3. Desconstrução parcial - ignorando elementos
            var (apenasNome, _, _) = pessoa;
            Console.WriteLine($"3. Desconstrução parcial: Apenas nome: {apenasNome}");

            // ==================================================================
            // DESCONSTRUÇÃO EM MÉTODOS
            // ==================================================================

            // 4. Desconstrução do retorno de método
            var (sucesso, mensagem) = TentarOperacao();
            Console.WriteLine($"4. Desconstrução de método: Sucesso: {sucesso}, Mensagem: {mensagem}");

            // ==================================================================
            // DESCONSTRUÇÃO EM COLETÂNEAS
            // ==================================================================

            // 5. Desconstrução em loops
            var pessoas = new List<Pessoa>
            {
                new Pessoa("João", "Santos", 35),
                new Pessoa("Maria", "Oliveira", 28),
                new Pessoa("Pedro", "Costa", 42)
            };

            Console.WriteLine("\n5. Desconstrução em loop:");
            foreach (var (pNome, pSobrenome, pIdade) in pessoas)
            {
                Console.WriteLine($"   - {pNome} {pSobrenome} ({pIdade} anos)");
            }

            // ==================================================================
            // DESCONSTRUÇÃO COM DICIONÁRIOS
            // ==================================================================

            // 6. Desconstrução de KeyValuePair
            var dicionario = new Dictionary<string, int>
            {
                ["Maçã"] = 10,
                ["Banana"] = 15,
                ["Laranja"] = 8
            };

            Console.WriteLine("\n6. Desconstrução de dicionário:");
            foreach (var (fruta, quantidade) in dicionario)
            {
                Console.WriteLine($"   {fruta}: {quantidade} unidades");
            }

            // ==================================================================
            // DESCONSTRUÇÃO COM MÚLTIPLOS DECONSTRUCT
            // ==================================================================

            // 7. Objeto com múltiplos métodos Deconstruct
            var produto = new Produto("Notebook", 2500.99m, "Eletrônicos");

            // Primeira sobrecarga - nome e preço
            var (nomeProduto, preco) = produto;
            Console.WriteLine($"\n7. Primeira sobrecarga: {nomeProduto} - {preco:C}");

            // Segunda sobrecarga - todos os campos
            var (nomeCompleto, precoTotal, categoria) = produto;
            Console.WriteLine($"   Segunda sobrecarga: {nomeCompleto} - {precoTotal:C} - {categoria}");

            // ==================================================================
            // DESCONSTRUÇÃO EM EXPRESSÕES COMPLEXAS
            // ==================================================================

            // 8. Desconstrução em expressões
            var resultado = CalcularEstatisticas(10, 20, 30);
            var (media, soma, maior, menor) = resultado;
            Console.WriteLine($"\n8. Estatísticas: Média: {media}, Soma: {soma}, Maior: {maior}, Menor: {menor}");

            // ==================================================================
            // DESCONSTRUÇÃO COM PATTERN MATCHING (C# 8.0+)
            // ==================================================================

            // 9. Desconstrução com pattern matching
            object obj = new Pessoa("Beatriz", "Rocha", 31);

            if (obj is Pessoa p)
            {
                var (nomeP, sobrenomeP, idadeP) = p;
                Console.WriteLine($"9. Pattern matching: {nomeP} {sobrenomeP} - {idadeP} anos");
            }

            // ==================================================================
            // CASOS DE USO PRÁTICOS
            // ==================================================================

            Console.WriteLine("\n🎯 CASOS DE USO PRÁTICOS:");
            Console.WriteLine("   • Retorno múltiplo de métodos");
            Console.WriteLine("   • Processamento de dados em lotes");
            Console.WriteLine("   • Manipulação de resultados de APIs");
            Console.WriteLine("   • Simplificação de código com objetos complexos");
        }

        private static (bool Sucesso, string Mensagem) TentarOperacao()
        {
            // Simulação de operação que pode falhar
            return (true, "Operação concluída com sucesso");
        }

        private static (double Media, int Soma, int Maior, int Menor) CalcularEstatisticas(params int[] numeros)
        {
            if (numeros == null || numeros.Length == 0)
                return (0, 0, 0, 0);

            int soma = 0;
            int maior = int.MinValue;
            int menor = int.MaxValue;

            foreach (var num in numeros)
            {
                soma += num;
                if (num > maior) maior = num;
                if (num < menor) menor = num;
            }

            double media = (double)soma / numeros.Length;

            return (media, soma, maior, menor);
        }
    }

    // ==================================================================
    // CLASSE COM MÉTODO DECONSTRUCT - Permite desconstrução
    // ==================================================================
    public class Pessoa
    {
        public string Nome { get; }
        public string Sobrenome { get; }
        public int Idade { get; }

        public Pessoa(string nome, string sobrenome, int idade)
        {
            Nome = nome;
            Sobrenome = sobrenome;
            Idade = idade;
        }

        // Método Deconstruct - permite desconstruir o objeto
        public void Deconstruct(out string nome, out string sobrenome, out int idade)
        {
            nome = Nome;
            sobrenome = Sobrenome;
            idade = Idade;
        }
    }

    // ==================================================================
    // CLASSE COM MÚLTIPLOS MÉTODOS DECONSTRUCT - Sobrecargas
    // ==================================================================
    public class Produto
    {
        public string Nome { get; }
        public decimal Preco { get; }
        public string Categoria { get; }

        public Produto(string nome, decimal preco, string categoria)
        {
            Nome = nome;
            Preco = preco;
            Categoria = categoria;
        }

        // Primeira sobrecarga - apenas nome e preço
        public void Deconstruct(out string nome, out decimal preco)
        {
            nome = Nome;
            preco = Preco;
        }

        // Segunda sobrecarga - todos os campos
        public void Deconstruct(out string nome, out decimal preco, out string categoria)
        {
            nome = Nome;
            preco = Preco;
            categoria = Categoria;
        }
    }
}