using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ExcecoesColecoes.Models
{
    public static class ColecoesEspecializadasMetodos
    {
        public static void DemonstrarMetodos()
        {
            Console.WriteLine("=== MÉTODOS DE COLEÇÕES ESPECIALIZADAS ===\n");

            // ========== READONLYCOLLECTION ==========
            Console.WriteLine("1. READONLYCOLLECTION METHODS:");
            var listaOriginal = new List<string> { "A", "B", "C" };
            var readOnly = new ReadOnlyCollection<string>(listaOriginal);

            // Count - Quantidade de itens (somente leitura)
            Console.WriteLine($"Count: {readOnly.Count}");

            // Contains() - Verifica se contém item
            Console.WriteLine($"Contains(B): {readOnly.Contains("B")}");

            // IndexOf() - Índice do item
            Console.WriteLine($"IndexOf(C): {readOnly.IndexOf("C")}");

            // CopyTo() - Copia para array
            var array = new string[3];
            readOnly.CopyTo(array, 0);
            Console.WriteLine($"CopyTo: {string.Join(", ", array)}");

            // Acesso por índice (somente leitura)
            Console.WriteLine($"readOnly[1]: {readOnly[1]}");
            Console.WriteLine();

            // ========== HASHSET<T> ==========
            Console.WriteLine("2. HASHSET<T> METHODS:");
            var hashSet = new HashSet<int> { 1, 2, 3, 4, 5 };

            // Add() - Adiciona item (ignora duplicatas)
            hashSet.Add(3); // Não adiciona - já existe
            hashSet.Add(6); // Adiciona - novo
            Console.WriteLine($"Add(3,6): {string.Join(", ", hashSet)}");

            // UnionWith() - União com outro conjunto
            hashSet.UnionWith(new[] { 5, 6, 7, 8 });
            Console.WriteLine($"UnionWith([5,6,7,8]): {string.Join(", ", hashSet)}");

            // IntersectWith() - Interseção com outro conjunto
            hashSet.IntersectWith(new[] { 4, 5, 6, 9 });
            Console.WriteLine($"IntersectWith([4,5,6,9]): {string.Join(", ", hashSet)}");

            // ExceptWith() - Diferença entre conjuntos
            hashSet.ExceptWith(new[] { 5 });
            Console.WriteLine($"ExceptWith([5]): {string.Join(", ", hashSet)}");

            // IsSubsetOf()/IsSupersetOf() - Verificações de conjunto
            Console.WriteLine($"IsSubsetOf([4,5,6]): {hashSet.IsSubsetOf(new[] { 4, 5, 6 })}");
            Console.WriteLine($"IsSupersetOf([4]): {hashSet.IsSupersetOf(new[] { 4 })}");
            Console.WriteLine();

            // ========== SORTEDSET<T> ==========
            Console.WriteLine("3. SORTEDSET<T> METHODS:");
            var sortedSet = new SortedSet<int> { 5, 2, 8, 1, 3 };

            // GetViewBetween() - Retorna subconjunto entre valores
            var view = sortedSet.GetViewBetween(2, 5);
            Console.WriteLine($"GetViewBetween(2,5): {string.Join(", ", view)}");

            // Min/Max - Menor e maior valor
            Console.WriteLine($"Min: {sortedSet.Min}, Max: {sortedSet.Max}");

            // Reverse() - Ordem reversa
            Console.WriteLine($"Reverse: {string.Join(", ", sortedSet.Reverse())}");
            Console.WriteLine();

            // ========== LINKEDLIST<T> ==========
            Console.WriteLine("4. LINKEDLIST<T> METHODS:");
            var linkedList = new LinkedList<string>();

            // AddFirst()/AddLast() - Adiciona no início/fim
            linkedList.AddFirst("Primeiro");
            linkedList.AddLast("Último");
            var segundo = linkedList.AddAfter(linkedList.First, "Segundo");
            linkedList.AddBefore(linkedList.Last, "Penúltimo");

            Console.WriteLine($"LinkedList: {string.Join(" -> ", linkedList)}");

            // Find() - Encontra nó com valor
            var node = linkedList.Find("Segundo");
            Console.WriteLine($"Find(Segundo): {node?.Value}");

            // Remove() - Remove nó ou valor
            linkedList.Remove("Penúltimo");
            Console.WriteLine($"After Remove: {string.Join(" -> ", linkedList)}");
            Console.WriteLine();

            // ========== OBSERVABLECOLLECTION ==========
            Console.WriteLine("5. OBSERVABLECOLLECTION METHODS:");
            var observable = new ObservableCollection<string> { "Item1", "Item2" };

            // Eventos de mudança
            observable.CollectionChanged += (sender, e) =>
            {
                Console.WriteLine($"CollectionChanged: {e.Action}");
                if (e.NewItems != null)
                    Console.WriteLine($"NewItems: {string.Join(", ", e.NewItems.Cast<string>())}");
                if (e.OldItems != null)
                    Console.WriteLine($"OldItems: {string.Join(", ", e.OldItems.Cast<string>())}");
            };

            // Add() - Dispara evento
            observable.Add("Item3");

            // Remove() - Dispara evento
            observable.Remove("Item1");

            // Insert() - Adiciona em posição específica
            observable.Insert(1, "ItemNovo");

            // Move() - Move item de posição
            observable.Move(0, 2);
            Console.WriteLine();

            // ========== BITARRAY ==========
            Console.WriteLine("6. BITARRAY METHODS:");
            var bits = new BitArray(new[] { true, false, true, false, true });

            // Set()/SetAll() - Define valores
            bits.Set(1, true);
            bits.SetAll(false);
            Console.WriteLine($"After SetAll(false): {BitsToString(bits)}");

            // Not() - Inverte todos os bits
            bits.SetAll(true);
            bits.Not();
            Console.WriteLine($"After Not(): {BitsToString(bits)}");

            // And/Or/Xor - Operações bit a bit
            var bits2 = new BitArray(new[] { true, true, false, false, true });
            bits.And(bits2);
            Console.WriteLine($"After And(): {BitsToString(bits)}");
            Console.WriteLine();

            // ========== COLLECTION<T> PERSONALIZADA ==========
            Console.WriteLine("7. COLLECTION<T> PERSONALIZADA:");
            var colecaoCustom = new MinhaColeçãoCustom<int> { 1, 2, 3 };

            // InsertItem() - Sobrescrito para adicionar log
            colecaoCustom.Add(4);

            // RemoveItem() - Sobrescrito para adicionar log
            colecaoCustom.Remove(2);

            // SetItem() - Sobrescrito para adicionar log
            colecaoCustom[0] = 10;
            Console.WriteLine($"Final: {string.Join(", ", colecaoCustom)}");
        }

        private static string BitsToString(BitArray bits)
        {
            return string.Join("", bits.Cast<bool>().Select(b => b ? "1" : "0"));
        }
    }

    // Coleção personalizada com override dos métodos protegidos
    public class MinhaColeçãoCustom<T> : Collection<T>
    {
        protected override void InsertItem(int index, T item)
        {
            Console.WriteLine($"InsertItem: Index={index}, Item={item}");
            base.InsertItem(index, item);
        }

        protected override void RemoveItem(int index)
        {
            Console.WriteLine($"RemoveItem: Index={index}, Item={this[index]}");
            base.RemoveItem(index);
        }

        protected override void SetItem(int index, T item)
        {
            Console.WriteLine($"SetItem: Index={index}, NewItem={item}, OldItem={this[index]}");
            base.SetItem(index, item);
        }

        protected override void ClearItems()
        {
            Console.WriteLine("ClearItems: Limpando toda a coleção");
            base.ClearItems();
        }
    }
}