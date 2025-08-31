using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ColecoesExcecos.Models

{
    public static class ColecoesGenericasMetodos
    {
        public static void DemonstrarMetodos()
        {
            Console.WriteLine("=== MÉTODOS DE COLEÇÕES GENÉRICAS ===\n");

            // ========== LIST<T> ==========
            Console.WriteLine("1. LIST<T> METHODS:");
            var lista = new List<int> { 1, 2, 3, 4, 5 };

            // Add() - Adiciona um item ao final da lista
            lista.Add(6);
            Console.WriteLine($"Add(6): {string.Join(", ", lista)}");

            // AddRange() - Adiciona vários itens de uma vez
            lista.AddRange(new[] { 7, 8, 9 });
            Console.WriteLine($"AddRange([7,8,9]): {string.Join(", ", lista)}");

            // Remove() - Remove a primeira ocorrência do item
            lista.Remove(3);
            Console.WriteLine($"Remove(3): {string.Join(", ", lista)}");

            // RemoveAt() - Remove item pelo índice
            lista.RemoveAt(0);
            Console.WriteLine($"RemoveAt(0): {string.Join(", ", lista)}");

            // RemoveAll() - Remove todos que atendem a condição
            lista.RemoveAll(x => x % 2 == 0);
            Console.WriteLine($"RemoveAll(par): {string.Join(", ", lista)}");

            // Contains() - Verifica se contém o item
            Console.WriteLine($"Contains(5): {lista.Contains(5)}");

            // Exists() - Verifica se existe item que atende condição
            Console.WriteLine($"Exists(>10): {lista.Exists(x => x > 10)}");

            // Find() - Encontra primeiro item que atende condição
            Console.WriteLine($"Find(>4): {lista.Find(x => x > 4)}");

            // FindAll() - Encontra todos que atendem condição
            var maiores = lista.FindAll(x => x > 1);
            Console.WriteLine($"FindAll(>1): {string.Join(", ", maiores)}");

            // ForEach() - Executa ação para cada item
            Console.Write("ForEach: ");
            lista.ForEach(x => Console.Write($"{x * 2} "));
            Console.WriteLine();

            // Sort() - Ordena a lista
            lista.Sort();
            Console.WriteLine($"Sort(): {string.Join(", ", lista)}");

            // Reverse() - Inverte a ordem
            lista.Reverse();
            Console.WriteLine($"Reverse(): {string.Join(", ", lista)}");

            // Clear() - Limpa toda a lista
            lista.Clear();
            Console.WriteLine($"Clear(): Count = {lista.Count}");
            Console.WriteLine();

            // ========== DICTIONARY<TKey, TValue> ==========
            Console.WriteLine("2. DICTIONARY<TKEY, TVALUE> METHODS:");
            var dict = new Dictionary<string, int>
            {
                ["Alice"] = 25,
                ["Bob"] = 30
            };

            // Add() - Adiciona par chave-valor
            dict.Add("Charlie", 35);
            Console.WriteLine($"Add(Charlie, 35): {dict.Count} items");

            // ContainsKey() - Verifica se chave existe
            Console.WriteLine($"ContainsKey(Alice): {dict.ContainsKey("Alice")}");

            // ContainsValue() - Verifica se valor existe
            Console.WriteLine($"ContainsValue(30): {dict.ContainsValue(30)}");

            // TryGetValue() - Tenta obter valor sem gerar exceção
            if (dict.TryGetValue("Bob", out int idadeBob))
                Console.WriteLine($"TryGetValue(Bob): {idadeBob}");

            // Remove() - Remove por chave
            dict.Remove("Alice");
            Console.WriteLine($"Remove(Alice): {dict.Count} items");

            // Keys - Coleção de todas as chaves
            Console.WriteLine($"Keys: {string.Join(", ", dict.Keys)}");

            // Values - Coleção de todos os valores
            Console.WriteLine($"Values: {string.Join(", ", dict.Values)}");
            Console.WriteLine();

            // ========== QUEUE<T> ==========
            Console.WriteLine("3. QUEUE<T> METHODS:");
            var queue = new Queue<string>();

            // Enqueue() - Adiciona ao final da fila
            queue.Enqueue("Primeiro");
            queue.Enqueue("Segundo");
            queue.Enqueue("Terceiro");
            Console.WriteLine($"Enqueue 3 items: Count = {queue.Count}");

            // Peek() - Visualiza primeiro item sem remover
            Console.WriteLine($"Peek(): {queue.Peek()}");

            // Dequeue() - Remove e retorna primeiro item
            Console.WriteLine($"Dequeue(): {queue.Dequeue()}");
            Console.WriteLine($"After Dequeue: Count = {queue.Count}");

            // Contains() - Verifica se item está na fila
            Console.WriteLine($"Contains(Segundo): {queue.Contains("Segundo")}");
            Console.WriteLine();

            // ========== STACK<T> ==========
            Console.WriteLine("4. STACK<T> METHODS:");
            var stack = new Stack<int>();

            // Push() - Adiciona ao topo da pilha
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            Console.WriteLine($"Push 3 items: Count = {stack.Count}");

            // Peek() - Visualiza topo sem remover
            Console.WriteLine($"Peek(): {stack.Peek()}");

            // Pop() - Remove e retorna do topo
            Console.WriteLine($"Pop(): {stack.Pop()}");
            Console.WriteLine($"After Pop: Count = {stack.Count}");

            // Contains() - Verifica se item está na pilha
            Console.WriteLine($"Contains(2): {stack.Contains(2)}");
            Console.WriteLine();

            // ========== LINQ COM COLEÇÕES ==========
            Console.WriteLine("5. LINQ METHODS:");
            var numeros = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            // Where() - Filtra itens
            var pares = numeros.Where(n => n % 2 == 0);
            Console.WriteLine($"Where(par): {string.Join(", ", pares)}");

            // Select() - Transforma itens
            var dobros = numeros.Select(n => n * 2);
            Console.WriteLine($"Select(x2): {string.Join(", ", dobros)}");

            // OrderBy() - Ordena itens
            var ordenados = numeros.OrderByDescending(n => n);
            Console.WriteLine($"OrderByDesc: {string.Join(", ", ordenados)}");

            // First()/FirstOrDefault() - Primeiro item
            Console.WriteLine($"First(): {numeros.First()}");
            Console.WriteLine($"FirstOrDefault(>100): {numeros.FirstOrDefault(n => n > 100)}");

            // Any()/All() - Verificações
            Console.WriteLine($"Any(>5): {numeros.Any(n => n > 5)}");
            Console.WriteLine($"All(>0): {numeros.All(n => n > 0)}");

            // Sum()/Average() - Agregações
            Console.WriteLine($"Sum: {numeros.Sum()}, Average: {numeros.Average()}");
        }
    }
}