using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.UseCases.KafkaConsumer
{
    public interface IKafkaConsumerUseCase
    {
        public Task ExecuteAsAsync();
    }
}
