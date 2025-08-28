using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace OperadoresLogicos.LogicExamples
{
    public static class CombinadosExample
    {
        public static void DemonstrarCombinados()
        {
            // Exemplo 1: Sistema de acesso
            int idade = 20;
            bool temConvite = true;
            bool ehVip = false;

            bool podeEntrar = (idade >= 18 && temConvite) || ehVip;

            Console.WriteLine($"Idade: {idade}");
            Console.WriteLine($"Tem convite: {temConvite}");
            Console.WriteLine($"É VIP: {ehVip}");
            Console.WriteLine($"Pode entrar: {podeEntrar}");

            // Exemplo 2: Validação complexa
            string usuario = "ana";
            string senha = "12345678";
            bool usuarioValido = usuario.Length >= 3 && !usuario.Contains(" ");
            bool senhaValida = senha.Length >= 8 || senha == "admin";

            Console.WriteLine($"\nUsuário válido: {usuarioValido}");
            Console.WriteLine($"Senha válida: {senhaValida}");

            // Exemplo 3: Lógica de desconto
            int quantidade = 5;
            double preco = 100.0;
            bool ehClientePremium = true;
            bool temDesconto = (quantidade > 10 || preco > 500) && !ehClientePremium;

            Console.WriteLine($"\nQuantidade: {quantidade}");
            Console.WriteLine($"Preço: {preco}");
            Console.WriteLine($"É cliente premium: {ehClientePremium}");
            Console.WriteLine($"Tem desconto: {temDesconto}");
        }
    }
}