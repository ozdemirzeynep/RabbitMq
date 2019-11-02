using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mq.Helper
{
    public class ConnectionHelper
    {
        public IConnection Connection()
        {
            ConnectionFactory connectionFactory = new ConnectionFactory()  // RabbitMQ hostuna bağlanmak için kullanılır. Bulunulan sunucudaki host name (localhost),virtual host ve credentials (password) girilir.
            {
                HostName = "localhost"
            };
            return connectionFactory.CreateConnection();
        }
    }
}
