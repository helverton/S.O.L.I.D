﻿using System;

namespace S.O.L.I.D.CSharp
{
    class E_DIP
    {
        //D - Princípio da inversão da dependência: Dependa de abstrações, não de implementações.
        //DIP - Dependency Inversion Principle (Princípio da inversão da dependência)
        //Este princípio afirma que módulos de alto nível não devem depender de módulos de baixo nível.Ambos devem depender de abstrações. 
        //Além disso, abstrações não devem depender de detalhes. Detalhes devem depender de abstrações.
        //Isso ajuda a manter os módulos de alto e baixo nível desacoplados e facilita a manutenção do código.


        //Neste exemplo, temos duas classes de implementação de ILogger: FileLogger e ConsoleLogger. A classe OrderProcessor depende da abstração ILogger em vez 
        //de uma implementação concreta. Isso permite que a classe OrderProcessor seja facilmente estendida para usar outras implementações de ILogger no futuro, 
        //sem precisar modificar o código existente.

        interface ILogger
        {
            void Log(string message);
        }

        class FileLogger : ILogger
        {
            public void Log(string message)
            {
                Console.WriteLine($"Logging to file: {message}");
            }
        }

        class ConsoleLogger : ILogger
        {
            public void Log(string message)
            {
                Console.WriteLine($"Logging to console: {message}");
            }
        }

        class OrderProcessor
        {
            private readonly ILogger _logger;

            public OrderProcessor(ILogger logger)
            {
                _logger = logger;
            }

            public void Process(Order order)
            {
                // Process the order here...
                _logger.Log($"Order processed: {order}");
            }
        }

        class Order
        {
            public int Id { get; set; }
            public string CustomerName { get; set; }
        }

        class Program
        {
            static void Main(string[] args)
            {
                ILogger logger = new ConsoleLogger();
                OrderProcessor processor = new OrderProcessor(logger);

                Order order = new Order { Id = 1, CustomerName = "John Doe" };
                processor.Process(order);
            }
        }




        //Aqui, a classe CadastroCliente é a classe de alto nível e as classes CadastroClienteSqlServerRepository e 
        //CadastroClienteOracleRepository são classes de baixo nível.A interface ICadastroClienteRepository é uma abstração que 
        //contém o método Salvar(), que é necessário para salvar as informações de um cliente.A classe CadastroClienteService é 
        //responsável por salvar as informações do cliente e depende da interface ICadastroClienteRepository em vez de depender diretamente das classes de baixo nível.

        //Dessa forma, podemos garantir que as classes de alto nível não dependam das classes de baixo nível, mas sim de abstrações.

        public class CadastroCliente
        {
            public string Nome { get; set; }
            public string Email { get; set; }
            public string Telefone { get; set; }
            public string Endereco { get; set; }
        }

        public interface ICadastroClienteRepository
        {
            void Salvar(CadastroCliente cliente);
        }

        public class CadastroClienteService
        {
            private readonly ICadastroClienteRepository _cadastroClienteRepository;

            public CadastroClienteService(ICadastroClienteRepository cadastroClienteRepository)
            {
                _cadastroClienteRepository = cadastroClienteRepository;
            }

            public void Salvar(CadastroCliente cliente)
            {
                _cadastroClienteRepository.Salvar(cliente);
            }
        }

        public class CadastroClienteSqlServerRepository : ICadastroClienteRepository
        {
            public void Salvar(CadastroCliente cliente)
            {
                // Lógica para salvar no SQL Server
            }
        }

        public class CadastroClienteOracleRepository : ICadastroClienteRepository
        {
            public void Salvar(CadastroCliente cliente)
            {
                // Lógica para salvar no Oracle
            }
        }



        //Neste exemplo, a classe CustomerRegistration depende da interface IEmailSender em vez de uma implementação concreta.
        //Isso permite que a classe CustomerRegistration seja desacoplada da implementação específica de envio de e-mail e, portanto, 
        //seja mais flexível e fácil de testar.A implementação real do envio de e-mail é injetada na classe CustomerRegistration por 
        //meio do construtor, seguindo o princípio de inversão de dependência.
        public interface IEmailSender
        {
            void SendEmail(string toAddress, string subject, string body);
        }

        public class EmailSender : IEmailSender
        {
            public void SendEmail(string toAddress, string subject, string body)
            {
                // Implementação do envio de e-mail
            }
        }

        public class CustomerRegistration
        {
            private readonly IEmailSender _emailSender;

            public CustomerRegistration(IEmailSender emailSender)
            {
                _emailSender = emailSender;
            }

            public void RegisterCustomer()
            {
                // Lógica de registro do cliente

                // Envio de e-mail
                _emailSender.SendEmail("to@example.com", "Subject", "Body");
            }
        }
    }
}
