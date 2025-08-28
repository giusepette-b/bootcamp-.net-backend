using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OperadoresLogicos.LogicExamples
{
    public static class AndOperatorExample
    {
        public static void DemonstrarAnd()
        {
            // Exemplo 1: Verificação de acesso
            bool temAcesso = true;
            bool ehAdmin = false;
            bool podeAcessar = temAcesso && ehAdmin;

            Console.WriteLine($"Tem acesso: {temAcesso}");
            Console.WriteLine($"É admin: {ehAdmin}");
            Console.WriteLine($"Pode acessar (AND): {podeAcessar}");

            // Exemplo 2: Validação de formulário
            string usuario = "joao123";
            string senha = "senha123";
            bool usuarioValido = usuario.Length >= 5;
            bool senhaValida = senha.Length >= 8;
            bool formularioValido = usuarioValido && senhaValida;

            Console.WriteLine($"\nUsuário válido: {usuarioValido}");
            Console.WriteLine($"Senha válida: {senhaValida}");
            Console.WriteLine($"Formulário válido (AND): {formularioValido}");

            // Exemplo 3: Intervalo numérico
            int idade = 25;
            bool estaNaFaixa1 = idade >= 18 && idade <= 30;
            bool estaNaFaixa2 = idade >= 20 && idade <= 40;

            Console.WriteLine($"\nIdade: {idade}");
            Console.WriteLine($"Entre 18 e 30: {estaNaFaixa1}");
            Console.WriteLine($"Entre 20 e 40: {estaNaFaixa2}");
        }
    }
}