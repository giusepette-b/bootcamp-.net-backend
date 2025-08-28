using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System;

namespace OperadoresCondicionais.Condicionais
{
    public static class OperadorTernarioExample
    {
        public static void Demonstrar(int temperatura)
        {
            Console.WriteLine("🔍 OPERADOR TERNÁRIO - If/Else Compacto");
            Console.WriteLine("=======================================");

            string estado = temperatura > 30 ? "Quente" : "Ameno";
            Console.WriteLine($"Temperatura: {temperatura}°C - {estado}");

            double preco = 150.0;
            string categoria = preco > 200 ? "Caro" :
                              preco > 100 ? "Médio" : "Barato";

            Console.WriteLine($"Preço: R$ {preco} - Categoria: {categoria}");
        }
    }
}