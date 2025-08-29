using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollectionsExamples.Examples
{
    public static class ListExample
    {
        public static void DemonstrarLists()
        {
            Console.WriteLine("📝 LISTAS - Coleção de tamanho dinâmico");
            Console.WriteLine("========================================");

            // ✅ Criação de lista
            List<string> frutas = new List<string>();
            List<int> numeros = new List<int> { 1, 2, 3, 4, 5 };

            // ✅ Adicionando elementos
            frutas.Add("Maçã");
            frutas.Add("Banana");
            frutas.Add("Laranja");
            frutas.AddRange(new[] { "Uva", "Morango" });

            Console.WriteLine("Lista de frutas:");
            ImprimirLista(frutas);

            // ✅ Acesso e modificação
            Console.WriteLine($"\nPrimeira fruta: {frutas[0]}");
            frutas[0] = "Pera"; // Modificação
            Console.WriteLine("Após modificar primeira fruta:");
            ImprimirLista(frutas);

            // ✅ Métodos de remoção
            frutas.Remove("Banana");
            Console.WriteLine("\nApós remover Banana:");
            ImprimirLista(frutas);

            frutas.RemoveAt(0); // Remove primeiro elemento
            Console.WriteLine("Após remover primeiro elemento:");
            ImprimirLista(frutas);

            // ✅ Busca e verificação
            bool contemUva = frutas.Contains("Uva");
            int indiceUva = frutas.IndexOf("Uva");
            Console.WriteLine($"\nContém Uva? {contemUva}");
            Console.WriteLine($"Índice da Uva: {indiceUva}");

            // ✅ Ordenação
            frutas.Sort();
            Console.WriteLine("\nLista ordenada:");
            ImprimirLista(frutas);

            // ✅ Inversão
            frutas.Reverse();
            Console.WriteLine("Lista invertida:");
            ImprimirLista(frutas);

            // ✅ Capacidade e contagem
            Console.WriteLine($"\nCapacidade: {frutas.Capacity}");
            Console.WriteLine($"Quantidade: {frutas.Count}");

            // ✅ Limpeza da lista
            frutas.Clear();
            Console.WriteLine("Após limpar a lista:");
            Console.WriteLine($"Quantidade: {frutas.Count}");

            // ✅ Exemplo prático: filtragem
            List<int> idades = new List<int> { 15, 25, 35, 45, 55, 65 };
            List<int> maioresDe30 = idades.FindAll(idade => idade > 30);

            Console.WriteLine("\nIdades maiores que 30:");
            ImprimirLista(maioresDe30);

            // ✅ Conversão para array e vice-versa
            int[] arrayIdades = idades.ToArray();
            List<int> listaDeArray = new List<int>(arrayIdades);
        }

        private static void ImprimirLista<T>(List<T> lista)
        {
            foreach (var item in lista)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
        }

        // ✅ Exemplo prático: gerenciamento de usuários
        public static void GerenciarUsuarios()
        {
            List<string> usuarios = new List<string>();

            // Adicionar usuários
            usuarios.Add("alice@email.com");
            usuarios.Add("bob@email.com");
            usuarios.Add("charlie@email.com");

            // Verificar se usuário existe
            if (!usuarios.Contains("diana@email.com"))
            {
                usuarios.Add("diana@email.com");
            }

            // Remover usuário
            usuarios.Remove("bob@email.com");

            Console.WriteLine("Usuários ativos:");
            foreach (var usuario in usuarios)
            {
                Console.WriteLine($"- {usuario}");
            }
        }
    }
}