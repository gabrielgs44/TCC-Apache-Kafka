using Confluent.Kafka;
using Domain.Common.Exceptions;
using Domain.Entities;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ExternalService.SendInvoice
{
    public class SendInvoiceExternalService : ISendInvoiceExternalService
    {
        public async Task ExecuteAsync(InvoiceDto invoice)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new System.Uri("https://localhost:44383/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var content = new StringContent(JsonConvert.SerializeObject(invoice), Encoding.UTF8, "application/json");

                    var response = await client.PostAsync("api/sendemail", content);

                    if (response.IsSuccessStatusCode)
                    {
                        return;
                    }
                    else
                    {
                        var valor = response.Content.ReadAsStringAsync().Result;
                        throw new BusinessRuleException(valor);
                    }
                }
            }
            catch (BusinessRuleException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception)
            {
                var config = new ProducerConfig
                {
                    BootstrapServers = "127.0.0.1:9092"
                };

                var producer = new ProducerBuilder<Null, string>(config).Build();

                using (producer)
                {
                    try
                    {
                        var result = await producer.ProduceAsync("payment", new Message<Null, string> { Value = JsonConvert.SerializeObject(invoice) });
                    }
                    catch (ProduceException<Null, string> ex)
                    {
                        throw new BusinessRuleException(ex.Message);
                    }
                }
            }
        }
    }
}
