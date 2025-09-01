using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ClassesAbstratasInterfaces.Models
{
    public static class ClassesAbstratas
    {
        public static void Demonstrar()
        {
            Console.WriteLine("=== CLASSES ABSTRATAS: DEFINIÇÃO DE COMPORTAMENTO ===\n");

            // ==================================================================
            // 1. CONCEITO DE CLASSE ABSTRATA
            // ==================================================================
            Console.WriteLine("1. CONCEITO DE CLASSE ABSTRATA:");
            Console.WriteLine("   • Não pode ser instanciada diretamente");
            Console.WriteLine("   • Serve como base para outras classes");
            Console.WriteLine("   • Pode conter métodos abstratos (sem implementação)");
            Console.WriteLine("   • Pode conter métodos concretos (com implementação)");
            Console.WriteLine("   • Define um contrato que as classes filhas devem seguir");
            Console.WriteLine();

            // ==================================================================
            // 2. INSTANCIAÇÃO DE CLASSES CONCRETAS
            // ==================================================================
            Console.WriteLine("2. INSTANCIAÇÃO DE CLASSES CONCRETAS:");

            // ❌ NÃO É POSSÍVEL: Instanciar classe abstrata diretamente
            // var forma = new FormaGeometrica(); // Erro de compilação!

            // ✅ CORRETO: Instanciar classes concretas que herdam da abstrata
            FormaGeometrica circulo = new Circulo(5.0);
            FormaGeometrica retangulo = new Retangulo(4.0, 6.0);
            FormaGeometrica triangulo = new Triangulo(3.0, 4.0, 5.0);

            Console.WriteLine("Formas geométricas criadas:");
            Console.WriteLine($"- Círculo com raio 5.0");
            Console.WriteLine($"- Retângulo 4.0x6.0");
            Console.WriteLine($"- Triângulo 3.0/4.0/5.0");
            Console.WriteLine();

            // ==================================================================
            // 3. MÉTODOS ABSTRATOS - IMPLEMENTAÇÃO OBRIGATÓRIA
            // ==================================================================
            Console.WriteLine("3. MÉTODOS ABSTRATOS (IMPLEMENTAÇÃO OBRIGATÓRIA):");

            List<FormaGeometrica> formas = new List<FormaGeometrica> { circulo, retangulo, triangulo };

            foreach (var forma in formas)
            {
                // ✅ Cada classe implementa os métodos abstratos de forma diferente
                double area = forma.CalcularArea(); // Método abstrato implementado
                double perimetro = forma.CalcularPerimetro(); // Método abstrato implementado

                Console.WriteLine($"{forma.GetType().Name}:");
                Console.WriteLine($"  Área: {area:F2}");
                Console.WriteLine($"  Perímetro: {perimetro:F2}");
            }
            Console.WriteLine();

            // ==================================================================
            // 4. MÉTODOS CONCRETOS NA CLASSE ABSTRATA
            // ==================================================================
            Console.WriteLine("4. MÉTODOS CONCRETOS (IMPLEMENTAÇÃO NA CLASSE BASE):");

            foreach (var forma in formas)
            {
                // ✅ Método concreto - já implementado na classe abstrata
                forma.ExibirInformacoes();
            }
            Console.WriteLine();

            // ==================================================================
            // 5. SOBRESCRITA DE MÉTODOS VIRTUAIS
            // ==================================================================
            Console.WriteLine("5. SOBRESCRITA DE MÉTODOS VIRTUAIS:");

            foreach (var forma in formas)
            {
                // ✅ Método virtual - pode ser sobrescrito pelas classes filhas
                forma.Desenhar();
            }
            Console.WriteLine();

            // ==================================================================
            // 6. PROPRIEDADES ABSTRATAS
            // ==================================================================
            Console.WriteLine("6. PROPRIEDADES ABSTRATAS:");

            foreach (var forma in formas)
            {
                // ✅ Propriedade abstrata - implementada pelas classes filhas
                Console.WriteLine($"{forma.GetType().Name}: {forma.Nome}");
            }
            Console.WriteLine();

            // ==================================================================
            // 7. HERANÇA MULTINÍVEL COM CLASSES ABSTRATAS
            // ==================================================================
            Console.WriteLine("7. HERANÇA MULTINÍVEL:");

            Animal cachorro = new Cachorro("Rex", 3);
            Animal gato = new Gato("Mimi", 2);

            cachorro.EmitirSom(); // ✅ Implementação da classe concreta
            gato.EmitirSom();     // ✅ Implementação da classe concreta

            // ✅ Métodos concretos da classe abstrata intermediária
            ((Mamifero)cachorro).Amamentar();
            ((Mamifero)gato).Amamentar();
            Console.WriteLine();

            // ==================================================================
            // 8. CONSTRUTORES EM CLASSES ABSTRATAS
            // ==================================================================
            Console.WriteLine("8. CONSTRUTORES EM CLASSES ABSTRATAS:");

            // ✅ Construtores de classes abstratas são chamados pelas classes filhas
            Console.WriteLine("Construtores das classes abstratas são executados durante a instanciação das classes concretas");
            Console.WriteLine();

            // ==================================================================
            // 9. CLASSES ABSTRATAS VS INTERFACES
            // ==================================================================
            Console.WriteLine("9. CLASSES ABSTRATAS VS INTERFACES:");
            Console.WriteLine("   ✅ Classe Abstrata: Herança única, pode ter implementação");
            Console.WriteLine("   ✅ Interface: Implementação múltipla, apenas contrato");
            Console.WriteLine("   ✅ Use classes abstratas para relacionamento 'é-um'");
            Console.WriteLine("   ✅ Use interfaces para definir comportamentos");
        }
    }

    // ==================================================================
    // CLASSE ABSTRATA BASE - FORMA GEOMÉTRICA
    // ==================================================================
    public abstract class FormaGeometrica
    {
        // PROPRIEDADE ABSTRATA - deve ser implementada pelas classes derivadas
        public abstract string Nome { get; }

        // MÉTODO ABSTRATO - sem implementação, deve ser implementado pelas derivadas
        public abstract double CalcularArea();

        // MÉTODO ABSTRATO - sem implementação, deve ser implementado pelas derivadas
        public abstract double CalcularPerimetro();

        // MÉTODO VIRTUAL - possui implementação padrão, pode ser sobrescrito
        public virtual void Desenhar()
        {
            Console.WriteLine($"Desenhando {Nome}...");
        }

        // MÉTODO CONCRETO - implementação completa na classe abstrata
        public void ExibirInformacoes()
        {
            Console.WriteLine($"=== {Nome.ToUpper()} ===");
            Console.WriteLine($"Área: {CalcularArea():F2}");
            Console.WriteLine($"Perímetro: {CalcularPerimetro():F2}");
        }

        // MÉTODO ESTÁTICO - pertence à classe, não às instâncias
        public static void ExibirFormulaArea()
        {
            Console.WriteLine("Fórmula de área varia conforme a forma geométrica");
        }
    }

    // ==================================================================
    // CLASSE CONCRETA - CÍRCULO (HERDA DA ABSTRATA)
    // ==================================================================
    public class Circulo : FormaGeometrica
    {
        public double Raio { get; }

        // Implementação da propriedade abstrata
        public override string Nome => "Círculo";

        public Circulo(double raio)
        {
            Raio = raio;
        }

        // Implementação do método abstrato
        public override double CalcularArea()
        {
            return Math.PI * Math.Pow(Raio, 2);
        }

        // Implementação do método abstrato
        public override double CalcularPerimetro()
        {
            return 2 * Math.PI * Raio;
        }

        // Sobrescrita do método virtual
        public override void Desenhar()
        {
            Console.WriteLine($"Desenhando círculo com raio {Raio:F2}...");
        }

        // Método específico da classe Círculo
        public double CalcularDiametro()
        {
            return 2 * Raio;
        }
    }

    // ==================================================================
    // CLASSE CONCRETA - RETÂNGULO (HERDA DA ABSTRATA)
    // ==================================================================
    public class Retangulo : FormaGeometrica
    {
        public double Largura { get; }
        public double Altura { get; }

        // Implementação da propriedade abstrata
        public override string Nome => "Retângulo";

        public Retangulo(double largura, double altura)
        {
            Largura = largura;
            Altura = altura;
        }

        // Implementação do método abstrato
        public override double CalcularArea()
        {
            return Largura * Altura;
        }

        // Implementação do método abstrato
        public override double CalcularPerimetro()
        {
            return 2 * (Largura + Altura);
        }

        // Método específico da classe Retangulo
        public bool EhQuadrado()
        {
            return Largura == Altura;
        }
    }

    // ==================================================================
    // CLASSE CONCRETA - TRIÂNGULO (HERDA DA ABSTRATA)
    // ==================================================================
    public class Triangulo : FormaGeometrica
    {
        public double LadoA { get; }
        public double LadoB { get; }
        public double LadoC { get; }

        // Implementação da propriedade abstrata
        public override string Nome => "Triângulo";

        public Triangulo(double ladoA, double ladoB, double ladoC)
        {
            LadoA = ladoA;
            LadoB = ladoB;
            LadoC = ladoC;
        }

        // Implementação do método abstrato
        public override double CalcularArea()
        {
            // Fórmula de Herão
            double s = (LadoA + LadoB + LadoC) / 2;
            return Math.Sqrt(s * (s - LadoA) * (s - LadoB) * (s - LadoC));
        }

        // Implementação do método abstrato
        public override double CalcularPerimetro()
        {
            return LadoA + LadoB + LadoC;
        }

        // Método específico da classe Triangulo
        public string TipoTriangulo()
        {
            if (LadoA == LadoB && LadoB == LadoC) return "Equilátero";
            if (LadoA == LadoB || LadoA == LadoC || LadoB == LadoC) return "Isósceles";
            return "Escaleno";
        }
    }

    // ==================================================================
    // HERANÇA MULTINÍVEL COM CLASSE ABSTRATA INTERMEDIÁRIA
    // ==================================================================
    public abstract class Animal
    {
        public string Nome { get; }
        public int Idade { get; }

        protected Animal(string nome, int idade)
        {
            Nome = nome;
            Idade = idade;
        }

        // Método abstrato - deve ser implementado pelas classes finais
        public abstract void EmitirSom();

        // Método concreto - implementação padrão
        public void Dormir()
        {
            Console.WriteLine($"{Nome} está dormindo...");
        }
    }

    public abstract class Mamifero : Animal
    {
        protected Mamifero(string nome, int idade) : base(nome, idade) { }

        // Método abstrato adicional
        public abstract void Amamentar();

        // Método concreto na classe abstrata intermediária
        public void Correr()
        {
            Console.WriteLine($"{Nome} está correndo...");
        }
    }

    public class Cachorro : Mamifero
    {
        public Cachorro(string nome, int idade) : base(nome, idade) { }

        // Implementação do método abstrato da classe Animal
        public override void EmitirSom()
        {
            Console.WriteLine($"{Nome} diz: Au au!");
        }

        // Implementação do método abstrato da classe Mamifero
        public override void Amamentar()
        {
            Console.WriteLine($"{Nome} está amamentando seus filhotes");
        }

        // Método específico da classe Cachorro
        public void AbanarRabo()
        {
            Console.WriteLine($"{Nome} está abanando o rabo!");
        }
    }

    public class Gato : Mamifero
    {
        public Gato(string nome, int idade) : base(nome, idade) { }

        public override void EmitirSom()
        {
            Console.WriteLine($"{Nome} diz: Miau!");
        }

        public override void Amamentar()
        {
            Console.WriteLine($"{Nome} está amamentando seus gatinhos");
        }

        // Método específico da classe Gato
        public void ArranharMoveis()
        {
            Console.WriteLine($"{Nome} está arranhando os móveis!");
        }
    }
}