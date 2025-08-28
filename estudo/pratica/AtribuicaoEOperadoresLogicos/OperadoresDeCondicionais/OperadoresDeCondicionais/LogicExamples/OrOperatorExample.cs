using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OperadoresLogicos.LogicExamples
{
    public static class OrOperatorExample
    {
        public static void DemonstrarOr()
        {
            // Exemplo 1: Métodos de pagamento
            bool temCartao = false;
            bool temPix = true;
            bool podePagar = temCartao || temPix;

            Console.WriteLine($"Tem cartão: {temCartao}");
            Console.WriteLine($"Tem PIX: {temPix}");
            Console.WriteLine($"Pode pagar (OR): {podePagar}");

            // Exemplo 2: Dias de semana vs fim de semana
            string dia = "Sábado";
            bool ehDiaUtil = dia == "Segunda" || dia == "Terça" ||
                           dia == "Quarta" || dia == "Quinta" ||
                           dia == "Sexta";
            bool ehFimDeSemana = dia == "Sábado" || dia == "Domingo";

            Console.WriteLine($"\nDia: {dia}");
            Console.WriteLine($"É dia útil: {ehDiaUtil}");
            Console.WriteLine($"É fim de semana: {ehFimDeSemana}");

            // Exemplo 3: Descontos especiais
            int idade = 65;
            bool ehEstudante = true;
            bool temDesconto = idade >= 65 || ehEstudante;

            Console.WriteLine($"\nIdade: {idade}");
            Console.WriteLine($"É estudante: {ehEstudante}");
            Console.WriteLine($"Tem direito a desconto (OR): {temDesconto}");
        }
    }
}