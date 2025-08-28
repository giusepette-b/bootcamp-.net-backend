using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace OperadoresCondicionais.Condicionais
{
    public static class IfElseExample
    {
        public static void Demonstrar()
        {
            Console.WriteLine("🔍 IF/ELSE - Controle de Fluxo Básico");
            Console.WriteLine("=====================================");

            int idade = 18;
            Console.WriteLine($"Idade: {idade}");

            if (idade >= 18)
            {
                Console.WriteLine("✅ Maior de idade - Pode dirigir");
            }

            double nota = 6.5;
            Console.WriteLine($"\nNota: {nota}");

            if (nota >= 7.0)
            {
                Console.WriteLine("🎉 Aprovado!");
            }
            else if (nota >= 5.0)
            {
                Console.WriteLine("📚 Recuperação");
            }
            else
            {
                Console.WriteLine("❌ Reprovado");
            }
        }
        public static void VerificaMaiorQueDez(int i)
        {
            if (i > 10)
            {
                Console.WriteLine($"{i} é maior que 10.");
            }
            else
            {
                Console.WriteLine($"{i} não é maior que 10.");
            }
        }
    }
}