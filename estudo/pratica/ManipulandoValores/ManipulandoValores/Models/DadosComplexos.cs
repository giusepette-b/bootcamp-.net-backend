using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManipulandoValores.Models

{
    public static class DadosComplexos
    {
        public static void Demonstrar()
        {
            List<Aluno> alunos = new List<Aluno>
            {
                new Aluno { Id = 1, Nome = "Ana", Notas = new List<double> { 8.5, 9.0, 7.5 } },
                new Aluno { Id = 2, Nome = "João", Notas = new List<double> { 6.0, 7.5, 8.0 } },
                new Aluno { Id = 3, Nome = "Maria", Notas = new List<double> { 9.5, 9.0, 8.5 } },
                new Aluno { Id = 4, Nome = "Pedro", Notas = new List<double> { 5.0, 6.5, 7.0 } }
            };

            Console.WriteLine("ALUNOS E NOTAS:");
            foreach (var aluno in alunos)
            {
                double media = aluno.Notas.Average();
                Console.WriteLine($"{aluno.Nome}: {string.Join(" | ", aluno.Notas)} → Média: {media:F2}");
            }

            // Alunos com média >= 7
            var aprovados = alunos.Where(a => a.Notas.Average() >= 7.0).ToList();
            Console.WriteLine("\nAPROVADOS:");
            foreach (var aluno in aprovados)
            {
                Console.WriteLine($"{aluno.Nome} - Média: {aluno.Notas.Average():F2}");
            }

            // Melhor nota de cada aluno
            Console.WriteLine("\nMELHOR NOTA DE CADA ALUNO:");
            foreach (var aluno in alunos)
            {
                double melhorNota = aluno.Notas.Max();
                Console.WriteLine($"{aluno.Nome}: {melhorNota}");
            }

            // Estatísticas gerais
            double mediaGeral = alunos.SelectMany(a => a.Notas).Average();
            double melhorNotaGeral = alunos.SelectMany(a => a.Notas).Max();
            double piorNotaGeral = alunos.SelectMany(a => a.Notas).Min();

            Console.WriteLine($"\nESTATÍSTICAS GERAIS:");
            Console.WriteLine($"Média geral: {mediaGeral:F2}");
            Console.WriteLine($"Melhor nota: {melhorNotaGeral}");
            Console.WriteLine($"Pior nota: {piorNotaGeral}");

            // Agrupamento por desempenho
            var porDesempenho = alunos.GroupBy(a =>
                a.Notas.Average() >= 7 ? "Aprovado" :
                a.Notas.Average() >= 5 ? "Recuperação" : "Reprovado");

            Console.WriteLine("\nPOR DESEMPENHO:");
            foreach (var grupo in porDesempenho)
            {
                Console.WriteLine($"\n{grupo.Key}:");
                foreach (var aluno in grupo)
                {
                    Console.WriteLine($"- {aluno.Nome} (Média: {aluno.Notas.Average():F2})");
                }
            }
        }
    }

    public class Aluno
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public List<double> Notas { get; set; }
    }
}