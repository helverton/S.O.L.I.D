using System;

namespace S.O.L.I.D.CSharp
{
    class C_LSP
    {
        //L - Princípio da substituição de Liskov: Se uma classe S é um subtipo de uma classe T, então objetos do tipo T podem ser substituídos por objetos do tipo S sem afetar a corretude do programa.
        //LSP - Liskov Substitution Principle (Princípio da substituição de Liskov)
        //O Princípio da Substituição de Liskov (LSP) é um princípio importante que ajuda a criar código robusto e flexível. O LSP afirma que se uma classe S é um subtipo de uma classe T, 
        //então objetos do tipo T podem ser substituídos por objetos do tipo S sem afetar a corretude do programa.


        //Nesse exemplo, temos uma classe abstrata Animal que define um método virtual MakeSound(). As classes Dog e Cat herdam da classe Animal e implementam o método MakeSound() 
        //de maneiras diferentes.A classe AnimalSound é responsável por reproduzir o som de um animal, independentemente do tipo de animal.
        //Observe que a classe AnimalSound não precisa saber qual tipo de animal está sendo reproduzido.Ela simplesmente chama o método MakeSound() do objeto Animal passado como parâmetro.
        //Isso significa que podemos passar um objeto Dog ou Cat para o método PlaySound() sem afetar a corretude do programa.

        public class Animal
        {
            public virtual void MakeSound()
            {
                Console.WriteLine("The animal makes a sound");
            }
        }

        public class Dog : Animal
        {
            public override void MakeSound()
            {
                Console.WriteLine("The dog barks");
            }
        }

        public class Cat : Animal
        {
            public override void MakeSound()
            {
                Console.WriteLine("The cat meows");
            }
        }

        public class AnimalSound
        {
            public void PlaySound(Animal animal)
            {
                animal.MakeSound();
            }
        }


        class Program
        {
            static void Main(string[] args)
            {
                Animal animal1 = new Dog();
                animal1.MakeSound();

                Animal animal2 = new Cat();
                animal2.MakeSound();

                new AnimalSound().PlaySound(animal1);
                new AnimalSound().PlaySound(animal2);
            }
        }




        //Aqui, a classe CadastroCliente é a classe base e as classes CadastroClienteSqlServer e CadastroClienteOracle são classes derivadas.
        //A classe CadastroClienteBase é uma classe abstrata que contém um método virtual Salvar() que é responsável por salvar as informações do 
        //cliente no banco de dados.As classes derivadas CadastroClienteSqlServer e CadastroClienteOracle substituem o método Salvar() da classe base 
        //para fornecer a lógica de salvamento específica do banco de dados.
        //Dessa forma, podemos usar as classes derivadas CadastroClienteSqlServer e CadastroClienteOracle no lugar da classe base CadastroClienteBase sem quebrar o comportamento do programa.

        public class CadastroCliente
        {
            public string Nome { get; set; }
            public string Email { get; set; }
            public string Telefone { get; set; }
            public string Endereco { get; set; }
        }

        public abstract class CadastroClienteBase
        {
            public virtual void Salvar(CadastroCliente cliente)
            {
                // Lógica para salvar no banco de dados
            }
        }

        public class CadastroClienteSqlServer : CadastroClienteBase
        {
            public override void Salvar(CadastroCliente cliente)
            {
                // Lógica para salvar no SQL Server
            }
        }

        public class CadastroClienteOracle : CadastroClienteBase
        {
            public override void Salvar(CadastroCliente cliente)
            {
                // Lógica para salvar no Oracle
            }
        }
    }
}
