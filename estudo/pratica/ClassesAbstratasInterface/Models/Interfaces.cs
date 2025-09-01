using System;
using System.Collections.Generic;

namespace ClassesAbstratasInterfaces.Models
{
    public static class Interfaces
    {
        public static void Demonstrar()
        {
            Console.WriteLine("=== INTERFACES: CONTRATOS DE COMPORTAMENTO ===\n");

            // ==================================================================
            // 1. CONCEITO DE INTERFACE
            // ==================================================================
            Console.WriteLine("1. CONCEITO DE INTERFACE:");
            Console.WriteLine("   • Define um contrato que as classes devem implementar");
            Console.WriteLine("   • Não contém implementação, apenas assinaturas");
            Console.WriteLine("   • Permite implementação múltipla");
            Console.WriteLine("   • Promove o desacoplamento e a flexibilidade");
            Console.WriteLine("   • Nome geralmente começa com 'I' (ex: IAnimal)");
            Console.WriteLine();

            // ==================================================================
            // 2. IMPLEMENTAÇÃO DE INTERFACES
            // ==================================================================
            Console.WriteLine("2. IMPLEMENTAÇÃO DE INTERFACES:");

            // Diferentes classes implementando a mesma interface
            IAnimal cachorro = new CachorroInterface("Rex");
            IAnimal gato = new GatoInterface("Mimi");
            IAnimal passaro = new Passaro("Piu-Piu");

            List<IAnimal> animais = new List<IAnimal> { cachorro, gato, passaro };

            foreach (var animal in animais)
            {
                animal.EmitirSom();    // Cada um implementa de forma diferente
                animal.Mover();        // Cada um implementa de forma diferente
                Console.WriteLine($"Espécie: {animal.Especie}");
                Console.WriteLine();
            }

            // ==================================================================
            // 3. IMPLEMENTAÇÃO MÚLTIPLA DE INTERFACES
            // ==================================================================
            Console.WriteLine("3. IMPLEMENTAÇÃO MÚLTIPLA:");

            var smartphone = new Smartphone();

            // Uma classe pode implementar várias interfaces
            IReprodutorMusical player = smartphone;
            IAplicativoMensagens app = smartphone;
            ICamera camera = smartphone;

            player.TocarMusica();
            app.EnviarMensagem("Olá!");
            camera.TirarFoto();
            Console.WriteLine();

            // ==================================================================
            // 4. INTERFACES COM PROPRIEDADES
            // ==================================================================
            Console.WriteLine("4. INTERFACES COM PROPRIEDADES:");

            IVeiculo carro = new CarroInterface("Toyota", "Corolla");
            IVeiculo moto = new MotoInterface("Honda", "CB500");

            Console.WriteLine($"Carro: {carro.Marca} {carro.Modelo}, Ligado: {carro.Ligado}");
            Console.WriteLine($"Moto: {moto.Marca} {moto.Modelo}, Ligado: {moto.Ligado}");

            carro.Ligar();
            moto.Ligar();

            Console.WriteLine($"Carro ligado: {carro.Ligado}");
            Console.WriteLine($"Moto ligado: {moto.Ligado}");
            Console.WriteLine();

            // ==================================================================
            // 5. HERANÇA DE INTERFACES
            // ==================================================================
            Console.WriteLine("5. HERANÇA DE INTERFACES:");

            IFuncionario gerente = new GerenteInterface("João", 5000);

            // Implementa todas as interfaces da hierarquia
            gerente.Trabalhar();     // De IFuncionario
            gerente.FazerLogin();    // De IAutenticavel
            gerente.ReceberSalario();// De IFuncionario
            Console.WriteLine();

            // ==================================================================
            // 6. INTERFACES EXPLÍCITAS
            // ==================================================================
            Console.WriteLine("6. IMPLEMENTAÇÃO EXPLÍCITA DE INTERFACES:");

            var multi = new MultiFuncional();

            // Chamada normal de método da classe
            multi.Processar();

            // Chamada explícita de método de interface
            ((IProcessador)multi).Processar();
            ((ILogger)multi).Processar();
            Console.WriteLine();

            // ==================================================================
            // 7. INTERFACES EM INJEÇÃO DE DEPENDÊNCIA
            // ==================================================================
            Console.WriteLine("7. INJEÇÃO DE DEPENDÊNCIA COM INTERFACES:");

            // ✅ Flexibilidade: podemos mudar a implementação facilmente
            INotificacao emailNotificacao = new EmailNotificacao();
            INotificacao smsNotificacao = new SMSNotificacao();

            var sistema = new SistemaNotificacao(emailNotificacao);
            sistema.EnviarNotificacao("Mensagem via Email");

            sistema.AlterarNotificacao(smsNotificacao);
            sistema.EnviarNotificacao("Mensagem via SMS");
            Console.WriteLine();

            // ==================================================================
            // 8. VANTAGENS DAS INTERFACES
            // ==================================================================
            Console.WriteLine("8. VANTAGENS DAS INTERFACES:");
            Console.WriteLine("   ✅ Desacoplamento: classes não dependem de implementações concretas");
            Console.WriteLine("   ✅ Testabilidade: fácil mock de dependências em testes");
            Console.WriteLine("   ✅ Flexibilidade: mudar implementações sem alterar contrato");
            Console.WriteLine("   ✅ Extensibilidade: fácil adicionar novos comportamentos");
            Console.WriteLine("   ✅ Implementação múltipla: uma classe pode ter vários papéis");
        }
    }

    // ==================================================================
    // INTERFACE SIMPLES
    // ==================================================================
    public interface IAnimal
    {
        // Assinatura de método - sem implementação
        void EmitirSom();
        void Mover();

        // Propriedade na interface
        string Especie { get; }
    }

    public class CachorroInterface : IAnimal
    {
        public string Nome { get; }
        public string Especie => "Canino";

        public CachorroInterface(string nome)
        {
            Nome = nome;
        }

        public void EmitirSom()
        {
            Console.WriteLine($"{Nome} diz: Au au!");
        }

        public void Mover()
        {
            Console.WriteLine($"{Nome} está correndo");
        }
    }

    public class GatoInterface : IAnimal
    {
        public string Nome { get; }
        public string Especie => "Felino";

        public GatoInterface(string nome)
        {
            Nome = nome;
        }

        public void EmitirSom()
        {
            Console.WriteLine($"{Nome} diz: Miau!");
        }

        public void Mover()
        {
            Console.WriteLine($"{Nome} está escalando");
        }
    }

    public class Passaro : IAnimal
    {
        public string Nome { get; }
        public string Especie => "Ave";

        public Passaro(string nome)
        {
            Nome = nome;
        }

        public void EmitirSom()
        {
            Console.WriteLine($"{Nome} diz: Piu piu!");
        }

        public void Mover()
        {
            Console.WriteLine($"{Nome} está voando");
        }
    }

    // ==================================================================
    // IMPLEMENTAÇÃO MÚLTIPLA DE INTERFACES
    // ==================================================================
    public interface IReprodutorMusical
    {
        void TocarMusica();
        void PausarMusica();
    }

    public interface IAplicativoMensagens
    {
        void EnviarMensagem(string mensagem);
        void ReceberMensagem();
    }

    public interface ICamera
    {
        void TirarFoto();
        void GravarVideo();
    }

    public class Smartphone : IReprodutorMusical, IAplicativoMensagens, ICamera
    {
        public void TocarMusica()
        {
            Console.WriteLine("Tocando música...");
        }

        public void PausarMusica()
        {
            Console.WriteLine("Música pausada");
        }

        public void EnviarMensagem(string mensagem)
        {
            Console.WriteLine($"Enviando mensagem: {mensagem}");
        }

        public void ReceberMensagem()
        {
            Console.WriteLine("Mensagem recebida");
        }

        public void TirarFoto()
        {
            Console.WriteLine("Foto tirada");
        }

        public void GravarVideo()
        {
            Console.WriteLine("Gravando vídeo");
        }
    }

    // ==================================================================
    // INTERFACE COM PROPRIEDADES
    // ==================================================================
    public interface IVeiculo
    {
        string Marca { get; }
        string Modelo { get; }
        bool Ligado { get; }

        void Ligar();
        void Desligar();
        void Mover();
    }

    public class CarroInterface : IVeiculo
    {
        public string Marca { get; }
        public string Modelo { get; }
        public bool Ligado { get; private set; }

        public CarroInterface(string marca, string modelo)
        {
            Marca = marca;
            Modelo = modelo;
            Ligado = false;
        }

        public void Ligar()
        {
            Ligado = true;
            Console.WriteLine($"{Marca} {Modelo} ligado");
        }

        public void Desligar()
        {
            Ligado = false;
            Console.WriteLine($"{Marca} {Modelo} desligado");
        }

        public void Mover()
        {
            Console.WriteLine($"{Marca} {Modelo} em movimento");
        }
    }

    public class MotoInterface : IVeiculo
    {
        public string Marca { get; }
        public string Modelo { get; }
        public bool Ligado { get; private set; }

        public MotoInterface(string marca, string modelo)
        {
            Marca = marca;
            Modelo = modelo;
            Ligado = false;
        }

        public void Ligar()
        {
            Ligado = true;
            Console.WriteLine($"{Marca} {Modelo} ligada");
        }

        public void Desligar()
        {
            Ligado = false;
            Console.WriteLine($"{Marca} {Modelo} desligada");
        }

        public void Mover()
        {
            Console.WriteLine($"{Marca} {Modelo} zig-zagando");
        }
    }

    // ==================================================================
    // HERANÇA DE INTERFACES
    // ==================================================================
    public interface IAutenticavel
    {
        void FazerLogin();
        void FazerLogout();
    }

    public interface IFuncionario : IAutenticavel
    {
        string Nome { get; }
        decimal Salario { get; }

        void Trabalhar();
        void ReceberSalario();
    }

    public class GerenteInterface : IFuncionario
    {
        public string Nome { get; }
        public decimal Salario { get; }

        public GerenteInterface(string nome, decimal salario)
        {
            Nome = nome;
            Salario = salario;
        }

        public void Trabalhar()
        {
            Console.WriteLine($"{Nome} está gerenciando a equipe");
        }

        public void ReceberSalario()
        {
            Console.WriteLine($"{Nome} recebeu R$ {Salario:F2}");
        }

        public void FazerLogin()
        {
            Console.WriteLine($"{Nome} fez login no sistema");
        }

        public void FazerLogout()
        {
            Console.WriteLine($"{Nome} fez logout do sistema");
        }
    }

    // ==================================================================
    // IMPLEMENTAÇÃO EXPLÍCITA DE INTERFACES
    // ==================================================================
    public interface IProcessador
    {
        void Processar();
    }

    public interface ILogger
    {
        void Processar();
    }

    public class MultiFuncional : IProcessador, ILogger
    {
        // Implementação normal de método da classe
        public void Processar()
        {
            Console.WriteLine("Processamento geral");
        }

        // Implementação explícita da interface IProcessador
        void IProcessador.Processar()
        {
            Console.WriteLine("Processamento específico de IProcessador");
        }

        // Implementação explícita da interface ILogger
        void ILogger.Processar()
        {
            Console.WriteLine("Processamento específico de ILogger");
        }
    }

    // ==================================================================
    // INTERFACES PARA INJEÇÃO DE DEPENDÊNCIA
    // ==================================================================
    public interface INotificacao
    {
        void Enviar(string mensagem);
    }

    public class EmailNotificacao : INotificacao
    {
        public void Enviar(string mensagem)
        {
            Console.WriteLine($"📧 Email enviado: {mensagem}");
        }
    }

    public class SMSNotificacao : INotificacao
    {
        public void Enviar(string mensagem)
        {
            Console.WriteLine($"📱 SMS enviado: {mensagem}");
        }
    }

    public class SistemaNotificacao
    {
        private INotificacao _notificacao;

        // Injeção de dependência via construtor
        public SistemaNotificacao(INotificacao notificacao)
        {
            _notificacao = notificacao;
        }

        // Método para alterar a implementação em tempo de execução
        public void AlterarNotificacao(INotificacao novaNotificacao)
        {
            _notificacao = novaNotificacao;
        }

        public void EnviarNotificacao(string mensagem)
        {
            _notificacao.Enviar(mensagem);
        }
    }
}