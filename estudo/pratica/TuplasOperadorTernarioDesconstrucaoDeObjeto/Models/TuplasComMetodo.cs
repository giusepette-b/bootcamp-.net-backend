using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TuplasOperadorTernarioDesconstrucaoDeObjeto.Models


{
    public static class TuplasComMetodos
    {
        public static void Demonstrar()
        {
            Console.WriteLine("=== TUPLAS COM MÉTODOS (DELEGATES) ===\n");

            // ==================================================================
            // 1. TUPLA COM ACTION - Método que não retorna valor (void)
            // ==================================================================
            Console.WriteLine("1. TUPLA COM ACTION (métodos void):");

            // Definindo uma tupla que contém Actions (métodos sem retorno)
            (Action Saudacao, Action Despedida) metodos = (
                () => Console.WriteLine("   Olá! Bem-vindo!"),
                () => Console.WriteLine("   Até logo! Volte sempre!")
            );

            // Executando os métodos da tupla
            metodos.Saudacao();
            metodos.Despedida();

            // ==================================================================
            // 2. TUPLA COM FUNC - Método que retorna valor
            // ==================================================================
            Console.WriteLine("\n2. TUPLA COM FUNC (métodos com retorno):");

            // Func<int, int, int> - recebe 2 ints e retorna 1 int
            (Func<int, int, int> Soma, Func<int, int, int> Multiplicacao) operacoes = (
                (a, b) => a + b,
                (a, b) => a * b
            );

            int resultadoSoma = operacoes.Soma(5, 3);
            int resultadoMulti = operacoes.Multiplicacao(5, 3);

            Console.WriteLine($"   Soma: 5 + 3 = {resultadoSoma}");
            Console.WriteLine($"   Multiplicação: 5 * 3 = {resultadoMulti}");

            // ==================================================================
            // 3. TUPLA COM MÉTODOS COMPLEXOS
            // ==================================================================
            Console.WriteLine("\n3. TUPLA COM MÉTODOS COMPLEXOS:");

            var processadores = (
                ValidarEmail: new Func<string, bool>(email => email.Contains("@")),
                Formatarnome: new Func<string, string>(nome => nome.Trim().ToUpper()),
                CalcularIdade: new Func<DateTime, int>(dataNasc =>
                    (DateTime.Now - dataNasc).Days / 365)
            );

            bool emailValido = processadores.ValidarEmail("usuario@email.com");
            string nomeFormatado = processadores.Formatarnome("   joão silva   ");
            int idade = processadores.CalcularIdade(new DateTime(1990, 5, 15));

            Console.WriteLine($"   Email válido: {emailValido}");
            Console.WriteLine($"   Nome formatado: {nomeFormatado}");
            Console.WriteLine($"   Idade calculada: {idade} anos");

            // ==================================================================
            // 4. MÉTODO QUE RETORNA TUPLA COM DELEGATES
            // ==================================================================
            Console.WriteLine("\n4. MÉTODO RETORNANDO TUPLA COM DELEGATES:");

            var (validar, processar) = ObterProcessadores();

            bool isValid = validar("input");
            string processed = processar("dados");

            Console.WriteLine($"   Validação: {isValid}");
            Console.WriteLine($"   Processamento: {processed}");

            // ==================================================================
            // 5. DELEGATES PRÉ-DEFINIDOS NA TUPLA - CORRIGIDO
            // ==================================================================
            Console.WriteLine("\n5. DELEGATES PRÉ-DEFINIDOS:");

            // CORREÇÃO: Especificar explicitamente os tipos dos delegates
            (Func<int, int, int> Soma, Func<int, int, int> Subtracao, Func<int, int, int> Multiplicacao)
                operacoesMatematicas = (
                Soma: Somar,
                Subtracao: Subtrair,
                Multiplicacao: Multiplicar
            );

            Console.WriteLine($"   Soma: {operacoesMatematicas.Soma(10, 5)}");
            Console.WriteLine($"   Subtração: {operacoesMatematicas.Subtracao(10, 5)}");
            Console.WriteLine($"   Multiplicação: {operacoesMatematicas.Multiplicacao(10, 5)}");

            // ==================================================================
            // 6. TUPLA COM MÚLTIPLOS TIPOS DE DELEGATES
            // ==================================================================
            Console.WriteLine("\n6. TUPLA COM MÚLTIPLOS DELEGATES:");

            var todosMetodos = (
                Acao: new Action(() => Console.WriteLine("   Ação executada!")),
                FuncString: new Func<string>(() => "Resultado da função"),
                FuncComParam: new Func<int, string>(num => $"Número: {num}"),
                Predicado: new Predicate<int>(x => x > 0)
            );

            todosMetodos.Acao();
            Console.WriteLine($"   {todosMetodos.FuncString()}");
            Console.WriteLine($"   {todosMetodos.FuncComParam(42)}");
            Console.WriteLine($"   Predicado (5 > 0): {todosMetodos.Predicado(5)}");

            // ==================================================================
            // 7. USO PRÁTICO - SISTEMA DE PLUGINS/EXTENSÕES
            // ==================================================================
            Console.WriteLine("\n7. CASO PRÁTICO - SISTEMA DE PLUGINS:");

            var pluginProcessamento = (
                Validar: new Func<string, bool>(input => !string.IsNullOrEmpty(input)),
                Processar: new Func<string, string>(input => input.ToUpper()),
                PosProcessar: new Action<string>(result =>
                    Console.WriteLine($"   Resultado processado: {result}"))
            );

            string entrada = "texto para processar";

            if (pluginProcessamento.Validar(entrada))
            {
                string resultado = pluginProcessamento.Processar(entrada);
                pluginProcessamento.PosProcessar(resultado);
            }
            else
            {
                Console.WriteLine("   Entrada inválida!");
            }

            // ==================================================================
            // 8. ALTERNATIVA COM VAR E CAST EXPLÍCITO - CORRIGIDO
            // ==================================================================
            Console.WriteLine("\n8. ALTERNATIVA COM CAST EXPLÍCITO:");

            var operacoesCast = (
                Soma: (Func<int, int, int>)Somar,
                Subtracao: (Func<int, int, int>)Subtrair,
                Multiplicacao: (Func<int, int, int>)Multiplicar
            );

            Console.WriteLine($"   Soma com cast: {operacoesCast.Soma(8, 2)}");
            Console.WriteLine($"   Subtração com cast: {operacoesCast.Subtracao(8, 2)}");
        }

        // ==================================================================
        // MÉTODOS AUXILIARES PARA OS DELEGATES
        // ==================================================================
        private static (Func<string, bool>, Func<string, string>) ObterProcessadores()
        {
            return (
                input => input.Length > 3,
                dados => $"Processado: {dados}"
            );
        }

        private static int Somar(int a, int b) => a + b;
        private static int Subtrair(int a, int b) => a - b;
        private static int Multiplicar(int a, int b) => a * b;
    }
}