using System;
using TuplasOperadorTernarioDesconstrucaoDeObjeto.Models;

namespace TuplasOperadorTernarioDesconstrucaoDeObjeto
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== TUPLAS, OPERADOR TERNÁRIO E DESCONSTRUÇÃO ===\n");

            // 1. Tuplas
            Console.WriteLine("1. TUPLAS:");
            Tuplas.Demonstrar();
            Console.WriteLine();

            // 2. Operador Ternário
            Console.WriteLine("2. OPERADOR TERNÁRIO:");
            OperadorTernario.Demonstrar();
            Console.WriteLine();

            // 3. Desconstrução de Objetos
            Console.WriteLine("3. DESCONSTRUÇÃO DE OBJETOS:");
            Desconstrucao.Demonstrar();

            // 4. Tuplas com métodos (delegates)
            Console.WriteLine("4. TUPLAS COM MÉTODOS:");
            TuplasComMetodos.Demonstrar();
        }
    }
}

// === TUPLAS, OPERADOR TERNÁRIO E DESCONSTRUÇÃO ===

// 1. TUPLAS:
// === TUPLAS EM C# ===

// 1. Tupla simples: Nome: João, Idade: 30
// 2. Tupla nomeada: Nome: Maria, Idade: 25
// 3. Tupla com var: Pedro, 35, Ativo: True
// 4. Método com tupla: Média: 30, Soma: 150, Maior: 50
// 5. Deconstrução direta: Média: 15, Soma: 45, Maior: 25
// 6. Comparação: tupla1 == tupla2: True
//    Comparação: tupla1 == tupla3: False

// 7. Lista de tuplas:
//    - Ana (28 anos)
//    - Carlos (32 anos)
//    - Beatriz (41 anos)

// 8. Dicionário com tuplas:
//    TI: João Silva - 15 func.
//    RH: Maria Santos - 8 func.
//    Vendas: Pedro Costa - 12 func.

// 9. Tupla complexa: Notebook - R$ 2.500,99 - Estoque: 15
// 10. Desconstrução: Nome: Luiz, Idade: 45, Ativo: False
// 11. Desconstrução parcial: Apenas Ativo: True

// 2. OPERADOR TERNÁRIO:
// === OPERADOR TERNÁRIO EM C# ===

// 1. Básico - Idade: 20, Status: Maior de idade
// 2. Numérico - Preço: R$ 100,00, Desconto: R$ 10,00
// 3. Aninhado - Nota: 85, Conceito: B
// 4. Com métodos - Bem-vindo usuário Premium!
// 5. Atribuição - Saudação: Olá, Visit...!
// 6. Expressão - Total: R$ 75,00, Com desconto: R$ 67,50
// 7. Tipos diferentes - Resultado: Aprovado (String)
// 8. Comparação - 10 é Par e Positivo
// 9. Inicialização - Modo: Dia, Tema: Claro

// 💡 BOAS PRÁTICAS:
//    • Use ternário para condições SIMPLES
//    • Evite ternários aninhados complexos
//    • Prefira if-else para lógica complexa
//    • Mantenha a legibilidade acima de tudo

// 3. DESCONSTRUÇÃO DE OBJETOS:
// === DESCONSTRUÇÃO DE OBJETOS EM C# ===

// 1. Desconstrução de tupla: Nome: Carlos, Idade: 30
// 2. Desconstrução de objeto: Ana Silva, 25 anos
// 3. Desconstrução parcial: Apenas nome: Ana
// 4. Desconstrução de método: Sucesso: True, Mensagem: Operação concluída com sucesso

// 5. Desconstrução em loop:
//    - João Santos (35 anos)
//    - Maria Oliveira (28 anos)
//    - Pedro Costa (42 anos)

// 6. Desconstrução de dicionário:
//    Maçã: 10 unidades
//    Banana: 15 unidades
//    Laranja: 8 unidades

// 7. Primeira sobrecarga: Notebook - R$ 2.500,99
//    Segunda sobrecarga: Notebook - R$ 2.500,99 - Eletrônicos

// 8. Estatísticas: Média: 20, Soma: 60, Maior: 30, Menor: 10
// 9. Pattern matching: Beatriz Rocha - 31 anos

// 🎯 CASOS DE USO PRÁTICOS:
//    • Retorno múltiplo de métodos
//    • Processamento de dados em lotes
//    • Manipulação de resultados de APIs
//    • Simplificação de código com objetos complexos