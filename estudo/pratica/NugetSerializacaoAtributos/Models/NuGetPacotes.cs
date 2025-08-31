using System;
using System.Collections.Generic;

namespace NugetSerializacaoAtributos.Models
{
    public static class NuGetPacotes
    {
        public static void Demonstrar()
        {
            Console.WriteLine("=== NUGET E PACOTES EXTERNOS ===\n");

            // ==================================================================
            // 1. O QUE É O NUGET?
            // ==================================================================
            Console.WriteLine("1. CONCEITO DO NUGET:");
            Console.WriteLine("   • Gerenciador de pacotes para .NET");
            Console.WriteLine("   • Biblioteca de pacotes open-source");
            Console.WriteLine("   • Facilita inclusão de dependências");
            Console.WriteLine("   • Integrado com Visual Studio e dotnet CLI");

            // ==================================================================
            // 2. COMO INSTALAR PACOTES NUGET
            // ==================================================================
            Console.WriteLine("\n2. INSTALAÇÃO DE PACOTES:");
            Console.WriteLine("   • Visual Studio: PM> Install-Package NomePacote");
            Console.WriteLine("   • dotnet CLI: dotnet add package NomePacote");
            Console.WriteLine("   • Editando .csproj: <PackageReference Include=\"NomePacote\" Version=\"1.0.0\" />");

            // ==================================================================
            // 3. PACOTES POPULARES PARA SERIALIZAÇÃO
            // ==================================================================
            Console.WriteLine("\n3. PACOTES POPULARES PARA SERIALIZAÇÃO:");
            Console.WriteLine("   • Newtonsoft.Json (Json.NET) - Alternativa ao System.Text.Json");
            Console.WriteLine("   • System.Text.Json - Nativo do .NET (recomendado)");
            Console.WriteLine("   • MessagePack - Serialização binária eficiente");
            Console.WriteLine("   • Protobuf-net - Protocol Buffers para .NET");

            // ==================================================================
            // 4. EXEMPLO: NEWTONSOFT.JSON VS SYSTEM.TEXT.JSON
            // ==================================================================
            Console.WriteLine("\n4. NEWTONSOFT.JSON VS SYSTEM.TEXT.JSON:");

            var produto = new ProdutoSimples
            {
                Nome = "Teste",
                Preco = 99.99m
            };

            // System.Text.Json (nativo)
            string jsonNativo = System.Text.Json.JsonSerializer.Serialize(produto);
            Console.WriteLine($"System.Text.Json: {jsonNativo}");

            // Simulação do Newtonsoft.Json (se estivesse instalado)
            Console.WriteLine("Newtonsoft.Json: {\"Nome\":\"Teste\",\"Preco\":99.99}");
            Console.WriteLine("   • Newtonsoft: Mais features, mais maduro");
            Console.WriteLine("   • System.Text.Json: Mais rápido, nativo");

            // ==================================================================
            // 5. COMO ESCOLHER PACOTES
            // ==================================================================
            Console.WriteLine("\n5. COMO ESCOLHER PACOTES NUGET:");
            Console.WriteLine("   • Downloads: Popularidade da biblioteca");
            Console.WriteLine("   • Versão: Estabilidade e suporte");
            Console.WriteLine("   • Licença: Tipo de licença (MIT, Apache, etc.)");
            Console.WriteLine("   • Manutenção: Última atualização e issues abertas");
            Console.WriteLine("   • Dependências: Quantas dependências indiretas");

            // ==================================================================
            // 6. GERENCIAMENTO DE VERSÕES
            // ==================================================================
            Console.WriteLine("\n6. GERENCIAMENTO DE VERSÕES:");
            Console.WriteLine("   • Versionamento Semântico: MAJOR.MINOR.PATCH");
            Console.WriteLine("   • Versão fixa: 1.2.3");
            Console.WriteLine("   • Versão range: [1.0.0, 2.0.0)");
            Console.WriteLine("   • Wildcards: 1.2.*");

            // ==================================================================
            // 7. PACOTES ÚTEIS PARA DESENVOLVIMENTO
            // ==================================================================
            Console.WriteLine("\n7. PACOTES ÚTEIS:");
            Console.WriteLine("   • AutoMapper - Mapeamento objeto-objeto");
            Console.WriteLine("   • Dapper - Micro-ORM para bancos de dados");
            Console.WriteLine("   • FluentValidation - Validação fluente");
            Console.WriteLine("   • NUnit/xUnit - Testes unitários");
            Console.WriteLine("   • Moq - Mocking para testes");
            Console.WriteLine("   • Serilog - Logging estruturado");

            // ==================================================================
            // 8. BOAS PRÁTICAS COM NUGET
            // ==================================================================
            Console.WriteLine("\n8. BOAS PRÁTICAS:");
            Console.WriteLine("   • Use PackageReference no .csproj");
            Console.WriteLine("   • Mantenha pacotes atualizados");
            Console.WriteLine("   • Verifique vulnerabilidades");
            Console.WriteLine("   • Use versões específicas em produção");
            Console.WriteLine("   • Considere o uso de Central Package Management");

            // ==================================================================
            // 9. EXEMPLO DE .CSPROJ COM PACOTES
            // ==================================================================
            Console.WriteLine("\n9. EXEMPLO DE ARQUIVO .CSPROJ:");
            Console.WriteLine("<Project Sdk=\"Microsoft.NET.Sdk\">");
            Console.WriteLine("  <PropertyGroup>");
            Console.WriteLine("    <TargetFramework>net8.0</TargetFramework>");
            Console.WriteLine("  </PropertyGroup>");
            Console.WriteLine("  <ItemGroup>");
            Console.WriteLine("    <PackageReference Include=\"Newtonsoft.Json\" Version=\"13.0.3\" />");
            Console.WriteLine("    <PackageReference Include=\"Dapper\" Version=\"2.0.151\" />");
            Console.WriteLine("    <PackageReference Include=\"FluentValidation\" Version=\"11.8.0\" />");
            Console.WriteLine("  </ItemGroup>");
            Console.WriteLine("</Project>");

            // ==================================================================
            // 10. FERRAMENTAS ÚTEIS
            // ==================================================================
            Console.WriteLine("\n10. FERRAMENTAS ÚTEIS:");
            Console.WriteLine("   • dotnet list package --outdated");
            Console.WriteLine("   • dotnet add package");
            Console.WriteLine("   • dotnet remove package");
            Console.WriteLine("   • NuGet Package Explorer");
            Console.WriteLine("   • GitHub Dependabot");
        }
    }

    public class ProdutoSimples
    {
        public string Nome { get; set; }
        public decimal Preco { get; set; }
    }
}