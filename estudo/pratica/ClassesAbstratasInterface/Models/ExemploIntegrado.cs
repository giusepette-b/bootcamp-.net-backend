using System;
using System.Collections.Generic;

namespace ClassesAbstratasInterfaces.Models
{
    public static class ExemploIntegrado
    {
        public static void Demonstrar()
        {
            Console.WriteLine("=== EXEMPLO INTEGRADO: SISTEMA DE PAGAMENTOS ===\n");

            // ==================================================================
            // 1. CLASSE ABSTRATA PARA PAGAMENTOS
            // ==================================================================
            Console.WriteLine("1. SISTEMA DE PAGAMENTOS COM CLASSE ABSTRATA:");

            List<Pagamento> pagamentos = new List<Pagamento>
            {
                new PagamentoCartao(100.00m, "1234-5678-9012-3456", "João Silva"),
                new PagamentoPix(200.00m, "joao.silva@email.com"),
                new PagamentoBoleto(300.00m, "23793.12345 60000.123456 78900.123456 1 12345678901234"),
                new PagamentoCartao(150.00m, "9876-5432-1098-7654", "Maria Santos")
            };

            // ==================================================================
            // 2. POLIMORFISMO COM CLASSE ABSTRATA
            // ==================================================================
            Console.WriteLine("2. PROCESSAMENTO POLIMÓRFICO:");

            foreach (var pagamento in pagamentos)
            {
                // ✅ Método abstrato - cada classe implementa diferente
                pagamento.ProcessarPagamento();

                // ✅ Método virtual - implementação padrão, pode ser sobrescrito
                string status = pagamento.VerificarStatus();
                Console.WriteLine($"Status: {status}");

                // ✅ Método concreto - implementação na classe abstrata
                pagamento.GerarComprovante();

                Console.WriteLine();
            }

            // ==================================================================
            // 3. INTERFACES PARA COMPORTAMENTOS ADICIONAIS
            // ==================================================================
            Console.WriteLine("3. INTERFACES PARA COMPORTAMENTOS ADICIONAIS:");

            foreach (var pagamento in pagamentos)
            {
                // ✅ Verificação se implementa interface específica
                if (pagamento is IReembolsavel reembolsavel)
                {
                    Console.WriteLine($"Pagamento reembolsável: {reembolsavel.CalcularValorReembolso():C}");
                }

                if (pagamento is IRastreavel rastreavel)
                {
                    Console.WriteLine($"Código de rastreio: {rastreavel.ObterCodigoRastreio()}");
                }

                Console.WriteLine();
            }

            // ==================================================================
            // 4. MÉTODOS ESTÁTICOS DA CLASSE ABSTRATA
            // ==================================================================
            Console.WriteLine("4. MÉTODOS ESTÁTICOS:");

            decimal total = Pagamento.CalcularTotal(pagamentos);
            Console.WriteLine($"Total processado: {total:C}");

            // ==================================================================
            // 5. EXCEÇÕES E VALIDAÇÕES
            // ==================================================================
            Console.WriteLine("\n5. TRATAMENTO DE ERROS:");

            try
            {
                var pagamentoInvalido = new PagamentoCartao(-100.00m, "1234-5678-9012-3456", "João");
                pagamentoInvalido.ProcessarPagamento();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"❌ Erro de validação: {ex.Message}");
            }

            // ==================================================================
            // 6. VANTAGENS DO USO COMBINADO
            // ==================================================================
            Console.WriteLine("\n6. VANTAGENS DO USO COMBINADO:");
            Console.WriteLine("   ✅ Classe Abstrata: Fornece implementação base comum");
            Console.WriteLine("   ✅ Interfaces: Adicionam comportamentos específicos");
            Console.WriteLine("   ✅ Polimorfismo: Mesma interface, implementações diferentes");
            Console.WriteLine("   ✅ Flexibilidade: Fácil adicionar novos tipos de pagamento");
            Console.WriteLine("   ✅ Manutenibilidade: Código organizado e extensível");
        }
    }

    // ==================================================================
    // CLASSE ABSTRATA BASE - PAGAMENTO
    // ==================================================================
    public abstract class Pagamento
    {
        public decimal Valor { get; protected set; }
        public DateTime Data { get; protected set; }
        public string Status { get; protected set; }
        public string IdTransacao { get; protected set; }

        protected Pagamento(decimal valor)
        {
            if (valor <= 0)
                throw new ArgumentException("Valor do pagamento deve ser positivo");

            Valor = valor;
            Data = DateTime.Now;
            Status = "Pendente";
            IdTransacao = Guid.NewGuid().ToString().Substring(0, 8).ToUpper();
        }

        // MÉTODO ABSTRATO - deve ser implementado pelas classes derivadas
        public abstract void ProcessarPagamento();

        // MÉTODO VIRTUAL - implementação padrão, pode ser sobrescrito
        public virtual string VerificarStatus()
        {
            return $"Status: {Status} | ID: {IdTransacao}";
        }

        // MÉTODO CONCRETO - implementação completa na classe base
        public void GerarComprovante()
        {
            Console.WriteLine("=== COMPROVANTE ===");
            Console.WriteLine($"Data: {Data:dd/MM/yyyy HH:mm:ss}");
            Console.WriteLine($"Valor: {Valor:C}");
            Console.WriteLine($"ID: {IdTransacao}");
            Console.WriteLine($"Status: {Status}");
            Console.WriteLine($"Tipo: {GetType().Name}");
        }

        // MÉTODO ESTÁTICO - utilitário da classe
        public static decimal CalcularTotal(List<Pagamento> pagamentos)
        {
            decimal total = 0;
            foreach (var pagamento in pagamentos)
            {
                total += pagamento.Valor;
            }
            return total;
        }

        // PROPRIEDADE VIRTUAL - pode ser sobrescrita
        public virtual decimal TaxaProcessamento => Valor * 0.02m; // 2% padrão
    }

    // ==================================================================
    // INTERFACES PARA COMPORTAMENTOS ESPECÍFICOS
    // ==================================================================
    public interface IReembolsavel
    {
        decimal CalcularValorReembolso();
        void SolicitarReembolso();
    }

    public interface IRastreavel
    {
        string ObterCodigoRastreio();
        void AtualizarStatusRastreio(string status);
    }

    public interface ISeguro
    {
        void AplicarSeguro();
        decimal CalcularValorSeguro();
    }

    // ==================================================================
    // CLASSE CONCRETA - PAGAMENTO COM CARTÃO
    // ==================================================================
    public class PagamentoCartao : Pagamento, IReembolsavel
    {
        public string NumeroCartao { get; }
        public string NomeTitular { get; }

        public PagamentoCartao(decimal valor, string numeroCartao, string nomeTitular)
            : base(valor)
        {
            if (string.IsNullOrEmpty(numeroCartao) || numeroCartao.Length < 16)
                throw new ArgumentException("Número do cartão inválido");

            if (string.IsNullOrEmpty(nomeTitular))
                throw new ArgumentException("Nome do titular é obrigatório");

            NumeroCartao = numeroCartao;
            NomeTitular = nomeTitular;
        }

        // Implementação do método abstrato
        public override void ProcessarPagamento()
        {
            Console.WriteLine($"💳 Processando pagamento com cartão: {NumeroCartao.Substring(0, 4)}****");
            Console.WriteLine($"Titular: {NomeTitular}");
            Console.WriteLine($"Valor: {Valor:C}");

            // Simulação de processamento
            Status = "Aprovado";
            Console.WriteLine("✅ Pagamento aprovado com sucesso!");
        }

        // Sobrescrita de propriedade virtual
        public override decimal TaxaProcessamento => Valor * 0.03m; // 3% para cartão

        // Implementação da interface IReembolsavel
        public decimal CalcularValorReembolso()
        {
            return Valor * 0.95m; // 95% do valor para reembolso
        }

        public void SolicitarReembolso()
        {
            Console.WriteLine($"🔄 Solicitação de reembolso: {CalcularValorReembolso():C}");
            Status = "Reembolso Solicitado";
        }
    }

    // ==================================================================
    // CLASSE CONCRETA - PAGAMENTO PIX
    // ==================================================================
    public class PagamentoPix : Pagamento, IRastreavel
    {
        public string ChavePix { get; }

        public PagamentoPix(decimal valor, string chavePix) : base(valor)
        {
            if (string.IsNullOrEmpty(chavePix))
                throw new ArgumentException("Chave PIX é obrigatória");

            ChavePix = chavePix;
        }

        public override void ProcessarPagamento()
        {
            Console.WriteLine($"📱 Processando PIX: {ChavePix}");
            Console.WriteLine($"Valor: {Valor:C}");

            // Simulação de processamento instantâneo
            Status = "Concluído";
            Console.WriteLine("✅ PIX processado instantaneamente!");
        }

        // Implementação da interface IRastreavel
        public string ObterCodigoRastreio()
        {
            return $"PIX-{IdTransacao}";
        }

        public void AtualizarStatusRastreio(string status)
        {
            Status = status;
            Console.WriteLine($"Status do PIX atualizado: {status}");
        }
    }

    // ==================================================================
    // CLASSE CONCRETA - PAGAMENTO BOLETO
    // ==================================================================
    public class PagamentoBoleto : Pagamento, IReembolsavel, IRastreavel
    {
        public string CodigoBarras { get; }
        public DateTime DataVencimento { get; }

        public PagamentoBoleto(decimal valor, string codigoBarras) : base(valor)
        {
            if (string.IsNullOrEmpty(codigoBarras) || codigoBarras.Length < 44)
                throw new ArgumentException("Código de barras inválido");

            CodigoBarras = codigoBarras;
            DataVencimento = DateTime.Now.AddDays(3);
        }

        public override void ProcessarPagamento()
        {
            Console.WriteLine($"📄 Gerando boleto: {CodigoBarras}");
            Console.WriteLine($"Valor: {Valor:C}");
            Console.WriteLine($"Vencimento: {DataVencimento:dd/MM/yyyy}");

            Status = "Aguardando Pagamento";
            Console.WriteLine("📋 Boleto gerado - Aguardando pagamento");
        }

        // Sobrescrita do método virtual
        public override string VerificarStatus()
        {
            return $"Boleto {Status} - Vencimento: {DataVencimento:dd/MM/yyyy}";
        }

        // Implementação da interface IReembolsavel
        public decimal CalcularValorReembolso()
        {
            return Valor * 0.90m; // 90% do valor para reembolso de boleto
        }

        public void SolicitarReembolso()
        {
            Console.WriteLine($"🔄 Solicitação de reembolso de boleto: {CalcularValorReembolso():C}");
            Status = "Reembolso Solicitado";
        }

        // Implementação da interface IRastreavel
        public string ObterCodigoRastreio()
        {
            return $"BOL-{IdTransacao}";
        }

        public void AtualizarStatusRastreio(string status)
        {
            Status = status;
            Console.WriteLine($"Status do boleto atualizado: {status}");
        }
    }
}