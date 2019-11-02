using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mq.Helper
{
    public class ConsumerHelper       //Gönderilen mesajı karşılayan sunucudur.  Kısaca ilgili kuyruğu(Queue)’yu dinleyen taraftır.
    {
        public ConsumerHelper(string queueName)
        {
            IConnection connection = new ConnectionHelper().Connection();
            IModel model = connection.CreateModel();  // CreateModel() methodu ile RabbitMQ üzerinde yeni bir channel yaratılır. İşte bu açılan channel yani session ile yeni bir queue oluşturulup istenen mesaj bu channel üzerinden gönderilmektedir.
            EventingBasicConsumer eventingBasicConsumer = new EventingBasicConsumer(model); //Gönderilen mesajı karşılayan sunucudur
            eventingBasicConsumer.Received += (sender, args) =>
            {
                byte[] body = args.Body;
                string message = Encoding.UTF8.GetString(body);
                Console.WriteLine("RECEIVE: " + queueName + ", Message: " + message + ", Second: " + DateTime.Now.Second);
            };
            model.BasicConsume(queueName, true, eventingBasicConsumer); //Methodu ile ilgili Queue’den mesajları çekme işlemine başlanır. Burada “noAck” parametresi true olarak atanır ise, ilgili mesaj alındıktan sonra Queue’den otomatik olarak silinir.
        }
    }       
}
