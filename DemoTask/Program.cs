using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoTask
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Task> list = new List<Task>();
            for (var i = 0; i < 10; i++)
            {
                list.Add(new Program().Foo());
            }
            Task.WaitAll(list.ToArray());
            Console.Read();
        }

        private Task Foo()
        {

            return Task.Factory.StartNew(() =>
            {
                Task.Delay(1000);
                Console.WriteLine(DateTime.Now.ToString());
            });
        }
    }
}
