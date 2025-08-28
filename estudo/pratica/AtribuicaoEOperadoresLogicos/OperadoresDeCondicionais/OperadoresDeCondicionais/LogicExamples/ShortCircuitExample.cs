using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OperadoresLogicos.LogicExamples
{
    public static class ShortCircuitExample
    {
        public static void DemonstrarShortCircuit()
        {
            Console.WriteLine("💡 Short-Circuit Evaluation");
            Console.WriteLine("===========================");

            // Exemplo 1: AND - Para na primeira condição falsa
            bool resultado1 = false && MetodoQueSeriaChamado("AND 1");
            Console.WriteLine("Resultado AND 1: " + resultado1);

            bool resultado2 = true && false && MetodoQueSeriaChamado("AND 2");
            Console.WriteLine("Resultado AND 2: " + resultado2);

            // Exemplo 2: OR - Para na primeira condição verdadeira
            bool resultado3 = true || MetodoQueSeriaChamado("OR 1");
            Console.WriteLine("Resultado OR 1: " + resultado3);

            bool resultado4 = false || true || MetodoQueSeriaChamado("OR 2");
            Console.WriteLine("Resultado OR 2: " + resultado4);

            // Exemplo prático
            string texto = null;
            bool textoValido = texto != null && texto.Length > 0;
            Console.WriteLine($"Texto válido: {textoValido} (não causa NullReferenceException)");
        }

        private static bool MetodoQueSeriaChamado(string nome)
        {
            Console.WriteLine($"�️  Método '{nome}' foi executado");
            return true;
        }
    }
}