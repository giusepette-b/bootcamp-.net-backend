using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace NugetSerializacaoAtributos.Models
{
    public static class AtributosCSharp
    {
        public static void Demonstrar()
        {
            Console.WriteLine("=== ATRIBUTOS NO C# ===\n");

            // ==================================================================
            // 1. O QUE SÃO ATRIBUTOS?
            // ==================================================================
            Console.WriteLine("1. CONCEITO DE ATRIBUTOS:");
            Console.WriteLine("   • Metadados adicionados ao código");
            Console.WriteLine("   • Fornecem informações adicionais");
            Console.WriteLine("   • Usados por compiladores, frameworks e ferramentas");
            Console.WriteLine("   • Colocados entre colchetes: [Atributo]");

            // ==================================================================
            // 2. ATRIBUTOS DE SERIALIZAÇÃO (JSON)
            // ==================================================================
            Console.WriteLine("\n2. ATRIBUTOS DE SERIALIZAÇÃO JSON:");

            var produto = new ProdutoComAtributos
            {
                Id = 1,
                Nome = "Tablet",
                Preco = 1299.99m,
                IgnorarEsteCampo = "Será ignorado"
            };

            string json = System.Text.Json.JsonSerializer.Serialize(produto,
                new System.Text.Json.JsonSerializerOptions { WriteIndented = true });

            Console.WriteLine("Serialização com atributos:");
            Console.WriteLine(json);
            Console.WriteLine("   • [JsonPropertyName] → Customiza nome no JSON");
            Console.WriteLine("   • [JsonIgnore] → Ignora propriedade na serialização");
            Console.WriteLine("   • [JsonConverter] → Usa converter customizado");

            // ==================================================================
            // 3. ATRIBUTOS DE VALIDAÇÃO (DATA ANNOTATIONS)
            // ==================================================================
            Console.WriteLine("\n3. ATRIBUTOS DE VALIDAÇÃO:");

            var usuario = new Usuario
            {
                Nome = "Jo", // Muito curto - vai falhar na validação
                Email = "email-invalido", // Email inválido
                Idade = 15 // Menor de idade
            };

            var resultadosValidacao = new List<ValidationResult>();
            bool valido = Validator.TryValidateObject(usuario,
                new ValidationContext(usuario), resultadosValidacao, true);

            Console.WriteLine($"Usuário válido: {valido}");
            foreach (var erro in resultadosValidacao)
            {
                Console.WriteLine($"   Erro: {erro.ErrorMessage}");
            }

            Console.WriteLine("   • [Required] → Campo obrigatório");
            Console.WriteLine("   • [StringLength] → Tamanho máximo/minimo");
            Console.WriteLine("   • [Range] → Valor entre mínimo e máximo");
            Console.WriteLine("   • [EmailAddress] → Formato de email válido");

            // ==================================================================
            // 4. ATRIBUTOS DE DEPRECATION (OBSOLETOS)
            // ==================================================================
            Console.WriteLine("\n4. ATRIBUTOS DE OBSOLESCÊNCIA:");

            // Este método está obsoleto e mostrará warning
#pragma warning disable CS0618
            MetodoAntigo();
#pragma warning restore CS0618

            Console.WriteLine("   • [Obsolete] → Marca métodos/propriedades como obsoletos");
            Console.WriteLine("   • Pode incluir mensagem e erro em vez de warning");

            // ==================================================================
            // 5. ATRIBUTOS PERSONALIZADOS
            // ==================================================================
            Console.WriteLine("\n5. ATRIBUTOS PERSONALIZADOS:");

            var pedido = new Pedido
            {
                Id = 1001,
                Status = StatusPedido.Processando,
                DataCriacao = DateTime.Now
            };

            // Usando atributo personalizado
            var atributo = (DescricaoAttribute)Attribute.GetCustomAttribute(
                typeof(StatusPedido).GetField(pedido.Status.ToString()),
                typeof(DescricaoAttribute));

            Console.WriteLine($"Status do pedido: {pedido.Status}");
            Console.WriteLine($"Descrição: {atributo?.Descricao}");
            Console.WriteLine("   • Criar classes que herdam de Attribute");
            Console.WriteLine("   • Usar Reflection para acessar os valores");

            // ==================================================================
            // 6. ATRIBUTOS DE SEGURANÇA
            // ==================================================================
            Console.WriteLine("\n6. ATRIBUTOS DE SEGURANÇA:");

            try
            {
                var service = new ServicoSensivel();
                service.OperacaoPrivada(); // Vai lançar exceção
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro de segurança: {ex.Message}");
            }

            Console.WriteLine("   • [Authorize] → Controla acesso em APIs");
            Console.WriteLine("   • [RequiredRole] → Exige roles específicas");
            Console.WriteLine("   • Atributos customizados para segurança");

            // ==================================================================
            // 7. ATRIBUTOS DE DOCUMENTAÇÃO (XML COMMENTS)
            // ==================================================================
            Console.WriteLine("\n7. ATRIBUTOS DE DOCUMENTAÇÃO:");

            var calculadora = new Calculadora();
            var resultado = calculadora.Somar(5, 3);
            Console.WriteLine($"Resultado: {resultado}");

            Console.WriteLine("   • <summary> → Documentação de métodos/propriedades");
            Console.WriteLine("   • <param> → Documentação de parâmetros");
            Console.WriteLine("   • <returns> → Documentação de retorno");
            Console.WriteLine("   • Gera documentação XML automaticamente");

            // ==================================================================
            // 8. ATRIBUTOS DE COMPILAÇÃO
            // ==================================================================
            Console.WriteLine("\n8. ATRIBUTOS DE COMPILAÇÃO:");

            Console.WriteLine("   • [Conditional] → Inclui/remove métodos na compilação");
            Console.WriteLine("   • [DebuggerStepThrough] → Pula debug no método");
            Console.WriteLine("   • [AssemblyVersion] → Versão do assembly");
            Console.WriteLine("   • [InternalsVisibleTo] → Compartilha internos com outros assemblies");
        }

        // ==================================================================
        // MÉTODO OBSOLETO - EXEMPLO DE [OBSOLETE]
        // ==================================================================
        [Obsolete("Use o novo método Processar() em vez deste.", false)]
        public static void MetodoAntigo()
        {
            Console.WriteLine("   Método antigo executado (obsoleto)");
        }
    }

    // ==================================================================
    // CLASSE COM ATRIBUTOS DE VALIDAÇÃO
    // ==================================================================
    public class Usuario
    {
        [Required(ErrorMessage = "Nome é obrigatório")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Nome deve ter entre 3 e 50 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Email é obrigatório")]
        [EmailAddress(ErrorMessage = "Email deve ser válido")]
        public string Email { get; set; }

        [Range(18, 120, ErrorMessage = "Idade deve ser entre 18 e 120 anos")]
        public int Idade { get; set; }
    }

    // ==================================================================
    // ENUM COM ATRIBUTO PERSONALIZADO
    // ==================================================================
    public enum StatusPedido
    {
        [Descricao("Pedido recebido e aguardando processamento")]
        Pendente,

        [Descricao("Pedido em processamento")]
        Processando,

        [Descricao("Pedido enviado para entrega")]
        Enviado,

        [Descricao("Pedido entregue com sucesso")]
        Entregue,

        [Descricao("Pedido cancelado pelo cliente")]
        Cancelado
    }

    // ==================================================================
    // ATRIBUTO PERSONALIZADO
    // ==================================================================
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class DescricaoAttribute : Attribute
    {
        public string Descricao { get; }

        public DescricaoAttribute(string descricao)
        {
            Descricao = descricao;
        }
    }

    // ==================================================================
    // CLASSE COM ATRIBUTOS DE SEGURANÇA
    // ==================================================================
    public class ServicoSensivel
    {
        [RequiredPermission("Admin")]
        public void OperacaoPrivada()
        {
            Console.WriteLine("Operação privada executada");
        }
    }

    // ==================================================================
    // ATRIBUTO PERSONALIZADO DE SEGURANÇA
    // ==================================================================
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class RequiredPermissionAttribute : Attribute
    {
        public string Permissao { get; }

        public RequiredPermissionAttribute(string permissao)
        {
            Permissao = permissao;
        }
    }

    // ==================================================================
    // CLASSE COM DOCUMENTAÇÃO XML
    // ==================================================================
    public class Calculadora
    {
        /// <summary>
        /// Soma dois números inteiros
        /// </summary>
        /// <param name="a">Primeiro número</param>
        /// <param name="b">Segundo número</param>
        /// <returns>Resultado da soma</returns>
        public int Somar(int a, int b)
        {
            return a + b;
        }
    }

    public class Pedido
    {
        public int Id { get; set; }
        public StatusPedido Status { get; set; }
        public DateTime DataCriacao { get; set; }
    }
}