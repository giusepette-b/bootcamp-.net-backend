using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TuplasOperadorTernarioDesconstrucaoDeObjeto.Models

{
    public static class OperadorTernario
    {
        public static void Demonstrar()
        {
            Console.WriteLine("=== OPERADOR TERNÁRIO EM C# ===\n");

            // ==================================================================
            // OPERADOR TERNÁRIO BÁSICO - condição ? valor_se_verdadeiro : valor_se_falso
            // ==================================================================

            // 1. Uso básico do operador ternário
            int idade = 20;
            string status = idade >= 18 ? "Maior de idade" : "Menor de idade";
            Console.WriteLine($"1. Básico - Idade: {idade}, Status: {status}");

            // 2. Ternário com tipos numéricos
            double preco = 100.0;
            double desconto = preco > 50.0 ? preco * 0.1 : 0;
            Console.WriteLine($"2. Numérico - Preço: {preco:C}, Desconto: {desconto:C}");

            // ==================================================================
            // TERNÁRIOS ANINHADOS - Múltiplas condições
            // ==================================================================

            // 3. Ternário aninhado - avalia múltiplas condições
            int nota = 85;
            string conceito = nota >= 90 ? "A" :
                             nota >= 80 ? "B" :
                             nota >= 70 ? "C" :
                             nota >= 60 ? "D" : "F";
            Console.WriteLine($"3. Aninhado - Nota: {nota}, Conceito: {conceito}");

            // ==================================================================
            // TERNÁRIO COM CHAMADA DE MÉTODOS
            // ==================================================================

            // 4. Ternário executando métodos diferentes
            bool usuarioPremium = true;
            string mensagem = usuarioPremium ? GerarMensagemPremium() : GerarMensagemComum();
            Console.WriteLine($"4. Com métodos - {mensagem}");

            // ==================================================================
            // TERNÁRIO PARA ATRIBUIÇÃO CONDICIONAL
            // ==================================================================

            // 5. Atribuição condicional de valores
            string nome = null;
            string nomeExibicao = nome ?? "Visitante"; // Operador null-coalescing
            string saudacao = nomeExibicao.Length > 5 ? nomeExibicao.Substring(0, 5) + "..." : nomeExibicao;
            Console.WriteLine($"5. Atribuição - Saudação: Olá, {saudacao}!");

            // ==================================================================
            // TERNÁRIO EM EXPRESSÕES COMPLEXAS
            // ==================================================================

            // 6. Ternário em expressões matemáticas
            int quantidade = 3;
            double precoUnitario = 25.0;
            double total = quantidade * precoUnitario;
            double totalComDesconto = total > 50 ? total * 0.9 : total;
            Console.WriteLine($"6. Expressão - Total: {total:C}, Com desconto: {totalComDesconto:C}");

            // ==================================================================
            // TERNÁRIO COM TIPOS DIFERENTES (usando object)
            // ==================================================================

            // 7. Ternário retornando tipos diferentes (cuidado - não recomendado)
            object resultado = idade > 18 ? "Aprovado" : false;
            Console.WriteLine($"7. Tipos diferentes - Resultado: {resultado} ({resultado.GetType().Name})");

            // ==================================================================
            // TERNÁRIO VS IF-ELSE - Quando usar cada um
            // ==================================================================

            // 8. Comparação ternário vs if-else
            int numero = 10;

            // Método 1: Ternário (para expressões simples)
            string parOuImpar = numero % 2 == 0 ? "Par" : "Ímpar";

            // Método 2: If-else (para lógica complexa)
            string categoria;
            if (numero == 0)
                categoria = "Zero";
            else if (numero > 0)
                categoria = "Positivo";
            else
                categoria = "Negativo";

            Console.WriteLine($"8. Comparação - {numero} é {parOuImpar} e {categoria}");

            // ==================================================================
            // TERNÁRIO EM INITIALIZERS E PROPRIEDADES
            // ==================================================================

            // 9. Ternário em inicialização de objetos
            var config = new Configuracao
            {
                Modo = DateTime.Now.Hour < 18 ? "Dia" : "Noite",
                Tema = DateTime.Now.Hour < 18 ? "Claro" : "Escuro"
            };
            Console.WriteLine($"9. Inicialização - Modo: {config.Modo}, Tema: {config.Tema}");

            // ==================================================================
            // LIMITAÇÕES E BOAS PRÁTICAS
            // ==================================================================

            Console.WriteLine("\n💡 BOAS PRÁTICAS:");
            Console.WriteLine("   • Use ternário para condições SIMPLES");
            Console.WriteLine("   • Evite ternários aninhados complexos");
            Console.WriteLine("   • Prefira if-else para lógica complexa");
            Console.WriteLine("   • Mantenha a legibilidade acima de tudo");
        }

        private static string GerarMensagemPremium()
        {
            return "Bem-vindo usuário Premium!";
        }

        private static string GerarMensagemComum()
        {
            return "Bem-vindo!";
        }
    }

    public class Configuracao
    {
        public string Modo { get; set; }
        public string Tema { get; set; }
    }
}