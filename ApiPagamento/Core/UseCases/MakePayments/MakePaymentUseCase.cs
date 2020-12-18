using Domain.Common.Enums;
using Domain.Common.Exceptions;
using Domain.Common.Extensions;
using Domain.DTOs;
using Domain.Entities;
using ExternalService.SendInvoice;
using System;
using System.Globalization;
using System.Threading.Tasks;

namespace Core.UseCases.MakePayments
{
    public class MakePaymentUseCase : IMakePaymentUseCase
    {
        private readonly ISendInvoiceExternalService _sendInvoice;

        public MakePaymentUseCase(ISendInvoiceExternalService sendInvoice)
        {
            _sendInvoice = sendInvoice;
        }

        public async Task<Guid> ExecuteAsync(MakePagamentDto makePagamentDto)
        {
            var card = ValidateCard(makePagamentDto.Card);
            var cliente = ValidateCliente(makePagamentDto.Cliente, card);

            if (makePagamentDto.PagamentValue < 10)
            {
                throw new BusinessRuleException("Erro: o valor tem que ser maior ou igual a 10 reais!");
            }

            if (makePagamentDto.Parceled < 0)
            {
                throw new BusinessRuleException("Erro: Parcela inválida!");
            }

            var payment = new Payment(makePagamentDto.PagamentValue, makePagamentDto.Parceled, card.CardNumber);

            var invoice = new InvoiceDto(cliente.Name, cliente.Email, payment);

            try
            {
                await _sendInvoice.ExecuteAsync(invoice);
            }
            catch (Exception e)
            {
                throw new BusinessRuleException("Error: " + e.Message);
            }
            return payment.PaymentId;
        }

        private Card ValidateCard(CardDto cardDto)
        {
            if (cardDto.CardNumber.Length != 16)
            {
                throw new BusinessRuleException("Erro: Número do Cartão é Inválido!");
            }

            var cardValidDate = cardDto.ValidDate;

            if (int.Parse(cardValidDate.Substring(3, 4)) <= DateTime.Now.Year)
            {
                if (int.Parse(cardValidDate.Substring(0, 2)) <= DateTime.Now.Month)
                {
                    throw new BusinessRuleException("Erro: Cartão está fora da validade!");
                }
            }

            if (cardDto.SecurityCode < 100)
            {
                throw new BusinessRuleException("Erro: Código de segurança inválido!");
            }

            var cardType = (CardType)cardDto.CardType;

            return new Card(
                            cardDto.CardNumber,
                            cardValidDate,
                            cardDto.SecurityCode,
                            cardType);
        }

        private Cliente ValidateCliente(ClienteDto clienteDto, Card card)
        {
            if (clienteDto.Name.IsNullOrEmpty())
            {
                throw new BusinessRuleException("Erro: Nome é Inválido!");
            }

            var bithDate = DateTime.Parse(clienteDto.BithDate, CultureInfo.InvariantCulture);

            if (bithDate >= DateTime.Now)
            {
                throw new BusinessRuleException("Erro: Data de Nascimento não pode ser igual ou superior ao dia atual!");
            }

            if (clienteDto.Email.IsNullOrEmpty())
            {
                throw new BusinessRuleException("Erro: Email não informado!");
            }

            if (!clienteDto.Email.IsEmailValid())
            {
                throw new BusinessRuleException("Erro: Email inválido!");
            }

            return new Cliente(clienteDto.Name, bithDate, clienteDto.BithDate, clienteDto.Email, card);
        }
    }
}
