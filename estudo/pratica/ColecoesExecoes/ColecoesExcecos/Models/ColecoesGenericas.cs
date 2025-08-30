using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExcecoesColecoes.Models
{
    public static class ColecoesGenericas
    {
        public static void Demonstrar()
        {
            // 1. List<T>
            Console.WriteLine("=== LIST<T> ===");
            var lista = new List<int> { 1, 2, 3, 4, 5 };
            lista.Add(6);
            lista.AddRange(new[] { 7, 8, 9 });
            lista.Remove(3);

            Console.WriteLine($"Lista: {string.Join(", ", lista)}");
            Console.WriteLine($"Contém 5? {lista.Contains(5)}");
            Console.WriteLine($"Count: {lista.Count}");

            // 2. Dictionary<TKey, TValue>
            Console.WriteLine("\n=== DICTIONARY<TKEY, TVALUE> ===");
            var dicionario = new Dictionary<string, int>
            {
                ["Alice"] = 25,
                ["Bob"] = 30,
                ["Charlie"] = 35
            };

            dicionario["David"] = 40;
            dicionario.TryAdd("Eva", 28);

            foreach (var kvp in dicionario)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value} anos");
            }

            // 3. HashSet<T>
            Console.WriteLine("\n=== HASHSET<T> ===");
            var hashSet = new HashSet<int> { 1, 2, 3, 4, 5 };
            hashSet.Add(3); // Duplicado - não será adicionado
            hashSet.Add(6);

            Console.WriteLine($"HashSet: {string.Join(", ", hashSet)}");
            Console.WriteLine($"Contém 4? {hashSet.Contains(4)}");

            // 4. Queue<T>
            Console.WriteLine("\n=== QUEUE<T> ===");
            var queue = new Queue<string>();
            queue.Enqueue("Primeiro");
            queue.Enqueue("Segundo");
            queue.Enqueue("Terceiro");

            while (queue.Count > 0)
            {
                Console.WriteLine($"Dequeue: {queue.Dequeue()}");
            }

            // 5. Stack<T>
            Console.WriteLine("\n=== STACK<T> ===");
            var stack = new Stack<string>();
            stack.Push("Primeiro");
            stack.Push("Segundo");
            stack.Push("Terceiro");

            while (stack.Count > 0)
            {
                Console.WriteLine($"Pop: {stack.Pop()}");
            }

            // 6. LinkedList<T>
            Console.WriteLine("\n=== LINKEDLIST<T> ===");
            var linkedList = new LinkedList<string>();
            linkedList.AddLast("Primeiro");
            linkedList.AddLast("Terceiro");
            var node = linkedList.AddFirst("Zeroth");
            linkedList.AddAfter(node, "Segundo");

            foreach (var item in linkedList)
            {
                Console.WriteLine($"Linked List: {item}");
            }

            // 7. SortedSet<T> e SortedDictionary<T>
            Console.WriteLine("\n=== COLECÕES ORDENADAS ===");
            var sortedSet = new SortedSet<int> { 5, 2, 8, 1, 3 };
            var sortedDict = new SortedDictionary<string, int>
            {
                ["Zebra"] = 5,
                ["Apple"] = 2,
                ["Banana"] = 3
            };

            Console.WriteLine($"SortedSet: {string.Join(", ", sortedSet)}");
            Console.WriteLine("SortedDictionary:");
            foreach (var kvp in sortedDict)
            {
                Console.WriteLine($"  {kvp.Key}: {kvp.Value}");
            }
        }
    }
}