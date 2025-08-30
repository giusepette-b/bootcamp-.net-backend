using System;
using PropriedadesEMetodoConstrutor.Model;

namespace PropriedadesEMetodoConstrutor
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== DEMONSTRAÇÃO DE CONSTRUTORES E PROPRIEDADES ===\n");

            // Demonstração 1: Construtor Básico
            Console.WriteLine("1. CONSTRUTOR BÁSICO:");
            Pessoa pessoa1 = new Pessoa("João", 30);
            pessoa1.ExibirInformacoes();
            Console.WriteLine();

            // Demonstração 2: Construtor com Validação
            Console.WriteLine("2. CONSTRUTOR COM VALIDAÇÃO:");
            try
            {
                Produto produto1 = new Produto("Notebook", -100.00m);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }

            Produto produto2 = new Produto("Mouse", 50.00m);
            produto2.ExibirDetalhes();
            Console.WriteLine();

            // Demonstração 3: Propriedades com lógica
            Console.WriteLine("3. PROPRIEDADES COM LÓGICA:");
            ContaBancaria conta = new ContaBancaria("12345-6", 1000.00m);
            Console.WriteLine($"Saldo inicial: {conta.Saldo:C}");

            conta.Depositar(500.00m);
            Console.WriteLine($"Após depósito: {conta.Saldo:C}");

            conta.Sacar(200.00m);
            Console.WriteLine($"Após saque: {conta.Saldo:C}");

            try
            {
                conta.Sacar(2000.00m);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
            Console.WriteLine();

            // Demonstração 4: Propriedades Auto-Implementadas
            Console.WriteLine("4. PROPRIEDADES AUTO-IMPLEMENTADAS:");
            Carro carro = new Carro("Toyota", "Corolla", 2022);
            Console.WriteLine($"Carro: {carro.Marca} {carro.Modelo} - {carro.Ano}");
            Console.WriteLine($"Está novo? {carro.EhNovo}");
            Console.WriteLine();

            // Demonstração 5: Construtor de Cópia
            Console.WriteLine("5. CONSTRUTOR DE CÓPIA:");
            Pessoa original = new Pessoa("Maria", 25);
            Pessoa copia = new Pessoa(original);

            Console.WriteLine("Original:");
            original.ExibirInformacoes();
            Console.WriteLine("Cópia:");
            copia.ExibirInformacoes();

            // Modificando a cópia
            copia.Nome = "Ana";
            Console.WriteLine("Após modificar a cópia:");
            Console.WriteLine("Original:");
            original.ExibirInformacoes();
            Console.WriteLine("Cópia:");
            copia.ExibirInformacoes();
        }
    }
}


// === DEMONSTRAÇÃO DE CONSTRUTORES E PROPRIEDADES ===

// 1. CONSTRUTOR BÁSICO:
// Nome: João, Idade: 30

// 2. CONSTRUTOR COM VALIDAÇÃO:
// Erro: Preço não pode ser negativo
// Produto: Mouse, Preço: R$ 50,00

// 3. PROPRIEDADES COM LÓGICA:
// Saldo inicial: R$ 1.000,00
// Após depósito: R$ 1.500,00
// Após saque: R$ 1.300,00
// Erro: Saldo insuficiente

// 4. PROPRIEDADES AUTO-IMPLEMENTADAS:
// Carro: Toyota Corolla - 2022
// Está novo? False

// 5. CONSTRUTOR DE CÓPIA:
// Original:
// Nome: Maria, Idade: 25
// Cópia:
// Nome: Maria, Idade: 25
// Após modificar a cópia:
// Original:
// Nome: Maria, Idade: 25
// Cópia:
// Nome: Ana, Idade: 25