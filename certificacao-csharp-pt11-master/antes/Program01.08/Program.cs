using System;
using System.Threading;
using System.Threading.Tasks;

namespace Program01._10
{
    class Program
    {
        static void Main(string[] args)
        {
            //PROBLEMA: Criar e executar uma tarefa-mãe 
            //e 10 tarefas-filhas que levam 1s cada uma para terminar.
            Task tarefaMae = 
                Task.Factory.StartNew(() => {
                    Console.WriteLine("Tarefa-mãe iniciou.");

                    for (int i = 0; i < 10; i++)
                    {
                        var indiceFilha = i;
                        Task tarefaFilha =
                            Task.Factory.StartNew((id) => ExecutarFilha(id),
                                                    indiceFilha,
                                                    TaskCreationOptions.AttachedToParent);
                    }
                });

            tarefaMae.Wait();
            System.Console.WriteLine("Tarefa-mãe terminou");

            System.Console.ReadLine();
        }

        private static void ExecutarFilha(object i)
        {
            System.Console.WriteLine("\tTarefa-filha {0} iniciou.", i);
            Thread.Sleep(1000);
            System.Console.WriteLine("\tTarefa-filha {0} terminou", i);
        }
    }
}
