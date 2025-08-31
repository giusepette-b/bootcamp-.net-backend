using System;
using LambdaExplanation; // ❗ Namespace correto

namespace LambdaExplanation // ❗ Mesmo namespace
{
    class Program
    {
        static void Main(string[] args) // ❗ static void Main, não static public void Main
        {
            Console.WriteLine("==============LAMBDAS BASICS==============="); // ❗ WriteLine com L maiúsculo
            Console.WriteLine("1 - Lambdas Basics:");
            LambdaBasics.Demonstrar(); // ❗ Nome da classe correto
        }
    }
}