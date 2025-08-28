using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
// Exemplo simples de Pattern Matching
public static class PatternMatchingExample
{
    public static void Demonstrar()
    {
        Console.WriteLine("🔍 PATTERN MATCHING - Verificações Inteligentes");
        Console.WriteLine("==============================================");

        object obj = "Hello World";

        // Pattern matching com switch
        switch (obj)
        {
            case string s when s.Length > 5:
                Console.WriteLine($"String longa: {s}");
                break;
            case string s:
                Console.WriteLine($"String curta: {s}");
                break;
            case int i when i > 0:
                Console.WriteLine($"Número positivo: {i}");
                break;
            case int i:
                Console.WriteLine($"Número: {i}");
                break;
            case null:
                Console.WriteLine("Valor nulo");
                break;
            default:
                Console.WriteLine("Tipo desconhecido");
                break;
        }

        // Pattern matching com is (mais simples)
        if (obj is string texto && texto.Length > 10)
        {
            Console.WriteLine($"Texto muito longo: {texto}");
        }

        object valor = "texto";

        // Verifica se NÃO é um inteiro
        if (valor is not int)
        {
            Console.WriteLine("Não é um inteiro");
        }

        // Verifica se NÃO é nulo
        if (valor is not null)
        {
            Console.WriteLine("Não é nulo");
        }

        // Combinações com pattern matching
        int numero = 10;
        var resultado = numero switch
        {
            not 0 => "Não é zero",
            _ => "É zero"
        };
    }
}