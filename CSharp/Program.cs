using System;

namespace S.O.L.I.D
{
    //O que é SOLID?
    //SOLID é um acrônimo criado por Michael Feathers, após observar que cinco princípios da orientação a objetos e design de código 
    //    — Criados por Robert C.Martin(a.k.a.Uncle Bob) e abordados no artigo The Principles of OOD 
    //    — poderiam se encaixar nesta palavra.

    //Esses princípios ajudam o programador a escrever códigos mais limpos, separando responsabilidades, diminuindo acoplamentos, 
    //facilitando na refatoração e estimulando o reaproveitamento do código.

    //SOLID é um acrônimo para cinco princípios da programação orientada a objetos que facilitam no desenvolvimento de softwares, 
    //tornando-os fáceis de manter e estender. Esses princípios podem ser aplicados a qualquer linguagem de POO.


    class Program
    {
        static void Main(string[] args)
        {
            var S = new CSharp.A_SRP();
            var O = new CSharp.B_OCP();
            var L = new CSharp.C_LSP();
            var I = new CSharp.D_ISP();
            var D = new CSharp.E_DIP();

            // The code provided will print ‘Hello S.O.L.I.D’ to the console.
            // Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.
            Console.WriteLine("Hello S.O.L.I.D!");
            Console.ReadKey();

            // Go to http://aka.ms/dotnet-get-started-console to continue learning how to build a console app! 
        }
    }
}
