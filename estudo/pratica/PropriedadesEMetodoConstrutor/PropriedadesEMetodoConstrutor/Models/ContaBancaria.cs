using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PropriedadesEMetodoConstrutor.Model
{
    public class ContaBancaria
    {
        // Propriedade somente leitura (apenas get)
        public string NumeroConta { get; }

        private decimal _saldo;
        public decimal Saldo
        {
            get { return saldo; }
            private set
            {
                if (value < 0)
                    throw new InvalidOperationException("Saldo não pode ser negativo");
                _saldo = value;
            }
        }

        // Construtor
        public ContaBancaria(string numeroConta, decimal saldoInicial = 0)
        {
            if (string.IsNullOrWhiteSpace(numeroConta))
                throw new ArgumentException("Número da conta não pode ser vazio");

            NumeroConta = numeroConta;
            Saldo = saldoInicial;
        }

        // Métodos para manipular o saldo
        public void Depositar(decimal valor)
        {
            if (valor <= 0)
                throw new ArgumentException("Valor do depósito deve ser positivo");

            Saldo += valor;
        }

        public void Sacar(decimal valor)
        {
            if (valor <= 0)
                throw new ArgumentException("Valor do saque deve ser positivo");

            if (Saldo - valor < 0)
                throw new InvalidOperationException("Saldo insuficiente");

            Saldo -= valor;
        }
    }
}