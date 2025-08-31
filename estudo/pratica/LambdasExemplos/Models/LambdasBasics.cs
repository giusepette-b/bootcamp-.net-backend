using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks; // ❗ Adicione este using para Task

namespace LambdaExplanation // ❗ Namespace consistente
{
    public static class LambdaBasics
    {
        public static void Demonstrar()
        {
            Console.WriteLine("=== LAMBDA EXPRESSIONS EM C# ===\n");

            // ==================================================================
            // 1. O QUE SÃO LAMBDA EXPRESSIONS?
            // ==================================================================
            Console.WriteLine("1. CONCEITO BÁSICO:");
            Console.WriteLine("   • São funções anônimas (sem nome)");
            Console.WriteLine("   • Sintaxe concisa para representar métodos");
            Console.WriteLine("   • Introduzidas no C# 3.0");
            Console.WriteLine("   • Base para LINQ e programação funcional");

            // ==================================================================
            // 2. SINTAXE BÁSICA: (parâmetros) => expressão
            // ==================================================================
            Console.WriteLine("\n2. SINTAXE BÁSICA:");

            // Lambda mais simples - nenhum parâmetro
            Action saudacao = () => Console.WriteLine("   Olá, mundo!");
            saudacao();

            // Lambda com um parâmetro
            Action<string> saudacaoNome = nome => Console.WriteLine($"   Olá, {nome}!");
            saudacaoNome("João");

            // Lambda com múltiplos parâmetros
            Func<int, int, int> soma = (a, b) => a + b;
            Console.WriteLine($"   Soma: 5 + 3 = {soma(5, 3)}");

            // Lambda com corpo entre chaves (múltiplas linhas)
            Func<int, int, int> operacaoComplexa = (a, b) =>
            {
                int resultado = a * b;
                resultado += 10;
                return resultado;
            };
            Console.WriteLine($"   Operação complexa: (5 * 3) + 10 = {operacaoComplexa(5, 3)}");

            // ==================================================================
            // 3. LAMBDA VS MÉTODOS TRADICIONAIS
            // ==================================================================
            Console.WriteLine("\n3. LAMBDA VS MÉTODOS TRADICIONAIS:");

            // Método tradicional
            int DobrarMetodo(int x) => x * 2;

            // Lambda equivalente
            Func<int, int> dobrarLambda = x => x * 2;

            Console.WriteLine($"   Método tradicional: {DobrarMetodo(5)}");
            Console.WriteLine($"   Lambda: {dobrarLambda(5)}");

            // ==================================================================
            // 4. LAMBDA COM LINQ - USO MAIS COMUM
            // ==================================================================
            Console.WriteLine("\n4. LAMBDA COM LINQ:");

            var numeros = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            // Where - filtra elementos
            var pares = numeros.Where(n => n % 2 == 0);
            Console.WriteLine($"   Números pares: {string.Join(", ", pares)}");

            // Select - transforma elementos
            var dobros = numeros.Select(n => n * 2);
            Console.WriteLine($"   Dobros: {string.Join(", ", dobros)}");

            // OrderBy - ordena elementos
            var ordenados = numeros.OrderByDescending(n => n);
            Console.WriteLine($"   Ordenados: {string.Join(", ", ordenados)}");

            // ==================================================================
            // 5. LAMBDA COM DELEGATES
            // ==================================================================
            Console.WriteLine("\n5. LAMBDA COM DELEGATES:");

            // Action - não retorna valor
            Action<string> logger = mensagem => Console.WriteLine($"   LOG: {mensagem}");
            logger("Mensagem de teste");

            // Func - retorna valor
            Func<string, int> contarLetras = texto => texto.Length;
            Console.WriteLine($"   Letras em 'Hello': {contarLetras("Hello")}");

            // Predicate - retorna bool (usado em Find, RemoveAll, etc.)
            Predicate<int> ehPositivo = numero => numero > 0;
            Console.WriteLine($"   5 é positivo? {ehPositivo(5)}");

            // ==================================================================
            // 6. CAPTURA DE VARIÁVEIS (CLOSURES)
            // ==================================================================
            Console.WriteLine("\n6. CAPTURA DE VARIÁVEIS (CLOSURES):");

            int fator = 10;

            // A lambda captura a variável 'fator' do escopo externo
            Func<int, int> multiplicar = x => x * fator;

            Console.WriteLine($"   Multiplicar por {fator}: 5 * {fator} = {multiplicar(5)}");

            // Se mudarmos o fator, a lambda usa o novo valor
            fator = 3;
            Console.WriteLine($"   Agora 5 * {fator} = {multiplicar(5)}");

            // ==================================================================
            // 7. LAMBDA EM EVENTOS - CORRIGIDO
            // ==================================================================
            Console.WriteLine("\n7. LAMBDA EM EVENTOS:");

            var botao = new Botao();

            // Subscribe com lambda
            botao.Click += (sender, args) =>
                Console.WriteLine("   Botão clicado! (lambda)");

            botao.Clicar();

            // ==================================================================
            // 8. LAMBDA EM MÉTODOS DE COLETÂNEAS
            // ==================================================================
            Console.WriteLine("\n8. LAMBDA EM COLETÂNEAS:");

            var pessoas = new List<Pessoa>
            {
                new Pessoa("Ana", 25),
                new Pessoa("João", 30),
                new Pessoa("Maria", 35)
            };

            // Find - encontra primeira ocorrência
            var jovem = pessoas.Find(p => p.Idade < 30);
            Console.WriteLine($"   Pessoa jovem: {jovem?.Nome}");

            // RemoveAll - remove basedo em condição
            pessoas.RemoveAll(p => p.Nome.StartsWith("A"));
            Console.WriteLine($"   Após remover 'A': {pessoas.Count} pessoas");

            // ForEach - executa ação para cada item
            Console.Write("   Nomes: ");
            pessoas.ForEach(p => Console.Write($"{p.Nome} "));
            Console.WriteLine();

            // ==================================================================
            // 9. LAMBDA AVANÇADO - EXPRESSÕES COMPLEXAS
            // ==================================================================
            Console.WriteLine("\n9. LAMBDA COMPLEXAS:");

            // Lambda com múltiplos parâmetros e lógica complexa
            Func<string, int, string> formatar = (nome, idade) =>
            {
                string categoria = idade < 30 ? "Jovem" : "Adulto";
                return $"{nome} ({idade} anos) - {categoria}";
            };

            Console.WriteLine($"   Formatação: {formatar("Carlos", 28)}");

            // Lambda com pattern matching (C# 9.0+)
            Func<object, string> descrever = obj => obj switch
            {
                string s => $"String: {s}",
                int i => $"Inteiro: {i}",
                _ => "Tipo desconhecido"
            };

            Console.WriteLine($"   Pattern matching: {descrever("texto")}");
            Console.WriteLine($"   Pattern matching: {descrever(42)}");

            // ==================================================================
            // 10. LAMBDA EM THREADS E TASKS
            // ==================================================================
            Console.WriteLine("\n10. LAMBDA EM THREADS:");

            // Task com lambda
            var task = Task.Run(() =>
            {
                Console.WriteLine("   Executando em background...");
                Task.Delay(100).Wait(); // ❗ Corrigido: Task.Delay em vez de Thread.Sleep
                return "Concluído!";
            });

            task.ContinueWith(t =>
                Console.WriteLine($"   Resultado: {t.Result}"));

            task.Wait();

            // ==================================================================
            // 11. EXEMPLOS PRÁTICOS
            // ==================================================================
            Console.WriteLine("\n11. EXEMPLOS PRÁTICOS:");

            // Validação
            Func<string, bool> validarEmail = email =>
                !string.IsNullOrEmpty(email) && email.Contains("@");

            // Formatação
            Func<decimal, string> formatarMoeda = valor =>
                valor.ToString("C", new System.Globalization.CultureInfo("pt-BR"));

            // Filtro complexo
            Func<Pessoa, bool> filtroIdoso = p =>
                p.Idade >= 60 && p.Nome.Length > 3;

            Console.WriteLine($"   Email válido: {validarEmail("teste@email.com")}");
            Console.WriteLine($"   Moeda formatada: {formatarMoeda(1234.56m)}");
        }

        // Método local para exemplo
        private static int DobrarMetodo(int x) => x * 2;
    }

    // Classes auxiliares - CORRIGIDAS
    public class Botao
    {
        public event EventHandler? Click = null; // ❗ Tornado anulável para evitar warning

        public void Clicar()
        {
            Click?.Invoke(this, EventArgs.Empty);
        }
    }

    public class Pessoa
    {
        public string Nome { get; }
        public int Idade { get; }

        public Pessoa(string nome, int idade)
        {
            Nome = nome;
            Idade = idade;
        }
    }
}