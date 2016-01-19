using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeadlockExample
{
    class Program
    {

        private static int _mutex = 0;

        //Exemplify on very basic case of deadlock (only for study propose)
        static void Main(string[] args)
        {
            var taskP1 = GetP1();
            var taskP2 = GetP2(taskP1);

            Task.Run(() => taskP2);
        }

        static Task<int> GetP1()
        {
            //State A of P1
            //Code to exemplify some resource that dont respond until P2 change to state B
            while (_mutex == 0);

            //State B of P1 process is return value 0;
            return Task.FromResult(0);
        }

        static async Task<int> GetP2(Task<int> resource)
        {
            //State A of P2 is wait for P1 finish (stay on state B)
            var result = await resource;


            //State B of P2 process is change mutex and print P1 result;
            _mutex = 1;
            Console.WriteLine($"P2 execute your job and get P1 result: {result}");

            return result;
        }
    }
}
