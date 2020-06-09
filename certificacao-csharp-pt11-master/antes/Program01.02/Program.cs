using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Program01._02
{
    class Program
    {
        static void Main(string[] args)
        {
            //MUITAS TAREFAS EM PARALELO, COM PARÂMETRO
            //=========================================
            //Tarefa 1: processar 100 itens em série
            //Tarefa 2: processar 100 itens em paralelo - percorrendo uma faixa
            //Tarefa 3: processar 100 itens em paralelo - percorrendo uma coleção

            double t1, t2, t3;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            System.Console.WriteLine("Tarefa 1: processar 100 itens em série");
            for (int i = 0; i < 100; i++)
            {
                Processar(i);
            }
            stopwatch.Stop();
            t1 = stopwatch.ElapsedMilliseconds / 1000.0;

            Console.WriteLine("Tarefa 2: processar 100 itens em paralelo - percorrendo uma faixa");
            stopwatch.Reset();
            stopwatch.Restart();

            Parallel.For(0, 100, (i) => Processar(i));
            stopwatch.Stop();
            t2 = stopwatch.ElapsedMilliseconds / 1000.0;

            Console.WriteLine("Tarefa 3: processar 100 itens em paralelo - percorrendo uma coleção");
            var itens = Enumerable.Range(0, 100);
            stopwatch.Reset();
            stopwatch.Restart();

            Parallel.ForEach(itens, (item) => Processar(item));
            stopwatch.Stop();
            t3 = stopwatch.ElapsedMilliseconds / 1000.0;


            System.Console.WriteLine("Tarefa 1 - Tempo decorrido: {0} segundos", t1);
            System.Console.WriteLine("Tarefa 2 - Tempo decorrido: {0} segundos", t2);
            System.Console.WriteLine("Tarefa 3 - Tempo decorrido: {0} segundos", t3);


            Console.WriteLine("Término do processamento. Tecle [ENTER] para terminar.");
            Console.ReadLine();
        }

        static void Processar(object item)
        {
            Console.WriteLine("Começando a trabalhar com: " + item);
            Thread.Sleep(100);
            Console.WriteLine("Terminando a trabalhar com: " + item);
        }
    }
}

