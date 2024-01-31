using System;

namespace S.O.L.I.D.CSharp
{
    class B_OCP
    {
        //O - Princípio aberto-fechado: Entidades de software(classes, módulos, funções, etc.) devem estar abertas para extensão, mas fechadas para modificação.
        //OCP - Open-Closed Principle (Princípio Aberto-Fechado)
        //O OCP afirma que as entidades de software (classes, módulos, funções, etc.) devem estar abertas para extensão, mas fechadas para modificação. 
        //Em outras palavras, você deve ser capaz de estender a funcionalidade de uma classe sem precisar modificar o código-fonte original.


        //Nesse exemplo, temos uma classe abstrata Shape que define um método abstrato Area(). As classes Rectangle e Circle herdam da classe Shape e 
        //implementam o método Area() de maneiras diferentes. A classe AreaCalculator é responsável por calcular a área total de uma lista de formas, independentemente do tipo de forma.
        //Observe que a classe AreaCalculator não precisa ser modificada para lidar com novos tipos de formas.Se você quiser adicionar uma nova forma, 
        //basta criar uma nova classe que herda da classe Shape e implementa o método Area(). A classe AreaCalculator pode lidar com essa nova forma sem precisar ser modificada.

        //O modificador override é usado em C# para fornecer uma nova implementação de um método herdado de uma classe base. O método que é substituído 
        //por uma declaração override é conhecido como o método base substituído. O método override deve ter a mesma assinatura que o método base substituído. 
        //Em outras palavras, ele deve ter o mesmo nome, tipo de retorno e lista de parâmetros. O modificador override é necessário para estender ou 
        //modificar a implementação abstrata ou virtual de um método, propriedade, indexador ou evento herdado.
        
        public abstract class Shape
        {
            public abstract double Area();
        }

        public class Rectangle : Shape
        {
            public double Width { get; set; }
            public double Height { get; set; }

            public override double Area()
            {
                return Width * Height;
            }
        }

        public class Circle : Shape
        {
            public double Radius { get; set; }

            public override double Area()
            {
                return Math.PI * Math.Pow(Radius, 2);
            }
        }

        public class AreaCalculator
        {
            public double TotalArea(Shape[] shapes)
            {
                double area = 0;

                foreach (var shape in shapes)
                {
                    area += shape.Area();
                }

                return area;
            }
        }




        //Neste exemplo, temos duas classes que implementam a interface IShape : Rectangle e Circle.A classe AreaCalculator depende da abstração IShape em 
        //vez de uma implementação concreta.Isso permite que a classe AreaCalculator seja facilmente estendida para usar outras implementações de IShape no futuro, 
        //sem precisar modificar o código existente.

        interface IShape
        {
            double Area();
        }

        class Rectangle_baseI : IShape
        {
            public double Width { get; set; }
            public double Height { get; set; }

            public double Area()
            {
                return Width * Height;
            }
        }

        class Circle_baseI : IShape
        {
            public double Radius { get; set; }

            public double Area()
            {
                return Math.PI * Radius * Radius;
            }
        }

        class AreaCalculator_baseI
        {
            public double TotalArea(IShape[] shapes)
            {
                double area = 0;
                foreach (IShape shape in shapes)
                {
                    area += shape.Area();
                }
                return area;
            }
        }

        class Program
        {
            static void Main(string[] args)
            {
                IShape[] shapes = new IShape[] { new Rectangle_baseI { Width = 10, Height = 20 }, new Circle_baseI { Radius = 5 } };
                AreaCalculator_baseI calculator = new AreaCalculator_baseI();
                double totalArea = calculator.TotalArea(shapes);
                Console.WriteLine($"Total area: {totalArea}");
            }
        }




        //Neste exemplo, a classe CadastroCliente é aberta para extensão, mas fechada para modificação.Isso significa que, 
        //se precisarmos adicionar suporte para um novo banco de dados, podemos criar uma nova classe que herda de CadastroCliente e 
        //implementa o método Salvar(). Dessa forma, não precisamos modificar a classe CadastroCliente original.

        public abstract class CadastroCliente
        {
            public string Nome { get; set; }
            public string Email { get; set; }
            public string Telefone { get; set; }
            public string Endereco { get; set; }

            public abstract void Salvar();
        }

        public class CadastroClienteSqlServer : CadastroCliente
        {
            public override void Salvar()
            {
                // Lógica para salvar no SQL Server
            }
        }

        public class CadastroClienteOracle : CadastroCliente
        {
            public override void Salvar()
            {
                // Lógica para salvar no Oracle
            }
        }
    }
}
