using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DemoBlockingCollection
{
    class Program
    {
        static BlockingCollection<int> queue = new BlockingCollection<int>(30);

        static void Main(string[] args)
        {
            var list = new List<Task>();
            list.Add(Producer());
            list.Add(Consumer());
            Task.WaitAll(list.ToArray());
            Console.Read();
        }

        //生产者
        static Task Producer()
        {
            return Task.Factory.StartNew(() =>
            {
                for (var i = 0; i < 100000; i++)
                {
                    if (!queue.TryAdd(i, 500))
                    {
                        Console.WriteLine("Timeout");
                    };
                }
            });
        }

        //消费者
        static Task Consumer()
        {
            return Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    queue.TryTake(out int i);
                    Thread.Sleep(5000);
                    Console.WriteLine(i);
                }
            });
        }
    }
}
