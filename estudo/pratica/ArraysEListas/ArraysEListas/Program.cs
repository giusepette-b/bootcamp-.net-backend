using System;
using CollectionsExamples.Examples;

namespace CollectionsExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("📚 COLEÇÕES EM C# - ARRAYS E LISTAS");
            Console.WriteLine("===================================\n");

            ArrayExample.DemonstrarArrays();
            Console.WriteLine();

            ListExample.DemonstrarLists();
            Console.WriteLine();

            DictionaryExample.DemonstrarDictionaries();
            Console.WriteLine();

            HashSetExample.DemonstrarHashSets();
            Console.WriteLine();

            StackQueueExample.DemonstrarStackQueue();
            Console.WriteLine();

            Console.WriteLine("🎉 Fim da demonstração de coleções!");
        }
    }
}