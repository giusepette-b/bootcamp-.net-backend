using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OperadoresCondicionais.Condicionais
{
    public static class SwitchCaseExample
    {
        public static void Demonstrar()
        {
            Console.WriteLine("🔍 SWITCH/CASE - Múltiplas Condições");
            Console.WriteLine("====================================");

            string diaSemana = "Quarta";
            Console.WriteLine($"Dia da semana: {diaSemana}");

            switch (diaSemana)
            {
                case "Segunda":
                    Console.WriteLine("😴 Início da semana...");
                    break;
                case "Terça":
                case "Quarta":
                case "Quinta":
                    Console.WriteLine("💼 Dia de trabalho");
                    break;
                case "Sexta":
                    Console.WriteLine("🎉 Sextou!");
                    break;
                case "Sábado":
                case "Domingo":
                    Console.WriteLine("🌅 Final de semana!");
                    break;
                default:
                    Console.WriteLine("❌ Dia inválido");
                    break;
            }
        }
    }
}