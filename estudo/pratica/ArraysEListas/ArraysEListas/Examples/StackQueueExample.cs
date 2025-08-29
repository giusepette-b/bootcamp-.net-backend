using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollectionsExamples.Examples
{
    public static class StackQueueExample
    {
        public static void DemonstrarStackQueue()
        {
            Console.WriteLine("⚡ STACKS E QUEUES - Coleções LIFO e FIFO");
            Console.WriteLine("========================================");

            DemonstrarStack();
            Console.WriteLine();
            DemonstrarQueue();
        }

        private static void DemonstrarStack()
        {
            Console.WriteLine("📚 STACK (LIFO - Last In, First Out)");

            Stack<string> historico = new Stack<string>();

            // ✅ Push - Adiciona no topo
            historico.Push("Página Inicial");
            historico.Push("Produtos");
            historico.Push("Carrinho de Compras");

            Console.WriteLine("Stack após pushes:");
            ImprimirStack(historico);

            // ✅ Peek - Visualiza topo sem remover
            string topo = historico.Peek();
            Console.WriteLine($"\nTopo do stack: {topo}");

            // ✅ Pop - Remove e retorna o topo
            string removido = historico.Pop();
            Console.WriteLine($"Removido: {removido}");
            Console.WriteLine("Stack após pop:");
            ImprimirStack(historico);

            // ✅ Exemplo prático: undo/redo
            Stack<string> undoStack = new Stack<string>();
            string textoAtual = "";

            undoStack.Push(textoAtual);
            textoAtual = "Hello";
            undoStack.Push(textoAtual);
            textoAtual = "Hello World";
            undoStack.Push(textoAtual);

            Console.WriteLine("\nSistema de Undo:");
            Console.WriteLine($"Texto atual: {textoAtual}");

            // Undo
            if (undoStack.Count > 1)
            {
                undoStack.Pop(); // Remove estado atual
                textoAtual = undoStack.Peek(); // Pega estado anterior
                Console.WriteLine($"Após undo: {textoAtual}");
            }
        }

        private static void DemonstrarQueue()
        {
            Console.WriteLine("\n📋 QUEUE (FIFO - First In, First Out)");

            Queue<string> filaAtendimento = new Queue<string>();

            // ✅ Enqueue - Adiciona no final
            filaAtendimento.Enqueue("Cliente 1");
            filaAtendimento.Enqueue("Cliente 2");
            filaAtendimento.Enqueue("Cliente 3");

            Console.WriteLine("Fila de atendimento:");
            ImprimirQueue(filaAtendimento);

            // ✅ Peek - Visualiza primeiro sem remover
            string proximo = filaAtendimento.Peek();
            Console.WriteLine($"\nPróximo da fila: {proximo}");

            // ✅ Dequeue - Remove e retorna o primeiro
            string atendido = filaAtendimento.Dequeue();
            Console.WriteLine($"Atendido: {atendido}");
            Console.WriteLine("Fila após dequeue:");
            ImprimirQueue(filaAtendimento);

            // ✅ Exemplo prático: processamento de pedidos
            Queue<Pedido> filaPedidos = new Queue<Pedido>();
            filaPedidos.Enqueue(new Pedido(1, "Produto A"));
            filaPedidos.Enqueue(new Pedido(2, "Produto B"));
            filaPedidos.Enqueue(new Pedido(3, "Produto C"));

            Console.WriteLine("\nProcessando pedidos:");
            while (filaPedidos.Count > 0)
            {
                Pedido pedido = filaPedidos.Dequeue();
                Console.WriteLine($"Processando: {pedido}");
            }
        }

        private static void ImprimirStack<T>(Stack<T> stack)
        {
            foreach (var item in stack)
            {
                Console.WriteLine($"- {item}");
            }
        }

        private static void ImprimirQueue<T>(Queue<T> queue)
        {
            foreach (var item in queue)
            {
                Console.WriteLine($"- {item}");
            }
        }
    }

    public class Pedido
    {
        public int Id { get; set; }
        public string Produto { get; set; }

        public Pedido(int id, string produto)
        {
            Id = id;
            Produto = produto;
        }

        public override string ToString() => $"Pedido {Id}: {Produto}";
    }
}