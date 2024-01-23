using System;
using System.Collections.Generic;

namespace S.O.L.I.D.CSharp
{
    class A_SRP
    {
        //S - Princípio da responsabilidade única: Uma classe deve ter um, e somente um, motivo para mudar.
        //SRP - Single Responsiblity Principle(Princípio da responsabilidade única)
        //Esse princípio declara que uma classe deve ser especializada em um único assunto e possuir apenas uma responsabilidade dentro do software, 
        //ou seja, a classe deve ter uma única tarefa ou ação para executar.


        //Nesse exemplo, a classe Inventory é responsável por gerenciar o estoque de produtos.Ela possui métodos para adicionar e 
        //remover produtos do estoque, bem como um método para obter uma lista de todos os produtos no estoque. A classe Product é 
        //responsável por representar um produto na loja, com propriedades para o nome, preço e quantidade.

        public class Inventory
        {
            private List<Product> products;

            public Inventory()
            {
                products = new List<Product>();
            }

            public void AddProduct(Product product)
            {
                products.Add(product);
            }

            public void RemoveProduct(Product product)
            {
                products.Remove(product);
            }

            public List<Product> GetProducts()
            {
                return products;
            }
        }

        public class Product
        {
            public string Name { get; set; }
            public decimal Price { get; set; }
            public int Quantity { get; set; }
        }



        //Neste exemplo, temos uma classe Order que representa um pedido.A classe OrderProcessor é responsável por processar o pedido.
        //Ao manter a responsabilidade de processar o pedido em uma classe separada, estamos seguindo o Princípio da Responsabilidade Única.
        //Isso torna o código mais fácil de entender e manter.

        class Order
        {
            public int Id { get; set; }
            public string CustomerName { get; set; }
            public decimal Total { get; set; }
        }

        class OrderProcessor
        {
            public void Process(Order order)
            {
                // Process the order here...
                Console.WriteLine($"Order processed: {order.Id}, {order.CustomerName}, {order.Total}");
            }
        }

        class Program
        {
            static void Main(string[] args)
            {
                Order order = new Order { Id = 1, CustomerName = "John Doe", Total = 100.00m };
                OrderProcessor processor = new OrderProcessor();
                processor.Process(order);
            }
        }




        //Neste exemplo, a classe CadastroCliente tem apenas uma responsabilidade: armazenar as informações de um cliente.Isso significa que, 
        //se precisarmos alterar a forma como as informações são armazenadas, não precisamos alterar outras partes do código que não estão relacionadas a essa responsabilidade.

        public class CadastroCliente
        {
            public string Nome { get; set; }
            public string Email { get; set; }
            public string Telefone { get; set; }
            public string Endereco { get; set; }
        }
    }
}
