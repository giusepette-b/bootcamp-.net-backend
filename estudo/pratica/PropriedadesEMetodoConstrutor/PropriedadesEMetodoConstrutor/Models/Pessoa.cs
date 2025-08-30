using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PropriedadesEMetodoConstrutor.Model
{
    public class Pessoa
    {
        // Campos privados
        private string nome;
        private int idade;

        // Propriedades com getters e setters
        public string Nome
        {
            get { return nome; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Nome não pode ser vazio");
                nome = value;
            }
        }

        public int Idade
        {
            get { return idade; }
            set
            {
                if (value < 0 || value > 150)
                    throw new ArgumentException("Idade deve estar entre 0 e 150");
                idade = value;
            }
        }

        // Construtor padrão
        public Pessoa()
        {
            nome = "Não definido";
            idade = 0;
        }

        // Construtor com parâmetros
        public Pessoa(string nome, int idade)
        {
            Nome = nome;
            Idade = idade;
        }

        // Construtor de cópia
        public Pessoa(Pessoa outraPessoa)
        {
            Nome = outraPessoa.Nome;
            Idade = outraPessoa.Idade;
        }

        public void ExibirInformacoes()
        {
            Console.WriteLine($"Nome: {Nome}, Idade: {Idade}");
        }
    }
}