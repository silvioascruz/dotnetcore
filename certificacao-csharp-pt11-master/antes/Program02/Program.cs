using System;
using System.Threading;

namespace Program02
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.Name = "Thread Principal";
            ExibirThread(Thread.CurrentThread);
            //1. Task X Thread
            Thread thread1 = new Thread(Executar);
            thread1.Name = "1. Task X Thread";
            thread1.Start();
            thread1.Join();

            //2. Thread com expressão lambda
            Thread thread2 = new Thread(() => Executar());
            thread2.Name = "2. Thread com expressão lambda";
            thread2.Start();
            thread2.Join();
            //3. Passando parâmetro para thread
            ParameterizedThreadStart  ps = new ParameterizedThreadStart((p) => ExecutarComParametro(p));

            Thread thread3 = new Thread(ps);
            thread3.Name = "3. Passando parâmetro para thread";
            thread3.Start(123);
            thread3.Join();
            //4. Interrompendo um relógio
            bool relogioFuncionando = true;
            
            Thread thread4 = new Thread(() => 
            {
                ExibirThread(Thread.CurrentThread);
                while (relogioFuncionando)
                {
                    System.Console.WriteLine("tic");
                    Thread.Sleep(1000);
                    System.Console.WriteLine("tac");
                    Thread.Sleep(1000);
                }
            });
            thread4.Name = "4. Interrompendo um relógio";
            thread4.Start();

            System.Console.WriteLine("Tecle algo para interromper");
            Console.ReadKey();
            relogioFuncionando = false;
            thread4.Join();

            //5. Sincronizando uma thread
            //.Join();
            //6. Dados da Thread: Nome, cultura, prioridade, contexto, background, pool

            //7. Usando Thread Pool
            for (int i = 0; i < 50; i++)
            {
                int estadoDoItem = i;
                ThreadPool.QueueUserWorkItem((estado) => ExecutarComParametro(estadoDoItem));
            }
           
           System.Console.ReadLine();
        }

        static void ExibirThread(Thread e){
            System.Console.WriteLine("");
            //Dados da Thread: Nome, cultura, prioridade, contexto, background, pool
            System.Console.WriteLine("Nome: {0}", e.Name);
            System.Console.WriteLine("Cultura: {0}", e.CurrentCulture);
            System.Console.WriteLine("Prioriadade: {0}", e.Priority);
            System.Console.WriteLine("Contexto: {0}", e.ExecutionContext);
            System.Console.WriteLine("Está em background?: {0}", e.IsBackground);
            System.Console.WriteLine("Está no pool de threads: {0}", e.IsThreadPoolThread);
            System.Console.WriteLine("");
        }

        static void Executar(){
            ExibirThread(Thread.CurrentThread);
            System.Console.WriteLine("Início da execução");
            Thread.Sleep(1000);
            System.Console.WriteLine("Fim da execução");
        }
        static void ExecutarComParametro(object param){
            ExibirThread(Thread.CurrentThread);
            System.Console.WriteLine("Início da execução com parâmetro: {0}", param);
            Thread.Sleep(1000);
            System.Console.WriteLine("Fim da execução com parâmetro: {0}", param);
        }

    }
}
