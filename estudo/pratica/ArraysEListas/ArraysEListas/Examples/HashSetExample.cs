using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollectionsExamples.Examples
{
    public static class HashSetExample
    {
        public static void DemonstrarHashSets()
        {
            Console.WriteLine("🎯 HASHSETS - Coleção de elementos únicos");
            Console.WriteLine("========================================");

            // ✅ Criação de HashSet
            HashSet<int> numerosUnicos = new HashSet<int> { 1, 2, 3, 4, 5 };
            HashSet<string> emails = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

            // ✅ Adicionando elementos (apenas únicos)
            numerosUnicos.Add(3); // Não adiciona, já existe
            numerosUnicos.Add(6); // Adiciona

            emails.Add("ALICE@EMAIL.COM");
            emails.Add("alice@email.com"); // Não adiciona (case insensitive)
            emails.Add("bob@email.com");

            Console.WriteLine("HashSet de números:");
            ImprimirHashSet(numerosUnicos);

            Console.WriteLine("\nHashSet de emails:");
            ImprimirHashSet(emails);

            // ✅ Operações de conjunto
            HashSet<int> conjuntoA = new HashSet<int> { 1, 2, 3, 4, 5 };
            HashSet<int> conjuntoB = new HashSet<int> { 4, 5, 6, 7, 8 };

            // União
            HashSet<int> uniao = new HashSet<int>(conjuntoA);
            uniao.UnionWith(conjuntoB);
            Console.WriteLine("\nUnião A ∪ B:");
            ImprimirHashSet(uniao);

            // Interseção
            HashSet<int> intersecao = new HashSet<int>(conjuntoA);
            intersecao.IntersectWith(conjuntoB);
            Console.WriteLine("Interseção A ∩ B:");
            ImprimirHashSet(intersecao);

            // Diferença
            HashSet<int> diferenca = new HashSet<int>(conjuntoA);
            diferenca.ExceptWith(conjuntoB);
            Console.WriteLine("Diferença A - B:");
            ImprimirHashSet(diferenca);

            // ✅ Verificação de subconjunto
            HashSet<int> subconjunto = new HashSet<int> { 1, 2 };
            bool ehSubconjunto = subconjunto.IsSubsetOf(conjuntoA);
            Console.WriteLine($"\n{{1, 2}} é subconjunto de A? {ehSubconjunto}");

            // ✅ Exemplo prático: sistema de tags
            HashSet<string> tagsArtigo = new HashSet<string> { "tech", "csharp", "programming" };
            HashSet<string> tagsUsuario = new HashSet<string> { "csharp", "dotnet", "web" };

            // Tags em comum
            tagsArtigo.IntersectWith(tagsUsuario);
            Console.WriteLine("\nTags em comum:");
            ImprimirHashSet(tagsArtigo);
        }

        private static void ImprimirHashSet<T>(HashSet<T> hashSet)
        {
            foreach (var item in hashSet)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
        }
    }
}