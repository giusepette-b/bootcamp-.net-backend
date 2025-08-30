using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PropriedadesEMetodoConstrutor.Model

{
    public class Carro
    {
        // Propriedades auto-implementadas
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int Ano { get; set; }

        // Propriedade somente leitura calculada
        public bool EhNovo
        {
            get { return DateTime.Now.Year - Ano <= 2; }
        }

        // Construtor
        public Carro(string marca, string modelo, int ano)
        {
            Marca = marca;
            Modelo = modelo;
            Ano = ano;
        }
    }
}