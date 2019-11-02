using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mq.Helper
{
    public class PublisherHelper
    {
        public PublisherHelper(string queueName, string message)
        {
            ConnectionHelper connectionHelper = new ConnectionHelper();
            using (IConnection connection = connectionHelper.Connection())
            {
                using(IModel channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queueName, false, false, false, null); //QueueDeclare() methodu ile oluşturulacak olan queue‘nin ismi tanımlanır
                    channel.BasicPublish("", queueName, null, Encoding.UTF8.GetBytes(message)); //BasicPublish() methodu “exchange” aslında mesajın alınıp bir veya daha fazla queue’ya konmasını sağlar. 
                    Console.WriteLine("SEND: " + queueName + ", Message: " + message + ", Second: " + DateTime.Now.Second);
                }
            }
        }
    }
}
