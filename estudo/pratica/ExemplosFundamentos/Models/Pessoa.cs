using System; // para que métodos nao fiquem dentro de namespaces. Métodos devem estar dentro de classes


namespace ExemplosFundamentos.Models // por convenção, se usa o local do diretório para namespace (faz bastante sentido)
{
    public class Pessoa
    {
        public string Nome { get; set; } = string.Empty; // Público - acessível de qualquer lugar
        public int Idade { get; set; } // Público - acessível de qualquer lugar
        protected bool IsAdult { get; set; } // Protegido - acessível apenas na classe e herdeiras
        private int CPF { get; set; } // Privado - acessível apenas na própria classe

        public void Apresentar()
        {
            // CPF é acessível aqui porque está dentro da própria classe
            Console.WriteLine($"Nome: {Nome}, Idade: {Idade}, Adulto: {IsAdult}, CPF: {CPF}"); // Essa é a sintaxe do Template String
        }
    }
    // public class Program
    // {
    //     public static void Main(string[] args) // o método Main está dentro do método program. 
    //     {
    //         Pessoa pessoa1 = new Pessoa();
    //         pessoa1.Nome = "teste";
    //         pessoa1.Idade = 25; // exemplo de valor
    //         pessoa1.Apresentar();
    //     }
    // }
    // // retorno
    // /home/giusepette/Documentos/bootcamp-.net-api-ai/estudo/pratica/exmplos-fundamentos/Program.cs(7,23): warning CS8618: O propriedade não anulável 'Nome' precisa conter um valor não nulo ao sair do construtor. Considere adicionar o modificador "obrigatório" ou declarar o propriedade como anulável. [/home/giusepette/Documentos/bootcamp-.net-api-ai/estudo/pratica/exmplos-fundamentos/exmplos-fundamentos.csproj]
    // Nome: teste, Idade: 25, Adulto: False, CPF: 0
}
// auto increment de classe
// public class Pessoa
// {
//     // ... propriedades anteriores ...

//     // Construtor personalizado
//     public Pessoa(string nome, int idade)
//     {
//         Nome = nome;
//         Idade = idade;
//         IsAdult = idade >= 18;
//         CPF = 0; // Valor padrão
//     }

//     // Construtor padrão (vazio)
//     public Pessoa() { }
// }