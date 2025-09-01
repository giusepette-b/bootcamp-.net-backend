using System;
using System.Collections.Generic;

namespace HerancaPolimorfismo.Models
{
    public static class Heranca
    {
        public static void Demonstrar()
        {
            Console.WriteLine("=== HERANÇA: REUTILIZAÇÃO DE CÓDIGO ===\n");

            // ==================================================================
            // 1. HERANÇA BÁSICA - CLASSE BASE E DERIVADAS
            // ==================================================================
            Console.WriteLine("1. HERANÇA BÁSICA:");

            // Classe base
            Veiculo veiculoGenerico = new Veiculo("Genérico", 2020);
            veiculoGenerico.Ligar();
            veiculoGenerico.Mover();
            Console.WriteLine();

            // Classes derivadas - herdam de Veiculo
            Carro carro = new Carro("Toyota", "Corolla", 2022, 4);
            Moto moto = new Moto("Honda", "CB500", 2021, 500);
            Caminhao caminhao = new Caminhao("Volvo", "FH", 2020, 10000);

            // Todos herdam os métodos básicos de Veiculo
            carro.Ligar();
            carro.Mover();

            moto.Ligar();
            moto.Mover();

            caminhao.Ligar();
            caminhao.Mover();
            Console.WriteLine();

            // ==================================================================
            // 2. ACESSO A MEMBROS DA CLASSE BASE - CORRIGIDO
            // ==================================================================
            Console.WriteLine("2. ACESSO A MEMBROS DA CLASSE BASE:");

            // ✅ CORREÇÃO: Usar propriedades públicas ou métodos para acessar dados
            Console.WriteLine($"Carro: {carro.ObterMarca()} {carro.ObterModelo()} ({carro.AnoFabricacao})");
            Console.WriteLine($"Moto: {moto.ObterMarca()} {moto.ObterModelo()} ({moto.AnoFabricacao})");
            Console.WriteLine($"Caminhão: {caminhao.ObterMarca()} {caminhao.ObterModelo()} ({caminhao.AnoFabricacao})");
            Console.WriteLine();

            // ==================================================================
            // 3. HERANÇA COM CONSTRUTORES
            // ==================================================================
            Console.WriteLine("3. HERANÇA COM CONSTRUTORES:");

            // Chamada encadeada de construtores (base)
            Carro carro2 = new Carro("Ford", "Mustang", 2023, 2);
            Console.WriteLine($"Carro criado: {carro2.ObterMarca()} {carro2.ObterModelo()}");
            Console.WriteLine();

            // ==================================================================
            // 4. SOBRESCRITA DE MÉTODOS (OVERRIDE)
            // ==================================================================
            Console.WriteLine("4. SOBRESCRITA DE MÉTODOS:");

            carro.Descrever(); // Método sobrescrito
            moto.Descrever();  // Método sobrescrito
            caminhao.Descrever(); // Método sobrescrito
            Console.WriteLine();

            // ==================================================================
            // 5. HERANÇA EM DIFERENTES NÍVEIS
            // ==================================================================
            Console.WriteLine("5. HERANÇA MULTINÍVEL:");

            Animal animal = new Animal("Animal genérico");
            Mamifero mamifero = new Mamifero("Leão", 5);
            Cao cao = new Cao("Rex", 3, "Pastor Alemão");

            Console.WriteLine("Cadeia de herança:");
            animal.EmitirSom();
            mamifero.EmitirSom();
            cao.EmitirSom();
            cao.Amamentar(); // Herdado de Mamifero
            Console.WriteLine();

            // ==================================================================
            // 6. HERANÇA VS COMPOSIÇÃO
            // ==================================================================
            Console.WriteLine("6. HERANÇA VS COMPOSIÇÃO:");

            // Herança: "É-UM"
            Carro meuCarro = new Carro("Fiat", "Uno", 2015, 4);

            // Composição: "TEM-UM"
            Motor motor = new Motor("V8", 300);
            Radio radio = new Radio("Pioneer", true);

            meuCarro.InstalarMotor(motor);
            meuCarro.InstalarRadio(radio);

            Console.WriteLine($"Carro com motor {meuCarro.Motor?.Tipo} e rádio {meuCarro.Radio?.Marca}");
            Console.WriteLine();

            // ==================================================================
            // 7. HERANÇA COM CLASSES SELADAS
            // ==================================================================
            Console.WriteLine("7. CLASSES SELADAS:");

            // Classe selada - não pode ser herdada
            CarroEletrico tesla = new CarroEletrico("Tesla", "Model S", 2023, 4, 100);
            tesla.Ligar();
            tesla.CarregarBateria();
            Console.WriteLine();

            // ❌ Não pode herdar de classe selada
            // class NovoCarro : CarroEletrico { } // Erro!
        }
    }

    // ==================================================================
    // CLASSE BASE - VEICULO
    // ==================================================================
    public class Veiculo
    {
        // ✅ CORREÇÃO: Alterado para private e adicionados métodos de acesso
        private string _marca;
        private string _modelo;
        public int AnoFabricacao { get; set; }

        // Construtor da classe base
        public Veiculo(string marca, string modelo, int anoFabricacao)
        {
            _marca = marca;
            _modelo = modelo;
            AnoFabricacao = anoFabricacao;
        }

        // Construtor sobrecarregado
        public Veiculo(string tipo, int anoFabricacao)
        {
            _marca = tipo;
            _modelo = "Genérico";
            AnoFabricacao = anoFabricacao;
        }

        // ✅ CORREÇÃO: Métodos públicos para acessar dados privados
        public string ObterMarca() => _marca;
        public string ObterModelo() => _modelo;

        // Métodos da classe base
        public virtual void Ligar()
        {
            Console.WriteLine($"{_marca} {_modelo} ligado");
        }

        public virtual void Desligar()
        {
            Console.WriteLine($"{_marca} {_modelo} desligado");
        }

        public virtual void Mover()
        {
            Console.WriteLine($"{_marca} {_modelo} em movimento");
        }

        // Método virtual - pode ser sobrescrito pelas classes derivadas
        public virtual void Descrever()
        {
            Console.WriteLine($"Veículo: {_marca} {_modelo} ({AnoFabricacao})");
        }
    }

    // ==================================================================
    // CLASSE DERIVADA - CARRO (HERDA DE VEICULO)
    // ==================================================================
    public class Carro : Veiculo
    {
        // Propriedade específica de Carro
        public int QuantidadePortas { get; set; }

        // ✅ CORREÇÃO: Propriedades anuláveis para evitar warning CS8618
        public Motor? Motor { get; private set; }
        public Radio? Radio { get; private set; }

        // Construtor chama o construtor da classe base usando base()
        public Carro(string marca, string modelo, int anoFabricacao, int quantidadePortas)
            : base(marca, modelo, anoFabricacao) // Chama construtor da classe base
        {
            QuantidadePortas = quantidadePortas;
            // ✅ CORREÇÃO: Inicializar como null para evitar warning
            Motor = null;
            Radio = null;
        }

        // Métodos específicos de Carro
        public void AbrirPorta()
        {
            Console.WriteLine($"Porta do {ObterMarca()} {ObterModelo()} aberta");
        }

        public void FecharPorta()
        {
            Console.WriteLine($"Porta do {ObterMarca()} {ObterModelo()} fechada");
        }

        // Sobrescreve método da classe base
        public override void Descrever()
        {
            // Chama método da classe base e adiciona comportamento específico
            base.Descrever();
            Console.WriteLine($"Tipo: Carro com {QuantidadePortas} portas");
        }

        // Métodos para composição
        public void InstalarMotor(Motor motor)
        {
            Motor = motor;
            Console.WriteLine($"Motor {motor.Tipo} instalado no {ObterMarca()} {ObterModelo()}");
        }

        public void InstalarRadio(Radio radio)
        {
            Radio = radio;
            Console.WriteLine($"Rádio {radio.Marca} instalado no {ObterMarca()} {ObterModelo()}");
        }
    }

    // ==================================================================
    // CLASSE DERIVADA - MOTO (HERDA DE VEICULO)
    // ==================================================================
    public class Moto : Veiculo
    {
        // Propriedade específica de Moto
        public int Cilindrada { get; set; }

        public Moto(string marca, string modelo, int anoFabricacao, int cilindrada)
            : base(marca, modelo, anoFabricacao)
        {
            Cilindrada = cilindrada;
        }

        // Métodos específicos de Moto
        public void Empinar()
        {
            Console.WriteLine($"{ObterMarca()} {ObterModelo()} empinando!");
        }

        // Sobrescreve método da classe base
        public override void Descrever()
        {
            base.Descrever();
            Console.WriteLine($"Tipo: Moto {Cilindrada}cc");
        }

        // Sobrescreve método com comportamento diferente
        public override void Mover()
        {
            Console.WriteLine($"{ObterMarca()} {ObterModelo()} zig-zagando no trânsito");
        }
    }

    // ==================================================================
    // CLASSE DERIVADA - CAMINHAO (HERDA DE VEICULO)
    // ==================================================================
    public class Caminhao : Veiculo
    {
        // Propriedade específica de Caminhao
        public double CapacidadeCarga { get; set; }

        public Caminhao(string marca, string modelo, int anoFabricacao, double capacidadeCarga)
            : base(marca, modelo, anoFabricacao)
        {
            CapacidadeCarga = capacidadeCarga;
        }

        // Métodos específicos de Caminhao
        public void Carregar(double peso)
        {
            if (peso <= CapacidadeCarga)
            {
                Console.WriteLine($"Caminhão carregado com {peso}kg");
            }
            else
            {
                Console.WriteLine($"Capacidade excedida! Máximo: {CapacidadeCarga}kg");
            }
        }

        // Sobrescreve método da classe base
        public override void Descrever()
        {
            base.Descrever();
            Console.WriteLine($"Tipo: Caminhão ({CapacidadeCarga}kg capacidade)");
        }
    }

    // ==================================================================
    // HERANÇA MULTINÍVEL
    // ==================================================================
    public class Animal
    {
        public string Nome { get; set; }

        public Animal(string nome)
        {
            Nome = nome;
        }

        public virtual void EmitirSom()
        {
            Console.WriteLine($"{Nome} emite um som");
        }
    }

    public class Mamifero : Animal
    {
        public int Idade { get; set; }

        public Mamifero(string nome, int idade) : base(nome)
        {
            Idade = idade;
        }

        public void Amamentar()
        {
            Console.WriteLine($"{Nome} amamentando");
        }

        public override void EmitirSom()
        {
            Console.WriteLine($"{Nome} (mamífero) emite som característico");
        }
    }

    public class Cao : Mamifero
    {
        public string Raca { get; set; }

        public Cao(string nome, int idade, string raca) : base(nome, idade)
        {
            Raca = raca;
        }

        public void Latir()
        {
            Console.WriteLine($"{Nome} está latindo: Au au!");
        }

        public override void EmitirSom()
        {
            Latir(); // Chama o método específico
        }
    }

    // ==================================================================
    // CLASSES PARA COMPOSIÇÃO (NÃO HERANÇA)
    // ==================================================================
    public class Motor
    {
        public string Tipo { get; set; }
        public int Potencia { get; set; }

        public Motor(string tipo, int potencia)
        {
            Tipo = tipo;
            Potencia = potencia;
        }
    }

    public class Radio
    {
        public string Marca { get; set; }
        public bool TemBluetooth { get; set; }

        public Radio(string marca, bool temBluetooth)
        {
            Marca = marca;
            TemBluetooth = temBluetooth;
        }

        public void Sintonizar(float frequencia)
        {
            Console.WriteLine($"Rádio {Marca} sintonizado em {frequencia} FM");
        }
    }

    // ==================================================================
    // CLASSE SELADA - NÃO PODE SER HERDADA
    // ==================================================================
    public sealed class CarroEletrico : Carro
    {
        public int AutonomiaBateria { get; set; }

        public CarroEletrico(string marca, string modelo, int ano, int portas, int autonomia)
            : base(marca, modelo, ano, portas)
        {
            AutonomiaBateria = autonomia;
        }

        public void CarregarBateria()
        {
            Console.WriteLine($"{ObterMarca()} {ObterModelo()} carregando bateria ({AutonomiaBateria}km de autonomia)");
        }

        // Sobrescreve método com comportamento diferente
        public override void Ligar()
        {
            Console.WriteLine($"{ObterMarca()} {ObterModelo()} ligado silenciosamente (elétrico)");
        }
    }
}