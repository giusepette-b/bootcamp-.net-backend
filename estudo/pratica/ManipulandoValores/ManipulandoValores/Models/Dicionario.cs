using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManipulandoValores.Models

{
    public static class Dicionarios
    {
        public static void Demonstrar()
        {
            // Dicionário simples
            Dictionary<int, string> alunos = new Dictionary<int, string>
            {
                { 1, "Ana Silva" },
                { 2, "João Santos" },
                { 3, "Maria Oliveira" }
            };

            // Adicionando elementos
            alunos.Add(4, "Pedro Costa");
            alunos[5] = "Julia Mendes"; // Adiciona ou atualiza

            Console.WriteLine("Dicionário de alunos:");
            foreach (var aluno in alunos)
            {
                Console.WriteLine($"ID: {aluno.Key}, Nome: {aluno.Value}");
            }

            // Buscas
            if (alunos.TryGetValue(3, out string nomeAluno3))
            {
                Console.WriteLine($"\nAluno com ID 3: {nomeAluno3}");
            }

            // Dicionário com valores complexos
            Dictionary<string, (int idade, string cidade)> pessoas = new Dictionary<string, (int, string)>
            {
                { "Ana", (25, "São Paulo") },
                { "Carlos", (30, "Rio de Janeiro") },
                { "Maria", (22, "Belo Horizonte") }
            };

            Console.WriteLine("\nDicionário de pessoas:");
            foreach (var pessoa in pessoas)
            {
                Console.WriteLine($"{pessoa.Key}: {pessoa.Value.idade} anos, {pessoa.Value.cidade}");
            }

            // Atualizando valores
            pessoas["Ana"] = (26, "Campinas");
            Console.WriteLine($"\nAna atualizada: {pessoas["Ana"].idade} anos, {pessoas["Ana"].cidade}");
        }
    }
}