using System;
using System.Threading;

namespace RabbitMQ1
{
    class Program
    {
        static void Main(string[] args)
        {
            new Mq.Helper.ConsumerHelper("bilgeadam");
            while (true)
            {
                new Mq.Helper.PublisherHelper("bilgeadam", "test 123");
                Thread.Sleep(1000);
            }
        }
    }
}
