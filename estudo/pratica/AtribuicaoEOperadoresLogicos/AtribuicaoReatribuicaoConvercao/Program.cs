// Enum declaration must be before top-level statements
using System;
enum Status { Ativo, Inativo }

// Como foi relatado nos módulos anteriores "=" representa atribuição

// string algumaString = "Alguma string";

// Console.WriteLine(algumaString);

// Operadores aritiméticos:

// int a = 10;

// // Adição
// a += 5;    // a = 15 (equivalente: a = a + 5)

// // Subtração
// a -= 3;    // a = 12 (equivalente: a = a - 3)

// // Multiplicação
// a *= 2;    // a = 24 (equivalente: a = a * 2)

// // Divisão
// a /= 4;    // a = 6 (equivalente: a = a / 4)

// // Módulo (resto da divisão)
// a %= 5;    // a = 1 (equivalente: a = a % 5)

// // Operadores Bitwise

// int b = 10; // 1010 em binário
// int c = 6;  // 0110 em binário

// // AND bitwise
// b &= c;     // b = 2 (0010 em binário)

// // OR bitwise  
// b |= c;     // b = 6 (0110 em binário)

// // XOR bitwise
// b ^= c;     // b = 0 (0000 em binário)

// // Deslocamento à esquerda
// b = 5;      // 0101 em binário
// b <<= 1;    // b = 10 (1010 em binário)

// // Deslocamento à direita
// b >>= 2;    // b = 2 (0010 em binário)

// // Operador de Coalescência Nula

// string nome = null;

// // Atribui apenas se for nulo
// nome ??= "Desconhecido"; // nome = "Desconhecido"

// // Não atribui se já tiver valor
// nome = "João";
// nome ??= "Maria"; // nome continua "João"

// // Combinação com outros operadores

// int x = 10;
// double y = 3.5;

// // Combinação com cast
// x += (int)y; // x = 13 (y é convertido para int)

// // Com operadores de incremento
// x += ++x;    // x = 24 (primeiro incrementa, depois soma)

// // Com expressões complexas
// x *= 2 + 3;  // x = 120 (equivalente: x = x * (2 + 3))

// // Com chamadas de método
// x += Math.Abs(-5); // x = 125

// // Casos especiais e casos de cautela.

// // Com tipos nullable
// int? valor = null;
// valor ??= 100; // valor = 100

// // Com strings (apenas += é válido)
// string texto = "Hello";
// texto += " World"; // texto = "Hello World"

// // Com tipos de ponto flutuante
// double d = 10.5;
// d /= 2.0; // d = 5.25

// // Cuidado com divisão inteira
// int inteiro = 10;
// inteiro /= 4; // inteiro = 2 (não 2.5)


// Conversões de tipos

// int numero = 123;
// string texto = numero.ToString(); // "123"
// string hex = numero.ToString("X"); // "7B" (hexadecimal)
// Console.WriteLine($"converções:texto: {texto}, hex: {hex}");

// // De string para número
// string input = "456";
// int valor = int.Parse(input); // 456
// Console.WriteLine($"converções:input: {input}, valor: {valor}");

// Boxing (valor → referência)
// int valor = 42;
// object obj = valor; // Boxing implícito
// Console.WriteLine($"converções:valor: {valor}, obj: {obj}");

// Unboxing (referência → valor)
// int valorNovo = (int)obj; // Unboxing explícito
// Console.WriteLine($"converções:valorNovo: {valorNovo}, obj: {obj}");

namespace AtribuicaoEOperadoresLogicos
{
    class Program
    {
        static void Main(string[] args)
        {
            // Conversões seguras com TryParse
            string input = "123a";
            if (int.TryParse(input, out int resultado))
            {
                Console.WriteLine($"Valor convertido: {resultado}");
            }
            else
            {
                Console.WriteLine("Conversão falhou");
            }

            // Conversão com formatação
            double valor = 1234.567;
            string formatado = valor.ToString("C"); // "R$ 1.234,57"
            string cientifico = valor.ToString("E2"); // "1.23E+003"

            // Conversão entre tipos numéricos
            int inteiro = 100;
            long longo = inteiro; // Implícita
            inteiro = (int)longo; // Explícita (pode causar overflow)

            // Conversão de/enum
            Status status = (Status)1; // Inativo
            int valorStatus = (int)Status.Ativo; // 0
            // Conversão de null usando Parse e Convert
            string? valorNulo = null;

            // Usando Convert (mais tolerante)
            int resultadoConvert = Convert.ToInt32(valorNulo); // Retorna 0
            Console.WriteLine($"Convert com null: {resultadoConvert}");

            // Usando TryParse (mais seguro)
            string a = "2"; // CORREÇÃO: aspas duplas para string
            if (int.TryParse(a, out int b))
            {
                Console.WriteLine($"Conversão bem-sucedida: {b}");
            }
            else
            {
                Console.WriteLine("Falha na conversão");
            }
            // Usar o Try Parse que é mais seguro


        }

    }
}
