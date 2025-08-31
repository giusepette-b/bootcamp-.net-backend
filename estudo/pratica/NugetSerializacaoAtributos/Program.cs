using System;
using System.Collections.Generic;
using System.Text.Json;
using NugetSerializacaoAtributos.Models;

namespace NugetSerializacaoAtributos
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== NUGET, SERIALIZAÇÃO E ATRIBUTOS EM C# ===\n");

            // 1. Serialização JSON
            Console.WriteLine("1. SERIALIZAÇÃO JSON:");
            SerializacaoJson.Demonstrar();
            Console.WriteLine();

            // 2. Atributos no C#
            Console.WriteLine("2. ATRIBUTOS NO C#:");
            AtributosCSharp.Demonstrar();
            Console.WriteLine();

            // 3. NuGet e Pacotes Externos
            Console.WriteLine("3. NUGET E PACOTES EXTERNOS:");
            NuGetPacotes.Demonstrar();
            Console.WriteLine();

            // 4. Exemplo Integrado
            Console.WriteLine("4. EXEMPLO INTEGRADO:");
            ExemploIntegrado.Demonstrar();
        }
    }
}

// Saída:
// === NUGET, SERIALIZAÇÃO E ATRIBUTOS EM C# ===

// 1. SERIALIZAÇÃO JSON:
// === SERIALIZAÇÃO JSON COM SYSTEM.TEXT.JSON ===

// 2. SERIALIZAÇÃO BÁSICA:
// JSON Básico:
// {"Id":1,"Nome":"Notebook Gamer","Preco":3549.99,"Categoria":"Eletr\u00F4nicos","DataFabricacao":"2024-01-15T00:00:00","Especificacoes":{"Processador":"Intel i7","Mem\u00F3ria":"16GB RAM","Armazenamento":"512GB SSD"}}

// JSON Formatado:
// {
//   "Id": 1,
//   "Nome": "Notebook Gamer",
//   "Preco": 3549.99,
//   "Categoria": "Eletr\u00F4nicos",
//   "DataFabricacao": "2024-01-15T00:00:00",
//   "Especificacoes": {
//     "Processador": "Intel i7",
//     "Mem\u00F3ria": "16GB RAM",
//     "Armazenamento": "512GB SSD"
//   }
// }

// 3. DESERIALIZAÇÃO BÁSICA:
// Produto desserializado: Notebook Gamer - R$ 3.549,99

// 4. OPÇÕES PERSONALIZADAS:
// JSON com CamelCase:
// {
//   "id": 1,
//   "nome": "Notebook Gamer",
//   "preco": 3549.99,
//   "categoria": "Eletr\u00F4nicos",
//   "dataFabricacao": "2024-01-15T00:00:00",
//   "especificacoes": {
//     "Processador": "Intel i7",
//     "Mem\u00F3ria": "16GB RAM",
//     "Armazenamento": "512GB SSD"
//   }
// }

// 5. SERIALIZAÇÃO DE COLEÇÕES:
// Array de produtos:
// [
//   {
//     "Id": 1,
//     "Nome": "Mouse",
//     "Preco": 89.90,
//     "Categoria": null,
//     "DataFabricacao": "0001-01-01T00:00:00",
//     "Especificacoes": null
//   },
//   {
//     "Id": 2,
//     "Nome": "Teclado",
//     "Preco": 199.50,
//     "Categoria": null,
//     "DataFabricacao": "0001-01-01T00:00:00",
//     "Especificacoes": null
//   },
//   {
//     "Id": 3,
//     "Nome": "Monitor",
//     "Preco": 899.00,
//     "Categoria": null,
//     "DataFabricacao": "0001-01-01T00:00:00",
//     "Especificacoes": null
//   }
// ]

// Produtos desserializados: 3 itens

// 6. SERIALIZAÇÃO PARA ARQUIVO:
// JSON salvo em: /home/giusepette/Documentos/bootcamp-.net-api-ai/estudo/pratica/NugetSerializacaoAtributos/produto.json
// Produto do arquivo: Notebook Gamer

// 7. SERIALIZAÇÃO COM ATRIBUTOS:
// JSON com atributos personalizados:
// {
//   "codigo": 100,
//   "nomeProduto": "Smartphone",
//   "Preco": "1999,99"
// }

// 8. MANIPULAÇÃO DE DATAS:
// JSON com data customizada:
// {
//   "id": 0,
//   "nome": "Produto com Data",
//   "preco": 100.00,
//   "categoria": null,
//   "dataFabricacao": "2025-08-31 14:14:06",
//   "especificacoes": null
// }

// 2. ATRIBUTOS NO C#:
// === ATRIBUTOS NO C# ===

// 1. CONCEITO DE ATRIBUTOS:
//    • Metadados adicionados ao código
//    • Fornecem informações adicionais
//    • Usados por compiladores, frameworks e ferramentas
//    • Colocados entre colchetes: [Atributo]

// 2. ATRIBUTOS DE SERIALIZAÇÃO JSON:
// Serialização com atributos:
// {
//   "codigo": 1,
//   "nomeProduto": "Tablet",
//   "Preco": "1299,99"
// }
//    • [JsonPropertyName] → Customiza nome no JSON
//    • [JsonIgnore] → Ignora propriedade na serialização
//    • [JsonConverter] → Usa converter customizado

// 3. ATRIBUTOS DE VALIDAÇÃO:
// Usuário válido: False
//    Erro: Nome deve ter entre 3 e 50 caracteres
//    Erro: Email deve ser válido
//    Erro: Idade deve ser entre 18 e 120 anos
//    • [Required] → Campo obrigatório
//    • [StringLength] → Tamanho máximo/minimo
//    • [Range] → Valor entre mínimo e máximo
//    • [EmailAddress] → Formato de email válido

// 4. ATRIBUTOS DE OBSOLESCÊNCIA:
//    Método antigo executado (obsoleto)
//    • [Obsolete] → Marca métodos/propriedades como obsoletos
//    • Pode incluir mensagem e erro em vez de warning

// 5. ATRIBUTOS PERSONALIZADOS:
// Status do pedido: Processando
// Descrição: Pedido em processamento
//    • Criar classes que herdam de Attribute
//    • Usar Reflection para acessar os valores

// 6. ATRIBUTOS DE SEGURANÇA:
// Operação privada executada
//    • [Authorize] → Controla acesso em APIs
//    • [RequiredRole] → Exige roles específicas
//    • Atributos customizados para segurança

// 7. ATRIBUTOS DE DOCUMENTAÇÃO:
// Resultado: 8
//    • <summary> → Documentação de métodos/propriedades
//    • <param> → Documentação de parâmetros
//    • <returns> → Documentação de retorno
//    • Gera documentação XML automaticamente

// 8. ATRIBUTOS DE COMPILAÇÃO:
//    • [Conditional] → Inclui/remove métodos na compilação
//    • [DebuggerStepThrough] → Pula debug no método
//    • [AssemblyVersion] → Versão do assembly
//    • [InternalsVisibleTo] → Compartilha internos com outros assemblies

// 3. NUGET E PACOTES EXTERNOS:
// === NUGET E PACOTES EXTERNOS ===

// 1. CONCEITO DO NUGET:
//    • Gerenciador de pacotes para .NET
//    • Biblioteca de pacotes open-source
//    • Facilita inclusão de dependências
//    • Integrado com Visual Studio e dotnet CLI

// 2. INSTALAÇÃO DE PACOTES:
//    • Visual Studio: PM> Install-Package NomePacote
//    • dotnet CLI: dotnet add package NomePacote
//    • Editando .csproj: <PackageReference Include="NomePacote" Version="1.0.0" />

// 3. PACOTES POPULARES PARA SERIALIZAÇÃO:
//    • Newtonsoft.Json (Json.NET) - Alternativa ao System.Text.Json
//    • System.Text.Json - Nativo do .NET (recomendado)
//    • MessagePack - Serialização binária eficiente
//    • Protobuf-net - Protocol Buffers para .NET

// 4. NEWTONSOFT.JSON VS SYSTEM.TEXT.JSON:
// System.Text.Json: {"Nome":"Teste","Preco":99.99}
// Newtonsoft.Json: {"Nome":"Teste","Preco":99.99}
//    • Newtonsoft: Mais features, mais maduro
//    • System.Text.Json: Mais rápido, nativo

// 5. COMO ESCOLHER PACOTES NUGET:
//    • Downloads: Popularidade da biblioteca
//    • Versão: Estabilidade e suporte
//    • Licença: Tipo de licença (MIT, Apache, etc.)
//    • Manutenção: Última atualização e issues abertas
//    • Dependências: Quantas dependências indiretas

// 6. GERENCIAMENTO DE VERSÕES:
//    • Versionamento Semântico: MAJOR.MINOR.PATCH
//    • Versão fixa: 1.2.3
//    • Versão range: [1.0.0, 2.0.0)
//    • Wildcards: 1.2.*

// 7. PACOTES ÚTEIS:
//    • AutoMapper - Mapeamento objeto-objeto
//    • Dapper - Micro-ORM para bancos de dados
//    • FluentValidation - Validação fluente
//    • NUnit/xUnit - Testes unitários
//    • Moq - Mocking para testes
//    • Serilog - Logging estruturado

// 8. BOAS PRÁTICAS:
//    • Use PackageReference no .csproj
//    • Mantenha pacotes atualizados
//    • Verifique vulnerabilidades
//    • Use versões específicas em produção
//    • Considere o uso de Central Package Management

// 9. EXEMPLO DE ARQUIVO .CSPROJ:
// <Project Sdk="Microsoft.NET.Sdk">
//   <PropertyGroup>
//     <TargetFramework>net8.0</TargetFramework>
//   </PropertyGroup>
//   <ItemGroup>
//     <PackageReference Include="Newtonsoft.Json" Version="13.0.3" />
//     <PackageReference Include="Dapper" Version="2.0.151" />
//     <PackageReference Include="FluentValidation" Version="11.8.0" />
//   </ItemGroup>
// </Project>

// 10. FERRAMENTAS ÚTEIS:
//    • dotnet list package --outdated
//    • dotnet add package
//    • dotnet remove package
//    • NuGet Package Explorer
//    • GitHub Dependabot

// 4. EXEMPLO INTEGRADO:
// === EXEMPLO INTEGRADO: NUGET + SERIALIZAÇÃO + ATRIBUTOS ===

// 1. CRIAÇÃO COM VALIDAÇÃO:
// 2. VALIDAÇÃO AUTOMÁTICA:
// Pedido válido: True

// 3. SERIALIZAÇÃO JSON:
// JSON do pedido:
// {
//   "id": 1001,
//   "cliente": {
//     "nome": "Jo\u00E3o Silva",
//     "email": "joao@email.com",
//     "endereco": "Rua das Flores, 123"
//   },
//   "itens": [
//     {
//       "produtoId": 1,
//       "nome": "Mouse",
//       "preco": 89.90,
//       "quantidade": 2
//     },
//     {
//       "produtoId": 2,
//       "nome": "Teclado",
//       "preco": 199.50,
//       "quantidade": 1
//     }
//   ],
//   "status": 1,
//   "dataCriacao": "2025-08-31T14:14:06.1669154-03:00"
// }

// 4. DESSERIALIZAÇÃO:
// Pedido desserializado: #0
// Unhandled exception. System.NullReferenceException: Object reference not set to an instance of an object.
//    at NugetSerializacaoAtributos.Models.ExemploIntegrado.Demonstrar() in /home/giusepette/Documentos/bootcamp-.net-api-ai/estudo/pratica/NugetSerializacaoAtributos/Models/ExemploIntegrado.cs:line 80
//    at NugetSerializacaoAtributos.Program.Main(String[] args) in /home/giusepette/Documentos/bootcamp-.net-api-ai/estudo/pratica/NugetSerializacaoAtributos/Program.cs:line 31