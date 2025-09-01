using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EncapsulamentoAbstracao.Models


{
    public static class ExemploIntegrado
    {
        public static void Demonstrar()
        {
            Console.WriteLine("=== EXEMPLO INTEGRADO: SISTEMA BANCÁRIO ===\n");

            // ==================================================================
            // 1. ABSTRAÇÃO: CONTA BANCÁRIA (CLASSE ABSTRATA)
            // ==================================================================
            Console.WriteLine("1. SISTEMA BANCÁRIO COM ABSTRAÇÃO:");

            List<Conta> contas = new List<Conta>
            {
                new ContaCorrente("12345-6", 1000.00m, 500.00m),
                new ContaPoupanca("78901-2", 2000.00m, 0.05m),
                new ContaSalario("34567-8", 500.00m, "Empresa XYZ")
            };

            // ==================================================================
            // 2. ENCAPSULAMENTO: DADOS PROTEGIDOS
            // ==================================================================
            foreach (var conta in contas)
            {
                Console.WriteLine($"\n--- {conta.GetType().Name} ---");
                Console.WriteLine($"Saldo inicial: {conta.Saldo:C}");

                // ✅ Operações permitidas pela interface pública
                conta.Depositar(300.00m);
                Console.WriteLine($"Após depósito: {conta.Saldo:C}");

                try
                {
                    conta.Sacar(200.00m);
                    Console.WriteLine($"Após saque: {conta.Saldo:C}");
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine($"Erro no saque: {ex.Message}");
                }

                // ✅ Método abstrato implementado diferentemente em cada classe
                conta.AplicarTaxas();
                Console.WriteLine($"Após taxas: {conta.Saldo:C}");

                // ❌ Dados internos protegidos
                // Console.WriteLine(conta._saldo); // Erro!
            }

            // ==================================================================
            // 3. POLIMORFISMO: MESMA INTERFACE, COMPORTAMENTOS DIFERENTES
            // ==================================================================
            Console.WriteLine("\n2. POLIMORFISMO:");

            foreach (var conta in contas)
            {
                Console.WriteLine($"{conta.GetType().Name}:");
                Console.WriteLine($"  Tipo: {conta.TipoConta}");
                Console.WriteLine($"  Saldo: {conta.Saldo:C}");

                // Cada conta tem regras diferentes de saque
                try
                {
                    conta.Sacar(800.00m);
                    Console.WriteLine("  Saque realizado com sucesso");
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine($"  Erro: {ex.Message}");
                }
            }
        }
    }

    // ==================================================================
    // CLASSE ABSTRATA PARA CONTA BANCÁRIA
    // ==================================================================
    public abstract class Conta
    {
        // Campos protegidos - encapsulamento
        protected decimal _saldo;

        // Propriedades públicas com acesso controlado
        public string NumeroConta { get; }
        public decimal Saldo => _saldo; // Somente leitura
        public abstract string TipoConta { get; }

        protected Conta(string numeroConta, decimal saldoInicial = 0)
        {
            NumeroConta = numeroConta;
            _saldo = saldoInicial;
        }

        // Métodos públicos - interface uniforme
        public virtual void Depositar(decimal valor)
        {
            ValidarValorPositivo(valor);
            _saldo += valor;
            Console.WriteLine($"Depositado: {valor:C}");
        }

        public virtual void Sacar(decimal valor)
        {
            ValidarValorPositivo(valor);

            if (_saldo < valor)
                throw new InvalidOperationException("Saldo insuficiente");

            _saldo -= valor;
            Console.WriteLine($"Sacado: {valor:C}");
        }

        // Método abstrato - cada conta implementa diferente
        public abstract void AplicarTaxas();

        // Método protegido - encapsula validação interna
        protected void ValidarValorPositivo(decimal valor)
        {
            if (valor <= 0)
                throw new ArgumentException("Valor deve ser positivo");
        }
    }

    // ==================================================================
    // CONTA CORRENTE - IMPLEMENTAÇÃO CONCRETA
    // ==================================================================
    public class ContaCorrente : Conta
    {
        private decimal _limiteChequeEspecial;

        public override string TipoConta => "Conta Corrente";

        public ContaCorrente(string numeroConta, decimal saldoInicial, decimal limiteChequeEspecial)
            : base(numeroConta, saldoInicial)
        {
            _limiteChequeEspecial = limiteChequeEspecial;
        }

        public override void Sacar(decimal valor)
        {
            ValidarValorPositivo(valor);

            // ✅ Encapsulamento: regra específica da conta corrente
            if (_saldo + _limiteChequeEspecial < valor)
                throw new InvalidOperationException(
                    $"Saldo+limite insuficiente. Limite: {_limiteChequeEspecial:C}");

            _saldo -= valor;
            Console.WriteLine($"Sacado: {valor:C} (usando cheque especial: {_saldo < 0})");
        }

        public override void AplicarTaxas()
        {
            // ✅ Abstração: implementação específica
            if (_saldo < 0)
            {
                decimal taxa = Math.Abs(_saldo) * 0.1m; // 10% sobre o negativo
                _saldo -= taxa;
                Console.WriteLine($"Taxa cheque especial: -{taxa:C}");
            }
        }
    }

    // ==================================================================
    // CONTA POUPANÇA - IMPLEMENTAÇÃO CONCRETA
    // ==================================================================
    public class ContaPoupanca : Conta
    {
        private decimal _taxaRendimento;

        public override string TipoConta => "Conta Poupança";

        public ContaPoupanca(string numeroConta, decimal saldoInicial, decimal taxaRendimento)
            : base(numeroConta, saldoInicial)
        {
            _taxaRendimento = taxaRendimento;
        }

        public override void Sacar(decimal valor)
        {
            ValidarValorPositivo(valor);

            // ✅ Encapsulamento: regra específica da poupança
            if (_saldo < valor)
                throw new InvalidOperationException("Saldo insuficiente na poupança");

            _saldo -= valor;
            Console.WriteLine($"Sacado: {valor:C}");
        }

        public override void AplicarTaxas()
        {
            // ✅ Abstração: implementação específica
            decimal rendimento = _saldo * _taxaRendimento;
            _saldo += rendimento;
            Console.WriteLine($"Rendimento: +{rendimento:C}");
        }
    }

    // ==================================================================
    // CONTA SALÁRIO - IMPLEMENTAÇÃO CONCRETA
    // ==================================================================
    public class ContaSalario : Conta
    {
        private string _empresa;
        private int _saquesRestantes;

        public override string TipoConta => "Conta Salário";

        public ContaSalario(string numeroConta, decimal saldoInicial, string empresa)
            : base(numeroConta, saldoInicial)
        {
            _empresa = empresa;
            _saquesRestantes = 2; // Limite de saques
        }

        public override void Sacar(decimal valor)
        {
            ValidarValorPositivo(valor);

            // ✅ Encapsulamento: regras específicas da conta salário
            if (_saquesRestantes <= 0)
                throw new InvalidOperationException("Limite de saques excedido");

            if (_saldo < valor)
                throw new InvalidOperationException("Saldo insuficiente");

            _saldo -= valor;
            _saquesRestantes--;
            Console.WriteLine($"Sacado: {valor:C} ({_saquesRestantes} saques restantes)");
        }

        public override void AplicarTaxas()
        {
            // ✅ Abstração: conta salário não tem taxas nem rendimentos
            Console.WriteLine("Conta salário: sem taxas ou rendimentos");
        }

        // Método específico da conta salário
        public void ReceberSalario(decimal valor)
        {
            ValidarValorPositivo(valor);
            _saldo += valor;
            _saquesRestantes = 2; // Reset dos saques
            Console.WriteLine($"Salário recebido: {valor:C}");
        }
    }
}