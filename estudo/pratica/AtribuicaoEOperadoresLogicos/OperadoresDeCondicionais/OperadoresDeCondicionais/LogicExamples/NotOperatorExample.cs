using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OperadoresLogicos.LogicExamples
{
    public static class NotOperatorExample
    {
        public static void DemonstrarNot()
        {
            // Exemplo 1: Inversão de estado
            bool estaLogado = false;
            bool precisaLogar = !estaLogado;

            Console.WriteLine($"Está logado: {estaLogado}");
            Console.WriteLine($"Precisa logar (NOT): {precisaLogar}");

            // Exemplo 2: Validação negativa
            string email = "usuario@email";
            bool emailInvalido = !email.Contains("@");

            Console.WriteLine($"\nEmail: {email}");
            Console.WriteLine($"Email inválido (NOT): {emailInvalido}");

            // Exemplo 3: Acesso negado
            bool temPermissao = false;
            bool acessoNegado = !temPermissao;

            Console.WriteLine($"\nTem permissão: {temPermissao}");
            Console.WriteLine($"Acesso negado (NOT): {acessoNegado}");

            // Exemplo 4: Dupla negação
            bool ativo = true;
            bool naoInativo = !!ativo; // !!true = true

            Console.WriteLine($"\nAtivo: {ativo}");
            Console.WriteLine($"Não inativo (!!): {naoInativo}");
        }
    }
}