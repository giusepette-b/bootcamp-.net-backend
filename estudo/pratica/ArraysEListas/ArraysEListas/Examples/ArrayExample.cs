using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollectionsExamples.Examples
{
    public static class ArrayExample
    {
        public static void DemonstrarArrays()
        {
            Console.WriteLine("📊 ARRAYS - Coleção de tamanho fixo");
            Console.WriteLine("===================================");

            // ✅ Declaração e inicialização
            int[] numeros = new int[5]; // Array de 5 posições
            // Arrays tem que declarar tipos, assim que declarados, todos os itens devem ser o declarado
            string[] nomes = { "Ana", "João", "Maria" }; // Inicialização direta

            // ✅ Preenchendo array
            for (int i = 0; i < numeros.Length; i++)
            {
                numeros[i] = (i + 1) * 10;
            }
            // ✅ Array Resize
            Array.Resize(ref nomes, nomes.Length = 1);
            nomes[3] = "Qualquer Nome";
            foreach (string itens in nomes)
            {
                Console.WriteLine($"Esse é o nome: {itens}");
            }
            Console.WriteLine("Array de números:");
            ImprimirArray(numeros);

            // ✅ Acesso por índice
            Console.WriteLine($"\nPrimeiro elemento: {nomes[0]}");
            Console.WriteLine($"Último elemento: {nomes[nomes.Length - 1]}");

            // ✅ Métodos estáticos da classe Array
            int[] copia = new int[numeros.Length];
            Array.Copy(numeros, copia, numeros.Length);

            Console.WriteLine("\nArray copiado:");
            ImprimirArray(copia);

            // ✅ Ordenação
            int[] desordenado = { 5, 2, 8, 1, 9 };
            Array.Sort(desordenado);

            Console.WriteLine("\nArray ordenado:");
            ImprimirArray(desordenado);

            // ✅ Busca
            int indice = Array.IndexOf(desordenado, 8);
            Console.WriteLine($"\nNúmero 8 encontrado no índice: {indice}");

            // ✅ Reverse
            Array.Reverse(desordenado);
            Console.WriteLine("Array invertido:");
            ImprimirArray(desordenado);

            // ✅ Array multidimensional
            int[,] matriz = new int[2, 3] { { 1, 2, 3 }, { 4, 5, 6 } };

            Console.WriteLine("\nMatriz 2x3:");
            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                for (int j = 0; j < matriz.GetLength(1); j++)
                {
                    Console.Write($"{matriz[i, j]} ");
                }
                Console.WriteLine();
            }

            // ✅ Array de arrays (jagged array)
            int[][] jaggedArray = new int[3][];
            jaggedArray[0] = new int[] { 1, 2, 3 };
            jaggedArray[1] = new int[] { 4, 5 };
            jaggedArray[2] = new int[] { 6, 7, 8, 9 };

            Console.WriteLine("\nJagged array:");
            for (int i = 0; i < jaggedArray.Length; i++)
            {
                for (int j = 0; j < jaggedArray[i].Length; j++)
                {
                    Console.Write($"{jaggedArray[i][j]} ");
                }
                Console.WriteLine();
            }
        }

        private static void ImprimirArray(int[] array)
        {
            foreach (var item in array)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
        }

        // ✅ Exemplo prático: cálculo de média
        public static double CalcularMedia(int[] valores)
        {
            if (valores == null || valores.Length == 0)
                throw new ArgumentException("Array não pode ser vazio");

            int soma = 0;
            foreach (int valor in valores)
            {
                soma += valor;
            }

            return (double)soma / valores.Length;
        }
    }
}
