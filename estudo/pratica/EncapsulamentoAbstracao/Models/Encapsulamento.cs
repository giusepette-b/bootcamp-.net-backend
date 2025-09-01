using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EncapsulamentoAbstracao.Models
{
    public static class Encapsulamento
    {
        public static void Demonstrar()
        {
            Console.WriteLine("=== ENCAPSULAMENTO: PROTEGER DADOS INTERNOS ===\n");

            // ==================================================================
            // 1. ENCAPSULAMENTO BÁSICO - GET/SET
            // ==================================================================
            Console.WriteLine("1. ENCAPSULAMENTO COM GET/SET:");

            var conta = new ContaBancaria("12345-6", 1000.00m);
            Console.WriteLine($"Saldo inicial: {conta.Saldo:C}");

            // ✅ Acesso permitido via propriedade pública
            conta.Depositar(500.00m);
            Console.WriteLine($"Após depósito: {conta.Saldo:C}");

            conta.Sacar(200.00m);
            Console.WriteLine($"Após saque: {conta.Saldo:C}");

            // ❌ Acesso direto ao saldo não é permitido (private set)
            // conta.Saldo = 1000000; // Erro de compilação!

            // ==================================================================
            // 2. ENCAPSULAMENTO COM VALIDAÇÃO
            // ==================================================================
            Console.WriteLine("\n2. ENCAPSULAMENTO COM VALIDAÇÃO:");

            var usuario = new Usuario();
            try
            {
                usuario.Idade = 15; // ❌ Vai lançar exceção
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }

            usuario.Idade = 25; // ✅ Válido
            Console.WriteLine($"Idade válida: {usuario.Idade}");

            // ==================================================================
            // 3. ENCAPSULAMENTO COM CAMPOS PRIVADOS
            // ==================================================================
            Console.WriteLine("\n3. CAMPOS PRIVADOS E MÉTODOS PÚBLICOS:");

            var carro = new Carro("Toyota", "Corolla", 2022);
            carro.Ligar();
            carro.Acelerar(50);
            carro.Freiar(20);
            carro.ExibirInfo();

            // ❌ Campos internos não são acessíveis
            // Console.WriteLine(carro._motorLigado); // Erro!
            // Console.WriteLine(carro._velocidadeAtual); // Erro!

            // ==================================================================
            // 4. ENCAPSULAMENTO COM PROPRIEDADES
            // ==================================================================
            Console.WriteLine("\n4. TIPOS DE PROPRIEDADES:");

            var produto = new Produto("Notebook", 2500.00m);

            // Propriedade com get público, set privado
            Console.WriteLine($"Nome: {produto.Nome}");
            // produto.Nome = "Novo Nome"; // ❌ Erro - set é privado

            // Propriedade com lógica personalizada
            produto.Preco = 3000.00m; // ✅ Aplica desconto automático
            Console.WriteLine($"Preço com desconto: {produto.Preco:C}");

            // Propriedade somente leitura
            Console.WriteLine($"Código: {produto.Codigo}"); // ✅
                                                            // produto.Codigo = "NOVO123"; // ❌ Erro - somente leitura

            // ==================================================================
            // 5. ENCAPSULAMENTO COM MÉTODOS PRIVADOS
            // ==================================================================
            Console.WriteLine("\n5. MÉTODOS PRIVADOS:");

            var calculadora = new CalculadoraCientifica();
            double resultado = calculadora.CalcularRaizQuadrada(25);
            Console.WriteLine($"Raiz quadrada de 25: {resultado}");

            // ❌ Método interno não acessível
            // calculadora.ValidarNumero(-5); // Erro!
        }
    }

    // ==================================================================
    // CLASSE COM ENCAPSULAMENTO BÁSICO
    // ==================================================================
    public class ContaBancaria
    {
        // Campo privado - acesso restrito
        private decimal _saldo;

        // Propriedade pública com acesso controlado
        public string NumeroConta { get; }
        public decimal Saldo
        {
            get => _saldo;
            private set // Set privado - só a classe pode modificar
            {
                if (value < 0)
                    throw new ArgumentException("Saldo não pode ser negativo");
                _saldo = value;
            }
        }

        public ContaBancaria(string numeroConta, decimal saldoInicial = 0)
        {
            NumeroConta = numeroConta;
            Saldo = saldoInicial;
        }

        // Métodos públicos para manipular o saldo
        public void Depositar(decimal valor)
        {
            if (valor <= 0)
                throw new ArgumentException("Valor do depósito deve ser positivo");

            Saldo += valor; // ✅ Acesso permitido dentro da classe
        }

        public void Sacar(decimal valor)
        {
            if (valor <= 0)
                throw new ArgumentException("Valor do saque deve ser positivo");

            if (Saldo - valor < 0)
                throw new InvalidOperationException("Saldo insuficiente");

            Saldo -= valor; // ✅ Acesso permitido dentro da classe
        }
    }

    // ==================================================================
    // CLASSE COM VALIDAÇÃO NO SETTER
    // ==================================================================
    public class Usuario
    {
        private int _idade;

        public string Nome { get; set; }

        public int Idade
        {
            get => _idade;
            set
            {
                // Validação no setter - encapsula a lógica de validação
                if (value < 18 || value > 120)
                    throw new ArgumentException("Idade deve ser entre 18 e 120 anos");

                _idade = value;
            }
        }
    }

    // ==================================================================
    // CLASSE COM CAMPOS PRIVADOS E MÉTODOS PÚBLICOS
    // ==================================================================
    public class Carro
    {
        // Campos privados - estado interno protegido
        private bool _motorLigado;
        private int _velocidadeAtual;

        // Propriedades públicas - interface controlada
        public string Marca { get; }
        public string Modelo { get; }
        public int Ano { get; }

        public Carro(string marca, string modelo, int ano)
        {
            Marca = marca;
            Modelo = modelo;
            Ano = ano;
            _motorLigado = false;
            _velocidadeAtual = 0;
        }

        // Métodos públicos - ações controladas
        public void Ligar()
        {
            _motorLigado = true;
            Console.WriteLine("Motor ligado");
        }

        public void Desligar()
        {
            _motorLigado = false;
            _velocidadeAtual = 0;
            Console.WriteLine("Motor desligado");
        }

        public void Acelerar(int incremento)
        {
            if (!_motorLigado)
                throw new InvalidOperationException("Motor desligado");

            _velocidadeAtual += incremento;
            Console.WriteLine($"Velocidade: {_velocidadeAtual} km/h");
        }

        public void Freiar(int decremento)
        {
            _velocidadeAtual = Math.Max(0, _velocidadeAtual - decremento);
            Console.WriteLine($"Velocidade: {_velocidadeAtual} km/h");
        }

        public void ExibirInfo()
        {
            Console.WriteLine($"{Marca} {Modelo} ({Ano}) - Motor: {(_motorLigado ? "Ligado" : "Desligado")}");
        }
    }

    // ==================================================================
    // CLASSE COM DIFERENTES TIPOS DE PROPRIEDADES
    // ==================================================================
    public class Produto
    {
        private static int _proximoId = 1;
        private decimal _preco;

        // Propriedade somente leitura (apenas get)
        public string Codigo { get; }

        // Propriedade com get público e set privado
        public string Nome { get; private set; }

        // Propriedade com lógica personalizada no set
        public decimal Preco
        {
            get => _preco;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Preço deve ser positivo");

                // Aplica desconto automático para preços altos
                _preco = value > 1000 ? value * 0.9m : value;
            }
        }

        public Produto(string nome, decimal preco)
        {
            Codigo = $"PROD{_proximoId++:D4}"; // Geração automática
            Nome = nome;
            Preco = preco;
        }

        // Método para permitir mudança do nome (controlada)
        public void AlterarNome(string novoNome)
        {
            if (string.IsNullOrWhiteSpace(novoNome))
                throw new ArgumentException("Nome não pode ser vazio");

            Nome = novoNome;
        }
    }

    // ==================================================================
    // CLASSE COM MÉTODOS PRIVADOS
    // ==================================================================
    public class CalculadoraCientifica
    {
        // Método público - interface para o usuário
        public double CalcularRaizQuadrada(double numero)
        {
            ValidarNumero(numero); // ✅ Método privado chamado internamente
            return Math.Sqrt(numero);
        }

        public double CalcularPotencia(double baseNum, double expoente)
        {
            ValidarNumero(baseNum);
            return Math.Pow(baseNum, expoente);
        }

        // Método privado - encapsula validação interna
        private void ValidarNumero(double numero)
        {
            if (numero < 0)
                throw new ArgumentException("Número não pode ser negativo");
        }
    }
}