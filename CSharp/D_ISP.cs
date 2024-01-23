using System;

namespace S.O.L.I.D.CSharp
{
    class D_ISP
    {
        //I - Princípio da segregação de interface: Muitas interfaces específicas são melhores do que uma interface única.
        //ISP - Interface Segregation Principle (Princípio da Segregação da Interface)        
        //Este princípio afirma que as interfaces devem ser segregadas em grupos menores e mais específicos de métodos, em vez de uma única interface grande. 
        //Isso ajuda a evitar que as classes sejam forçadas a implementar métodos que não precisam.


        //Neste exemplo, temos três interfaces segregadas: IScanner, IPrinter e IFax.A classe HPLaserJetPrinter implementa as interfaces IPrinter e IScanner, 
        //enquanto a classe LiquidInkjetPrinter implementa apenas a interface IPrinter. Dessa forma, cada classe implementa apenas os métodos que precisa, 
        //sem ser forçada a implementar métodos desnecessários.

        interface IScanner
        {
            void Scan(string content);
        }

        interface IPrinter
        {
            void Print(string content);
        }

        interface IFax
        {
            void Fax(string content);
        }

        class HPLaserJetPrinter : IPrinter, IScanner
        {
            public void Print(string content)
            {
                Console.WriteLine("Printing...");
            }

            public void Scan(string content)
            {
                Console.WriteLine("Scanning...");
            }
        }

        class LiquidInkjetPrinter : IPrinter
        {
            public void Print(string content)
            {
                Console.WriteLine("Printing...");
            }
        }


        class Program
        {
            static void Main(string[] args)
            {
                IPrinter printer1 = new HPLaserJetPrinter();
                printer1.Print("Hello World!");

                IPrinter printer2 = new LiquidInkjetPrinter();
                printer2.Print("Hello World!");
            }
        }




        //Aqui, a interface ICadastroCliente contém apenas o método Salvar(), que é necessário para armazenar as informações de um cliente.
        //As classes CadastroClienteSqlServer e CadastroClienteOracle implementam a interface ICadastroCliente e fornecem a lógica de salvamento específica do banco de dados.
        //Dessa forma, podemos garantir que cada cliente tenha uma interface específica que contém apenas os métodos necessários, 
        //evitando que os clientes sejam forçados a depender de métodos que não usam.

        public interface ICadastroCliente
        {
            void Salvar(A_SRP.CadastroCliente cliente);
        }

        public class CadastroClienteSqlServer : ICadastroCliente
        {
            public void Salvar(A_SRP.CadastroCliente cliente)
            {
                // Lógica para salvar no SQL Server
            }
        }

        public class CadastroClienteOracle : ICadastroCliente
        {
            public void Salvar(A_SRP.CadastroCliente cliente)
            {
                // Lógica para salvar no Oracle
            }
        }
    }
}
