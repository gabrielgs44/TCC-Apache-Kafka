using Confluent.Kafka;
using Core.DTOs;
using Core.UseCases.SendInvoice;
using Newtonsoft.Json;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Core.UseCases.KafkaConsumer
{
    public class KafkaConsumerUseCase : IKafkaConsumerUseCase
    {
        [Obsolete]
        public Task ExecuteAsAsync()
        {
            var conf = new ConsumerConfig
            {
                GroupId = "test-consumer-group",
                BootstrapServers = "127.0.0.1:9092",
                AutoOffsetReset = AutoOffsetReset.Earliest
            };

            using var c = new ConsumerBuilder<Ignore, string>(conf).Build();

            {
                c.Subscribe("payment");

                var cts = new CancellationTokenSource();
                Console.CancelKeyPress += (_, e) =>
                {
                    e.Cancel = true;
                    cts.Cancel();
                };

                try
                {
                    try
                    {
                        while (true)
                        {
                            var cr = c.Consume(cts.Token);
                            var sendInvoice = new SendInvoiceUseCase();
                            sendInvoice.Execute(JsonConvert.DeserializeObject<InvoiceDto>(cr.Value));
                        }
                    }
                    catch (ConsumeException e)
                    {
                        Console.WriteLine($"Error occured: {e.Error.Reason}");
                    }
                }
                catch (OperationCanceledException)
                {
                    c.Close();
                }
            }

            return Task.CompletedTask;
        }
    }
}
