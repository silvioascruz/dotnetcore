using System;
using System.Threading;
using System.Threading.Tasks;

namespace Program07_01
{
    //Implementar métodos thread-safe
    class Program
    {
        static void Main(string[] args)
        {
            var contador = new Contador();

            System.Console.WriteLine("Contador Inicial: {0}", contador.Numero);

            Thread thread1 = new Thread(() => 
            {
                for (int i = 0; i < 50; i++)
                {
                    contador.Incrementar();
                    Thread.Sleep(i);
                }
            });
            thread1.Start();
            //thread1.Join();

            Thread thread2 = new Thread(() => 
            {
                for (int i = 0; i < 50; i++)
                {
                    contador.Incrementar();
                    Thread.Sleep(i);
                }
            });
            thread2.Start();
            thread1.Join();
            thread2.Join();    

            System.Console.WriteLine("Contador Final: {0}", contador.Numero);        
        }

        static object ContadorObject = new object();
        class Contador
        {
            public int Numero { get; private set; } = 0;
            public void Incrementar()
            {
                lock(ContadorObject)
                {
                    Numero++;
                }
            }
        }
    }
}
