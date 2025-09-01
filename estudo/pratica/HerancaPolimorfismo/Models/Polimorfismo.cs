using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace HerancaPolimorfismo.Models
{
    public static class Polimorfismo
    {
        public static void Demonstrar()
        {
            Console.WriteLine("=== POLIMORFISMO: MÚLTIPLAS FORMAS ===\n");

            // ==================================================================
            // 1. POLIMORFISMO COM HERANÇA
            // ==================================================================
            Console.WriteLine("1. POLIMORFISMO COM HERANÇA:");

            // Lista da classe base contendo objetos das classes derivadas
            List<Veiculo> veiculos = new List<Veiculo>
            {
                new Carro("Toyota", "Corolla", 2022, 4),
                new Moto("Honda", "CB500", 2021, 500),
                new Caminhao("Volvo", "FH", 2020, 10000),
                new Carro("Ford", "Fiesta", 2019, 2),
                new Moto("Yamaha", "MT-07", 2023, 700)
            };

            // Polimorfismo: mesmo método, comportamentos diferentes
            foreach (var veiculo in veiculos)
            {
                veiculo.Ligar();    // Cada um liga de forma diferente
                veiculo.Mover();     // Cada um se move de forma diferente
                veiculo.Descrever(); // Cada um se descreve de forma diferente
                Console.WriteLine();
            }

            // ==================================================================
            // 2. MÉTODOS VIRTUAIS E OVERRIDE
            // ==================================================================
            Console.WriteLine("2. MÉTODOS VIRTUAIS E OVERRIDE:");

            Veiculo v1 = new Carro("Fiat", "Uno", 2015, 4);
            Veiculo v2 = new Moto("Kawasaki", "Ninja", 2022, 600);

            // Chamada polimórfica - runtime decide qual método chamar
            v1.Descrever(); // Chama Carro.Descrever()
            v2.Descrever(); // Chama Moto.Descrever()
            Console.WriteLine();

            // ==================================================================
            // 3. SOBRECARGA DE MÉTODOS (COMPILE-TIME POLYMORPHISM)
            // ==================================================================
            Console.WriteLine("3. SOBRECARGA DE MÉTODOS:");

            Calculadora calc = new Calculadora();

            // Sobrecarga: mesmo nome, parâmetros diferentes
            Console.WriteLine($"Soma int: {calc.Somar(5, 3)}");
            Console.WriteLine($"Soma double: {calc.Somar(5.5, 3.2)}");
            Console.WriteLine($"Soma string: {calc.Somar("Hello", " World")}");
            Console.WriteLine($"Soma 3 números: {calc.Somar(1, 2, 3)}");
            Console.WriteLine();

            // ==================================================================
            // 4. POLIMORFISMO COM INTERFACES
            // ==================================================================
            Console.WriteLine("4. POLIMORFISMO COM INTERFACES:");

            List<IPagamento> pagamentos = new List<IPagamento>
            {
                new PagamentoCartao(),
                new PagamentoBoleto(),
                new PagamentoPix()
            };

            decimal valor = 150.00m;
            foreach (var pagamento in pagamentos)
            {
                pagamento.Processar(valor); // Cada um processa de forma diferente
            }
            Console.WriteLine();

            // ==================================================================
            // 5. MÉTODOS ABSTRATOS E POLIMORFISMO
            // ==================================================================
            Console.WriteLine("5. MÉTODOS ABSTRATOS:");

            List<FormaGeometrica> formas = new List<FormaGeometrica>
            {
                new Circulo(5.0),
                new Retangulo(4.0, 6.0),
                new Triangulo(3.0, 4.0, 5.0)
            };

            foreach (var forma in formas)
            {
                // Polimorfismo: cada forma calcula área de forma diferente
                double area = forma.CalcularArea();
                double perimetro = forma.CalcularPerimetro();

                Console.WriteLine($"{forma.GetType().Name}: Área={area:F2}, Perímetro={perimetro:F2}");
            }
            Console.WriteLine();

            // ==================================================================
            // 6. OPERADORES AS E IS (TYPE CASTING)
            // ==================================================================
            Console.WriteLine("6. OPERADORES AS E IS:");

            foreach (var veiculo in veiculos)
            {
                // Verifica o tipo em tempo de execução
                if (veiculo is Carro carro)
                {
                    carro.AbrirPorta(); // Método específico de Carro
                }
                else if (veiculo is Moto moto)
                {
                    moto.Empinar(); // Método específico de Moto
                }
                else if (veiculo is Caminhao caminhao)
                {
                    caminhao.Carregar(5000); // Método específico de Caminhao
                }
            }
            Console.WriteLine();

            // ==================================================================
            // 7. POLIMORFISMO EM TEMPO DE EXECUÇÃO
            // ==================================================================
            Console.WriteLine("7. POLIMORFISMO EM RUNTIME:");

            Veiculo veiculoPolimorfico;

            // Runtime decision
            Random random = new Random();
            if (random.Next(2) == 0)
            {
                veiculoPolimorfico = new Carro("VW", "Golf", 2021, 4);
            }
            else
            {
                veiculoPolimorfico = new Moto("Ducati", "Monster", 2022, 800);
            }

            // O compilador não sabe qual método será chamado
            veiculoPolimorfico.Ligar(); // Decide em tempo de execução
            veiculoPolimorfico.Mover(); // Decide em tempo de execução
        }
    }

    // ==================================================================
    // INTERFACE PARA POLIMORFISMO
    // ==================================================================
    public interface IPagamento
    {
        void Processar(decimal valor);
        string ObterComprovante();
    }

    public class PagamentoCartao : IPagamento
    {
        public void Processar(decimal valor)
        {
            Console.WriteLine($"Processando pagamento de R$ {valor:F2} via Cartão");
        }

        public string ObterComprovante()
        {
            return "Comprovante de cartão";
        }
    }

    public class PagamentoBoleto : IPagamento
    {
        public void Processar(decimal valor)
        {
            Console.WriteLine($"Gerando boleto de R$ {valor:F2}");
        }

        public string ObterComprovante()
        {
            return "Comprovante de boleto";
        }
    }

    public class PagamentoPix : IPagamento
    {
        public void Processar(decimal valor)
        {
            Console.WriteLine($"Processando PIX de R$ {valor:F2}");
        }

        public string ObterComprovante()
        {
            return "Comprovante de PIX";
        }
    }

    // ==================================================================
    // CLASSE ABSTRATA PARA POLIMORFISMO
    // ==================================================================
    public abstract class FormaGeometrica
    {
        public abstract double CalcularArea();
        public abstract double CalcularPerimetro();

        // Método virtual com implementação padrão
        public virtual void Desenhar()
        {
            Console.WriteLine("Desenhando forma geométrica");
        }
    }

    public class Circulo : FormaGeometrica
    {
        public double Raio { get; }

        public Circulo(double raio)
        {
            Raio = raio;
        }

        public override double CalcularArea()
        {
            return Math.PI * Math.Pow(Raio, 2);
        }

        public override double CalcularPerimetro()
        {
            return 2 * Math.PI * Raio;
        }

        public override void Desenhar()
        {
            Console.WriteLine("Desenhando círculo");
        }
    }

    public class Retangulo : FormaGeometrica
    {
        public double Largura { get; }
        public double Altura { get; }

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

        public override void Desenhar()
        {
            Console.WriteLine("Desenhando retângulo");
        }
    }

    public class Triangulo : FormaGeometrica
    {
        public double LadoA { get; }
        public double LadoB { get; }
        public double LadoC { get; }

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

        public override void Desenhar()
        {
            Console.WriteLine("Desenhando triângulo");
        }
    }

    // ==================================================================
    // SOBRECARGA DE MÉTODOS
    // ==================================================================
    public class Calculadora
    {
        // Sobrecarga: mesmo nome, parâmetros diferentes
        public int Somar(int a, int b)
        {
            return a + b;
        }

        public double Somar(double a, double b)
        {
            return a + b;
        }

        public string Somar(string a, string b)
        {
            return a + b;
        }

        public int Somar(int a, int b, int c)
        {
            return a + b + c;
        }

        public int Somar(params int[] numeros)
        {
            int soma = 0;
            foreach (int num in numeros)
            {
                soma += num;
            }
            return soma;
        }
    }
}