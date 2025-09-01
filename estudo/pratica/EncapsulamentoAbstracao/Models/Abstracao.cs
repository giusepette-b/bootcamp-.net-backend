using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EncapsulamentoAbstracao.Models

{
    public static class Abstracao
    {
        public static void Demonstrar()
        {
            Console.WriteLine("=== ABSTRAÇÃO: SIMPLIFICAR A REALIDADE ===\n");

            // ==================================================================
            // 1. CLASSE ABSTRATA E HERANÇA
            // ==================================================================
            Console.WriteLine("1. CLASSE ABSTRATA:");

            // ❌ Não pode instanciar classe abstrata
            // var forma = new FormaGeometrica(); // Erro!

            // ✅ Instanciando classes concretas
            FormaGeometrica circulo = new Circulo(5.0);
            FormaGeometrica retangulo = new Retangulo(4.0, 6.0);

            Console.WriteLine($"Área do círculo: {circulo.CalcularArea():F2}");
            Console.WriteLine($"Área do retângulo: {retangulo.CalcularArea():F2}");
            Console.WriteLine($"Perímetro do círculo: {circulo.CalcularPerimetro():F2}");

            // ==================================================================
            // 2. MÉTODOS ABSTRATOS - IMPLEMENTAÇÃO OBRIGATÓRIA
            // ==================================================================
            Console.WriteLine("\n2. MÉTODOS ABSTRATOS:");

            List<FormaGeometrica> formas = new List<FormaGeometrica>
            {
                new Circulo(3.0),
                new Retangulo(5.0, 2.0),
                new Triangulo(3.0, 4.0, 5.0)
            };

            foreach (var forma in formas)
            {
                Console.WriteLine($"{forma.GetType().Name}:");
                Console.WriteLine($"  Área: {forma.CalcularArea():F2}");
                Console.WriteLine($"  Perímetro: {forma.CalcularPerimetro():F2}");
                forma.ExibirInfo(); // Método concreto da classe abstrata
                Console.WriteLine();
            }

            // ==================================================================
            // 3. INTERFACES - CONTRATOS DE COMPORTAMENTO
            // ==================================================================
            Console.WriteLine("3. INTERFACES:");

            IAnimal cachorro = new Cachorro();
            IAnimal gato = new Gato();

            cachorro.EmitirSom();
            cachorro.Mover();

            gato.EmitirSom();
            gato.Mover();

            // ==================================================================
            // 4. ABSTRAÇÃO COM MÚLTIPLAS INTERFACES
            // ==================================================================
            Console.WriteLine("\n4. MÚLTIPLAS INTERFACES:");

            var smartphone = new Smartphone();

            // Como IReprodutorMusical
            IReprodutorMusical player = smartphone;
            player.Tocar();
            player.Pausar();

            // Como IAplicativoMensagens
            IAplicativoMensagens app = smartphone;
            app.EnviarMensagem("Olá! Como vai?");
            app.ReceberMensagem();

            // ==================================================================
            // 5. ABSTRAÇÃO EM SISTEMAS REAIS
            // ==================================================================
            Console.WriteLine("\n5. ABSTRAÇÃO EM SISTEMAS REAIS:");

            Pagamento pagamentoCartao = new PagamentoCartaoCredito(100.00m, "1234-5678-9012-3456");
            Pagamento pagamentoBoleto = new PagamentoBoleto(200.00m, "12345678901");

            pagamentoCartao.ProcessarPagamento();
            Console.WriteLine($"Status: {pagamentoCartao.ObterStatus()}");

            pagamentoBoleto.ProcessarPagamento();
            Console.WriteLine($"Status: {pagamentoBoleto.ObterStatus()}");
        }
    }

    // ==================================================================
    // CLASSE ABSTRATA - DEFINE CONCEITO, NÃO IMPLEMENTAÇÃO
    // ==================================================================
    public abstract class FormaGeometrica
    {
        // Método abstrato - sem implementação, obriga as filhas a implementar
        public abstract double CalcularArea();
        public abstract double CalcularPerimetro();

        // Método concreto - implementação padrão para todas as filhas
        public virtual void ExibirInfo()
        {
            Console.WriteLine("Forma geométrica genérica");
        }

        // Propriedade abstrata
        public abstract string Nome { get; }
    }

    // ==================================================================
    // CLASSE CONCRETA - IMPLEMENTA A ABSTRAÇÃO
    // ==================================================================
    public class Circulo : FormaGeometrica
    {
        public double Raio { get; }

        public override string Nome => "Círculo";

        public Circulo(double raio)
        {
            Raio = raio;
        }

        // Implementação obrigatória dos métodos abstratos
        public override double CalcularArea()
        {
            return Math.PI * Math.Pow(Raio, 2);
        }

        public override double CalcularPerimetro()
        {
            return 2 * Math.PI * Raio;
        }

        // Override do método concreto
        public override void ExibirInfo()
        {
            Console.WriteLine($"Círculo com raio {Raio:F2}");
        }
    }

    public class Retangulo : FormaGeometrica
    {
        public double Largura { get; }
        public double Altura { get; }

        public override string Nome => "Retângulo";

        public Retangulo(double largura, double altura)
        {
            Largura = largura;
            Altura = altura;
        }

        public override double CalcularArea()
        {
            return Largura * Altura;
        }

        public override double CalcularPerimetro()
        {
            return 2 * (Largura + Altura);
        }

        public override void ExibirInfo()
        {
            Console.WriteLine($"Retângulo {Largura:F2}x{Altura:F2}");
        }
    }

    public class Triangulo : FormaGeometrica
    {
        public double LadoA { get; }
        public double LadoB { get; }
        public double LadoC { get; }

        public override string Nome => "Triângulo";

        public Triangulo(double ladoA, double ladoB, double ladoC)
        {
            LadoA = ladoA;
            LadoB = ladoB;
            LadoC = ladoC;
        }

        public override double CalcularArea()
        {
            // Fórmula de Herão
            double s = (LadoA + LadoB + LadoC) / 2;
            return Math.Sqrt(s * (s - LadoA) * (s - LadoB) * (s - LadoC));
        }

        public override double CalcularPerimetro()
        {
            return LadoA + LadoB + LadoC;
        }

        public override void ExibirInfo()
        {
            Console.WriteLine($"Triângulo {LadoA:F2}/{LadoB:F2}/{LadoC:F2}");
        }
    }

    // ==================================================================
    // INTERFACE - CONTRATO DE COMPORTAMENTO
    // ==================================================================
    public interface IAnimal // interfaces, por convenção, se implementam nomenclaturas com "I" no começo do nome.
    {
        // Apenas assinatura, sem implementação
        void EmitirSom();
        void Mover();

        // Propriedade na interface
        string Especie { get; }
    }

    public class Cachorro : IAnimal
    {
        public string Especie => "Canino";

        public void EmitirSom()
        {
            Console.WriteLine("Au au!");
        }

        public void Mover()
        {
            Console.WriteLine("Cachorro correndo...");
        }
    }

    public class Gato : IAnimal
    {
        public string Especie => "Felino";

        public void EmitirSom()
        {
            Console.WriteLine("Miau!");
        }

        public void Mover()
        {
            Console.WriteLine("Gato escalando...");
        }
    }

    // ==================================================================
    // MÚLTIPLAS INTERFACES
    // ==================================================================
    public interface IReprodutorMusical //
    {
        void Tocar();
        void Pausar();
        void ProximaMusica();
    }

    public interface IAplicativoMensagens
    {
        void EnviarMensagem(string mensagem);
        void ReceberMensagem();
    }

    public class Smartphone : IReprodutorMusical, IAplicativoMensagens
    {
        public void Tocar()
        {
            Console.WriteLine("Tocando música...");
        }

        public void Pausar()
        {
            Console.WriteLine("Música pausada");
        }

        public void ProximaMusica()
        {
            Console.WriteLine("Próxima música");
        }

        public void EnviarMensagem(string mensagem)
        {
            Console.WriteLine($"Enviando mensagem: {mensagem}");
        }

        public void ReceberMensagem()
        {
            Console.WriteLine("Mensagem recebida");
        }
    }

    // ==================================================================
    // ABSTRAÇÃO PARA SISTEMA DE PAGAMENTOS
    // ==================================================================
    public abstract class Pagamento
    {
        public decimal Valor { get; }
        public DateTime Data { get; }
        public string Status { get; protected set; }

        protected Pagamento(decimal valor)
        {
            Valor = valor;
            Data = DateTime.Now;
            Status = "Pendente";
        }

        // Método abstrato - cada tipo de pagamento implementa diferente
        public abstract void ProcessarPagamento();

        // Método concreto - comum a todos os pagamentos
        public string ObterStatus()
        {
            return $"{Status} em {Data:dd/MM/yyyy}";
        }
    }

    public class PagamentoCartaoCredito : Pagamento
    {
        public string NumeroCartao { get; }

        public PagamentoCartaoCredito(decimal valor, string numeroCartao)
            : base(valor)
        {
            NumeroCartao = numeroCartao;
        }

        public override void ProcessarPagamento()
        {
            Console.WriteLine($"Processando pagamento de R$ {Valor:F2} no cartão {NumeroCartao}");
            // Simulação de processamento
            Status = "Aprovado";
        }
    }

    public class PagamentoBoleto : Pagamento
    {
        public string CodigoBarras { get; }

        public PagamentoBoleto(decimal valor, string codigoBarras)
            : base(valor)
        {
            CodigoBarras = codigoBarras;
        }

        public override void ProcessarPagamento()
        {
            Console.WriteLine($"Gerando boleto de R$ {Valor:F2} - Código: {CodigoBarras}");
            // Simulação de geração de boleto
            Status = "Aguardando pagamento";
        }
    }
}