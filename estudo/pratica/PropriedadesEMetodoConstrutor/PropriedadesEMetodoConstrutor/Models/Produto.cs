using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace PropriedadesEMetodoConstrutor.Model
{
    public class Produto
    {
        // Propriedades auto-implementadas com validação no setter
        public string Nome { get; set; }

        private decimal preco;
        public decimal Preco
        {
            get { return preco; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Preço não pode ser negativo");
                preco = value;
            }
        }

        // Construtor com validação
        public Produto(string nome, decimal preco)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("Nome do produto não pode ser vazio");

            if (preco < 0)
                throw new ArgumentException("Preço não pode ser negativo");

            Nome = nome;
            Preco = preco;
        }

        public void ExibirDetalhes()
        {
            Console.WriteLine($"Produto: {Nome}, Preço: {Preco:C}");
        }
    }
}