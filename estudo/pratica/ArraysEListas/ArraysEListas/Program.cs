using System;
using DesafioFundamentos.Models;

// Coloca o encoding para UTF8 para exibir acentuação
Console.OutputEncoding = System.Text.Encoding.UTF8;

Console.WriteLine("🅿️  SISTEMA DE ESTACIONAMENTO");
Console.WriteLine("=============================\n");

try
{
    // Entrada de valores com validação
    decimal precoInicial = LerDecimal("Digite o preço inicial: R$ ");
    decimal precoPorHora = LerDecimal("Agora digite o preço por hora: R$ ");

    // Instancia a classe Estacionamento
    Estacionamento es = new Estacionamento(precoInicial, precoPorHora);

    string? opcao;
    bool exibirMenu = true;

    // Loop do menu
    while (exibirMenu)
    {
        Console.Clear();
        Console.WriteLine("🎯 MENU PRINCIPAL");
        Console.WriteLine("=================");
        es.MostrarValores();
        Console.WriteLine("\nEscolha uma opção:");
        Console.WriteLine("1 ➤ Cadastrar veículo");
        Console.WriteLine("2 ➤ Remover veículo");
        Console.WriteLine("3 ➤ Listar veículos");
        Console.WriteLine("4 ➤ Ver valores");
        Console.WriteLine("5 ➤ Encerrar");
        Console.Write("\nOpção: ");

        opcao = Console.ReadLine();

        switch (opcao)
        {
            case "1":
                es.AdicionarVeiculo();
                break;

            case "2":
                es.RemoverVeiculo();
                break;

            case "3":
                es.ListarVeiculos();
                break;

            case "4":
                es.MostrarValores();
                break;

            case "5":
                exibirMenu = false;
                Console.WriteLine("Encerrando o sistema...");
                break;

            case null: // ✅ Caso o input seja nulo
                Console.WriteLine("❌ Opção não pode ser vazia!");
                break;

            default:
                Console.WriteLine("❌ Opção inválida! Tente novamente.");
                break;
        }

        if (exibirMenu)
        {
            Console.WriteLine("\n⏎ Pressione ENTER para continuar...");
            Console.ReadLine();
        }
    }
}
catch (Exception ex)
{
    Console.WriteLine($"❌ Erro inesperado: {ex.Message}");
}

Console.WriteLine("\n👋 Programa encerrado. Obrigado!");

// ✅ Método auxiliar para leitura segura de decimais
static decimal LerDecimal(string mensagem)
{
    while (true)
    {
        Console.Write(mensagem);
        string? input = Console.ReadLine();

        // ✅ Verifica se é nulo ou vazio
        if (string.IsNullOrWhiteSpace(input))
        {
            Console.WriteLine("❌ Valor não pode ser vazio! Tente novamente.");
            continue;
        }

        if (decimal.TryParse(input, out decimal valor) && valor >= 0)
        {
            return valor;
        }
        Console.WriteLine("❌ Valor inválido! Digite um número positivo.");
    }
}