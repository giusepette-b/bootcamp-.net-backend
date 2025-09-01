using System;
using System.Collections.Generic;

namespace HerancaPolimorfismo.Models
{
    public static class ExemploIntegrado
    {
        public static void Demonstrar()
        {
            Console.WriteLine("=== EXEMPLO INTEGRADO: SISTEMA DE FUNCIONÁRIOS ===\n");

            // ==================================================================
            // 1. HERANÇA: HIERARQUIA DE FUNCIONÁRIOS
            // ==================================================================
            List<Funcionario> funcionarios = new List<Funcionario>
            {
                new Gerente("João Silva", 5000, "Vendas", 2000),
                new Desenvolvedor("Maria Santos", 4000, "C#", "Sênior"),
                new Analista("Pedro Costa", 3500, "Business Intelligence"),
                new Estagiario("Ana Oliveira", 1500, "Desenvolvimento", 6),
                new Desenvolvedor("Carlos Lima", 4500, "Java", "Pleno")
            };

            // ==================================================================
            // 2. POLIMORFISMO: MÉTODOS VIRTUAIS E OVERRIDE
            // ==================================================================
            Console.WriteLine("FOLHA DE PAGAMENTO:");
            Console.WriteLine("===================");

            foreach (var funcionario in funcionarios)
            {
                // Polimorfismo: mesmo método, comportamentos diferentes
                funcionario.Trabalhar();       // Cada um trabalha diferente
                funcionario.ReceberSalario();  // Cada um recebe diferente

                // Método abstrato - implementação obrigatória
                double bonus = funcionario.CalcularBonus();
                Console.WriteLine($"Bônus: R$ {bonus:F2}");

                // Verificação de tipo para métodos específicos
                if (funcionario is Gerente gerente)
                {
                    gerente.GerenciarEquipe();
                }
                else if (funcionario is Desenvolvedor dev)
                {
                    dev.Codificar();
                }
                else if (funcionario is Estagiario estagiario)
                {
                    estagiario.Aprender();
                }

                Console.WriteLine("---");
            }

            // ==================================================================
            // 3. HERANÇA MULTINÍVEL E PROPRIEDADES PROTEGIDAS
            // ==================================================================
            Console.WriteLine("\nINFORMAÇÕES DETALHADAS:");
            Console.WriteLine("======================");

            foreach (var funcionario in funcionarios)
            {
                // Acesso às propriedades através de métodos públicos
                funcionario.ExibirInformacoes();

                // Uso de operador is para type checking
                if (funcionario is IFuncionarioComissionado comissionado)
                {
                    comissionado.AdicionarVenda(10000);
                    Console.WriteLine($"Comissão: R$ {comissionado.CalcularComissao():F2}");
                }

                Console.WriteLine();
            }

            // ==================================================================
            // 4. POLIMORFISMO EM COLETÂNEAS - CORRIGIDO
            // ==================================================================
            Console.WriteLine("TOTAL DA FOLHA:");
            Console.WriteLine("===============");

            double totalFolha = 0;
            double totalBonus = 0;

            foreach (var funcionario in funcionarios)
            {
                // ✅ CORREÇÃO: Usar método público para acessar salário
                totalFolha += funcionario.ObterSalarioBase();
                totalBonus += funcionario.CalcularBonus();
            }

            Console.WriteLine($"Salários: R$ {totalFolha:F2}");
            Console.WriteLine($"Bônus: R$ {totalBonus:F2}");
            Console.WriteLine($"Total: R$ {totalFolha + totalBonus:F2}");
        }
    }

    // ==================================================================
    // CLASSE BASE ABSTRATA
    // ==================================================================
    public abstract class Funcionario
    {
        // ✅ CORREÇÃO: Alterado para private e adicionado método de acesso
        private string _nome;
        private double _salarioBase;

        // Construtor protegido - só pode ser chamado pelas classes derivadas
        protected Funcionario(string nome, double salarioBase)
        {
            _nome = nome;
            _salarioBase = salarioBase;
        }

        // ✅ CORREÇÃO: Método público para acessar salário base
        public double ObterSalarioBase() => _salarioBase;
        public string ObterNome() => _nome;

        // Método abstrato - deve ser implementado pelas classes derivadas
        public abstract double CalcularBonus();

        // Método virtual - pode ser sobrescrito
        public virtual void Trabalhar()
        {
            Console.WriteLine($"{_nome} está trabalhando");
        }

        // Método virtual - pode ser sobrescrito
        public virtual void ReceberSalario()
        {
            Console.WriteLine($"{_nome} recebeu R$ {_salarioBase:F2}");
        }

        // Método para exibir informações
        public virtual void ExibirInformacoes()
        {
            Console.WriteLine($"{GetType().Name}: {_nome}");
            Console.WriteLine($"Salário base: R$ {_salarioBase:F2}");
            Console.WriteLine($"Bônus: R$ {CalcularBonus():F2}");
        }
    }

    // ==================================================================
    // INTERFACE PARA FUNCIONÁRIOS COMISSIONADOS
    // ==================================================================
    public interface IFuncionarioComissionado
    {
        void AdicionarVenda(double valorVenda);
        double CalcularComissao();
    }

    // ==================================================================
    // CLASSE DERIVADA - GERENTE
    // ==================================================================
    public class Gerente : Funcionario, IFuncionarioComissionado
    {
        public string Departamento { get; set; }
        public double BonusGerencia { get; set; }
        private double _totalVendas;

        public Gerente(string nome, double salarioBase, string departamento, double bonusGerencia)
            : base(nome, salarioBase)
        {
            Departamento = departamento;
            BonusGerencia = bonusGerencia;
            _totalVendas = 0;
        }

        // Implementação do método abstrato
        public override double CalcularBonus()
        {
            return ObterSalarioBase() * 0.2 + BonusGerencia + (_totalVendas * 0.05);
        }

        // Sobrescreve método virtual
        public override void Trabalhar()
        {
            Console.WriteLine($"{ObterNome()} está gerenciando o departamento {Departamento}");
        }

        // Método específico de Gerente
        public void GerenciarEquipe()
        {
            Console.WriteLine($"{ObterNome()} está gerenciando a equipe");
        }

        // Implementação da interface
        public void AdicionarVenda(double valorVenda)
        {
            _totalVendas += valorVenda;
            Console.WriteLine($"Venda de R$ {valorVenda:F2} adicionada");
        }

        public double CalcularComissao()
        {
            return _totalVendas * 0.05;
        }

        // Sobrescreve método de exibição
        public override void ExibirInformacoes()
        {
            base.ExibirInformacoes();
            Console.WriteLine($"Departamento: {Departamento}");
            Console.WriteLine($"Total vendas: R$ {_totalVendas:F2}");
        }
    }

    // ==================================================================
    // CLASSE DERIVADA - DESENVOLVEDOR
    // ==================================================================
    public class Desenvolvedor : Funcionario
    {
        public string Linguagem { get; set; }
        public string Nivel { get; set; }

        public Desenvolvedor(string nome, double salarioBase, string linguagem, string nivel)
            : base(nome, salarioBase)
        {
            Linguagem = linguagem;
            Nivel = nivel;
        }

        public override double CalcularBonus()
        {
            double bonusNivel = Nivel.ToLower() switch
            {
                "júnior" => ObterSalarioBase() * 0.1,
                "pleno" => ObterSalarioBase() * 0.15,
                "sênior" => ObterSalarioBase() * 0.2,
                _ => ObterSalarioBase() * 0.05
            };

            return bonusNivel;
        }

        public override void Trabalhar()
        {
            Console.WriteLine($"{ObterNome()} está desenvolvendo em {Linguagem}");
        }

        // Método específico de Desenvolvedor
        public void Codificar()
        {
            Console.WriteLine($"{ObterNome()} está codificando funcionalidades");
        }

        public override void ExibirInformacoes()
        {
            base.ExibirInformacoes();
            Console.WriteLine($"Linguagem: {Linguagem}");
            Console.WriteLine($"Nível: {Nivel}");
        }
    }

    // ==================================================================
    // CLASSE DERIVADA - ANALISTA
    // ==================================================================
    public class Analista : Funcionario
    {
        public string Especialidade { get; set; }

        public Analista(string nome, double salarioBase, string especialidade)
            : base(nome, salarioBase)
        {
            Especialidade = especialidade;
        }

        public override double CalcularBonus()
        {
            return ObterSalarioBase() * 0.12;
        }

        public override void Trabalhar()
        {
            Console.WriteLine($"{ObterNome()} está analisando {Especialidade}");
        }

        public override void ExibirInformacoes()
        {
            base.ExibirInformacoes();
            Console.WriteLine($"Especialidade: {Especialidade}");
        }
    }

    // ==================================================================
    // CLASSE DERIVADA - ESTAGIARIO
    // ==================================================================
    public class Estagiario : Funcionario
    {
        public string Departamento { get; set; }
        public int MesesContrato { get; set; }

        public Estagiario(string nome, double salarioBase, string departamento, int mesesContrato)
            : base(nome, salarioBase)
        {
            Departamento = departamento;
            MesesContrato = mesesContrato;
        }

        public override double CalcularBonus()
        {
            // Estagiários não recebem bônus
            return 0;
        }

        public override void Trabalhar()
        {
            Console.WriteLine($"{ObterNome()} está estagiando no departamento {Departamento}");
        }

        public override void ReceberSalario()
        {
            Console.WriteLine($"{ObterNome()} recebeu bolsa-auxílio de R$ {ObterSalarioBase():F2}");
        }

        // Método específico de Estagiario
        public void Aprender()
        {
            Console.WriteLine($"{ObterNome()} está aprendendo e ganhando experiência");
        }

        public override void ExibirInformacoes()
        {
            base.ExibirInformacoes();
            Console.WriteLine($"Departamento: {Departamento}");
            Console.WriteLine($"Contrato: {MesesContrato} meses");
        }
    }
}