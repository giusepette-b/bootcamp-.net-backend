using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollectionsExamples.Examples
{
    public static class DictionaryExample
    {
        public static void DemonstrarDictionaries()
        {
            Console.WriteLine("🔑 DICTIONARIES - Coleção chave-valor");
            Console.WriteLine("====================================");

            // ✅ Criação de dictionary
            Dictionary<string, int> idadePessoas = new Dictionary<string, int>();
            Dictionary<int, string> produtos = new Dictionary<int, string>
            {
                { 1, "Notebook" },
                { 2, "Mouse" },
                { 3, "Teclado" }
            };

            // ✅ Adicionando elementos
            idadePessoas.Add("Alice", 25);
            idadePessoas.Add("Bob", 30);
            idadePessoas["Charlie"] = 35; // Outra forma de adicionar

            Console.WriteLine("Dictionary de idades:");
            ImprimirDictionary(idadePessoas);

            // ✅ Acesso por chave
            Console.WriteLine($"\nIdade da Alice: {idadePessoas["Alice"]}");

            // ✅ Verificação de existência
            if (idadePessoas.ContainsKey("Bob"))
            {
                Console.WriteLine("Bob está no dictionary");
            }

            if (idadePessoas.ContainsValue(30))
            {
                Console.WriteLine("Alguém tem 30 anos");
            }

            // ✅ Remoção
            idadePessoas.Remove("Bob");
            Console.WriteLine("\nApós remover Bob:");
            ImprimirDictionary(idadePessoas);

            // ✅ Tentativa segura de acesso
            if (idadePessoas.TryGetValue("Alice", out int idadeAlice))
            {
                Console.WriteLine($"Alice tem {idadeAlice} anos (acesso seguro)");
            }

            // ✅ Iteração pelas chaves e valores
            Console.WriteLine("\nChaves no dictionary:");
            foreach (string nome in idadePessoas.Keys)
            {
                Console.WriteLine($"- {nome}");
            }

            Console.WriteLine("\nValores no dictionary:");
            foreach (int idade in idadePessoas.Values)
            {
                Console.WriteLine($"- {idade} anos");
            }

            // ✅ Exemplo prático: contador de palavras
            Dictionary<string, int> contadorPalavras = ContarPalavras(
                "o rato roeu a roupa do rei de roma e o rei ficou com raiva do rato"
            );

            Console.WriteLine("\nContagem de palavras:");
            ImprimirDictionary(contadorPalavras);

            // ✅ Limpeza
            idadePessoas.Clear();
            Console.WriteLine($"\nApós clear, quantidade: {idadePessoas.Count}");
        }

        private static void ImprimirDictionary<TKey, TValue>(Dictionary<TKey, TValue> dictionary)
        {
            foreach (var kvp in dictionary)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }
        }

        public static Dictionary<string, int> ContarPalavras(string texto)
        {
            Dictionary<string, int> contador = new Dictionary<string, int>();
            string[] palavras = texto.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            foreach (string palavra in palavras)
            {
                if (contador.ContainsKey(palavra))
                {
                    contador[palavra]++;
                }
                else
                {
                    contador[palavra] = 1;
                }
            }

            return contador;
        }
    }
}