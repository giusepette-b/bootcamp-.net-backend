using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel; // ❗FALTANDO este namespace importante

namespace ExcecoesColecoes
{
    public static class ColecoesEspecializadas
    {
        public static void Demonstrar()
        {
            // 1. ReadOnlyCollection - Coleção somente leitura
            Console.WriteLine("=== READONLYCOLLECTION ===");
            var listaOriginal = new List<int> { 1, 2, 3, 4, 5 };
            var readOnly = new ReadOnlyCollection<int>(listaOriginal);

            Console.WriteLine($"ReadOnly: {string.Join(", ", readOnly)}");
            // readOnly[0] = 10; // ❌ Erro de compilação - coleção é somente leitura

            // 2. Collection inicializável - Herdando de Collection<T>
            Console.WriteLine("\n=== COLLECTION INICIALIZÁVEL ===");
            var colecao = new MinhaColeção<int> { 1, 2, 3, 4, 5 };
            foreach (var item in colecao)
            {
                Console.WriteLine($"Item: {item}");
            }

            // 3. IEnumerable personalizado - Implementando a interface
            Console.WriteLine("\n=== IENUMERABLE PERSONALIZADO ===");
            var numeros = new NumerosPares(10);
            foreach (var numero in numeros)
            {
                Console.WriteLine($"Número par: {numero}");
            }

            // 4. Coleções thread-safe (exemplo básico)
            Console.WriteLine("\n=== COLECÕES THREAD-SAFE ===");
            var listaSync = ArrayList.Synchronized(new ArrayList { 1, 2, 3, 4, 5 });
            Console.WriteLine($"Lista sincronizada: {string.Join(", ", listaSync.ToArray())}");

            // 5. BitArray - Trabalhando com bits
            Console.WriteLine("\n=== BITARRAY ===");
            var bits = new BitArray(new[] { true, false, true, true, false });
            for (int i = 0; i < bits.Count; i++)
            {
                Console.WriteLine($"Bit {i}: {bits[i]}");
            }

            // 6. Coleções especializadas .NET
            Console.WriteLine("\n=== COLECÕES ESPECIALIZADAS ===");
            var listaQueue = new Queue();
            listaQueue.Enqueue("Primeiro");
            listaQueue.Enqueue("Segundo");

            Console.WriteLine("Queue:");
            while (listaQueue.Count > 0)
            {
                Console.WriteLine($"Dequeue: {listaQueue.Dequeue()}");
            }

            // 7. ObservableCollection (simulação)
            Console.WriteLine("\n=== OBSERVABLECOLLECTION (SIMULAÇÃO) ===");
            var observable = new ObservableCollectionSimulada<string>();
            observable.ItemAdicionado += (sender, item) =>
                Console.WriteLine($"Item adicionado: {item}");
            observable.ItemRemovido += (sender, item) =>
                Console.WriteLine($"Item removido: {item}");

            observable.Add("Item 1");
            observable.Add("Item 2");
            observable.Remove("Item 1");
        }
    }

    // Coleção personalizada que herda de Collection<T>
    public class MinhaColeção<T> : Collection<T>
    {
        protected override void InsertItem(int index, T item)
        {
            Console.WriteLine($"Inserindo {item} na posição {index}");
            base.InsertItem(index, item);
        }

        protected override void RemoveItem(int index)
        {
            Console.WriteLine($"Removendo item na posição {index}");
            base.RemoveItem(index);
        }
    }

    // IEnumerable personalizado para números pares - IMPLEMENTAÇÃO CORRIGIDA
    public class NumerosPares : IEnumerable<int>
    {
        private readonly int _max;

        public NumerosPares(int max)
        {
            _max = max;
        }

        // Implementação do GetEnumerator genérico
        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i <= _max; i += 2)
            {
                yield return i; // ❗yield return é uma forma especial de retornar sequências
            }
        }

        // Implementação explícita da interface não genérica - CORRIGIDA
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator(); // ❗Chama a implementação genérica
        }
    }

    // Simulação de ObservableCollection com eventos
    public class ObservableCollectionSimulada<T> : Collection<T>
    {
        public event EventHandler<T> ItemAdicionado;
        public event EventHandler<T> ItemRemovido;

        protected override void InsertItem(int index, T item)
        {
            base.InsertItem(index, item);
            ItemAdicionado?.Invoke(this, item);
        }

        protected override void RemoveItem(int index)
        {
            T item = this[index];
            base.RemoveItem(index);
            ItemRemovido?.Invoke(this, item);
        }
    }
}