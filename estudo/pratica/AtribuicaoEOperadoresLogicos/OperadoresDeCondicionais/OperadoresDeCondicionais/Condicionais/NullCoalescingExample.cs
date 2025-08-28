using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
public static class NullCoalescingExample
{
    public static void Demonstrar()
    {
        Console.WriteLine("🔍 NULL COALESCING - Lidando com Valores Nulos");
        Console.WriteLine("=============================================");

        string nome = null;
        string nomePadrao = nome ?? "Visitante";
        Console.WriteLine($"Nome: {nomePadrao}");

        // Operador ??= (atribui apenas se for nulo)
        nome ??= "Convidado";
        Console.WriteLine($"Nome após ??=: {nome}");

        // Encadeamento de ??
        string apelido = null;
        string nomeCompleto = apelido ?? nome ?? "Anônimo";
        Console.WriteLine($"Nome completo: {nomeCompleto}");

        // Operador ?. (null conditional)
        string mensagem = null;
        int? tamanho = mensagem?.Length;
        Console.WriteLine($"Tamanho da mensagem: {tamanho ?? 0}");
    }
}