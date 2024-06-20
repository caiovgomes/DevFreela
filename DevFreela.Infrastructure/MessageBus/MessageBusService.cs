using DevFreela.Core.Services;
using RabbitMQ.Client;

namespace DevFreela.Infrastructure.MessageBus
{
    public class MessageBusService : IMessageBusService
    {
        private readonly ConnectionFactory _factory;
        //private readonly IConfiguration _configuration;
        //Casos seja externo o construtor vai receber o configuration como parametro
        //MessageBusService(IConfiguration configuration)
        public MessageBusService()
        {
            _factory = new ConnectionFactory
            {
                HostName = "localhost",
            };
        }

        public void Publish(string queue, byte[] message)
        {
            using (var connection = _factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    // Garantir que a fila esteja criada
                    // queue = fila
                    // durable = fila durável, que quando reiniciar o servidor RabbitMQ se os dados/metadados vão está disponível
                    // exclusive = quero permitir apenas uma conexão, e quando essa conexão acabar eu vou deletar a fila
                    // autodelete = vou permitir várias conexões, mas quando todas terminarem eu vou deletar a fila
                    channel.QueueDeclare(queue: queue, durable: false, exclusive: false, autoDelete: false, arguments: null);

                    // Publicar a mensagem
                    // exchange = Agente responsável por rotear as mensagens (ficou em branco para dizer que é padrão)
                    // routingKey = 
                    channel.BasicPublish(exchange: "", routingKey: queue, basicProperties: null, body: message);

                }
            }
        }
    }
}
