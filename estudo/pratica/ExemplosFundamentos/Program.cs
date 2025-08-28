// using ExemplosFundamentos.Models;

// Pessoa pessoa1 = new Pessoa(); // instanciando via construtor
// pessoa1.Nome = "teste de pessoa";
// pessoa1.Idade = 25;
// pessoa1.Apresentar();
// Saída:/home/giusepette/Documentos/bootcamp-.net-api-ai/estudo/pratica/exmplos-fundamentos/Models/Pessoa.cs(8,23): warning CS8618: O propriedade não anulável 'Nome' precisa conter um valor não nulo ao sair do construtor. Considere adicionar o modificador "obrigatório" ou declarar o propriedade como anulável. [/home/giusepette/Documentos/bootcamp-.net-api-ai/estudo/pratica/exmplos-fundamentos/exmplos-fundamentos.csproj]
// Nome: teste de pessoa, Idade: 25, Adulto: False, CPF: 0

// Tipos de dados:

using System;

namespace TiposDeDados
{
    class Program
    {
        static void Main(string[] args)
        {
            // ========== TIPOS NUMÉRICOS INTEIROS ==========
            byte numeroPequeno = 255;                 // 0 a 255 (1 byte)
            short numeroCurto = 32000;                // -32,768 a 32,767 (2 bytes)
            int idade = 25;                           // -2.147B a 2.147B (4 bytes)
            long populacaoMundial = 7800000000;       // Números muito grandes (8 bytes)

            // ========== TIPOS NUMÉRICOS DECIMAIS ==========
            float peso = 68.5f;                       // Precisão de 6-9 dígitos (4 bytes)
            double pi = 3.1415926535;                 // Precisão de 15-17 dígitos (8 bytes)
            decimal preco = 19.99m;                   // Precisão de 28-29 dígitos (16 bytes)

            // ========== TIPOS LÓGICOS E TEXTO ==========
            bool estaChovendo = false;                // true ou false (1 bit)
            char letraInicial = 'J';                  // Caractere único (2 bytes)
            string nome = "João Silva";               // Texto (tamanho variável)

            // ========== REATRIBUIÇÃO DE VARIÁVEIS  ==========
            peso = 78.5f;
            nome = "Pedro Silva";

            // ========== TIPOS DE DATA E HORA ==========
            DateTime dataNascimento = new DateTime(1990, 5, 15);
            DateTime agora = DateTime.Now;
            TimeSpan intervalo = new TimeSpan(2, 30, 0); // 2 horas e 30 minutos

            // ========== TIPOS GENÉRICOS ==========
            object qualquerCoisa = "Posso ser qualquer tipo";
            var tipoInferido = "O compilador descobre meu tipo";
            dynamic tipoDinamico = "Mudo em tempo de execução";

            // ========== EXEMPLOS DE USO PRÁTICO ==========
            Console.WriteLine("=== TIPOS DE DADOS EM C# ===");
            Console.WriteLine($"Inteiro (int): {idade}");
            Console.WriteLine($"Decimal (double): {pi}");
            Console.WriteLine($"Monetário (decimal): {preco:C}");
            Console.WriteLine($"Lógico (bool): {estaChovendo}");
            Console.WriteLine($"Texto (string): {nome}");
            Console.WriteLine($"Data (DateTime): {dataNascimento:dd/MM/yyyy}");
            Console.WriteLine($"Caractere (char): {letraInicial}");

            // ========== OPERAÇÕES COM TIPOS ==========
            int x = 10, y = 3;
            int soma = x + y;             // 13
            int divisao = x / y;          // 3 (divisão inteira)
            double divisaoDecimal = x / (double)y; // 3.333 (divisão decimal)

            string textoCombinado = nome + " tem " + idade + " anos";
            string textoInterpolado = $"{nome} tem {idade} anos";

            // ========== CONVERSÕES DE TIPO ==========
            string textoNumero = "123";
            int numeroConvertido = int.Parse(textoNumero);    // Conversão explícita
            int numeroTryParse;
            bool sucesso = int.TryParse(textoNumero, out numeroTryParse); // Conversão segura

            double decimalDouble = 10.5;
            int doubleParaInt = (int)decimalDouble;           // Cast explícito → 10

            // ========== TIPOS ANULÁVEIS ==========
            int? numeroNulo = null;        // Tipo valor que pode ser null
            string? textoNulo = null;      // Tipo referência que pode ser null (C# 8+)

            // ========== VERIFICAÇÃO DE TIPOS ==========
            Console.WriteLine($"\n=== INFORMAÇÕES DOS TIPOS ===");
            Console.WriteLine($"Tipo de 'idade': {idade.GetType()}");
            Console.WriteLine($"Tipo de 'nome': {nome.GetType()}");
            Console.WriteLine($"Tipo de 'agora': {agora.GetType()}");

            object obj = 42;
            if (obj is int numero)         // Pattern matching
            {
                Console.WriteLine($"obj é um int: {numero}");
            }
        }
    }
}