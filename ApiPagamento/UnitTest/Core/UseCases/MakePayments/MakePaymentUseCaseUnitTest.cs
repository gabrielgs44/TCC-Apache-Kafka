//using Core.DTOs;
//using Core.UseCases.MakePayments;
//using FluentAssertions;
//using Moq;
//using System;
//using Xunit;

//namespace UnitTest.Core.UseCases.MakePayments
//{
//    public class MakePaymentUseCaseUnitTest : UnitTest
//    {
//        private readonly Mock<IMakePaymentUseCase> _mockIMakePayment;

//        [Fact(DisplayName = "Should make payment")]
//        public void ShouldMakePayment()
//        {
//            var makePaymentDto = new MakePagamentDto()
//            {
//                PagamentValue = 200.00,
//                Parceled = 2,
//                Card = new CardDto()
//                {
//                    Name = "Name",
//                    CardNumber = "1234567891234567",
//                    ValidDate = "10/2024",
//                    SecurityCode = 187,
//                    BithDate = "11/11/1990",
//                    PhoneNumber = "21999999999",
//                    CardType = 1
//                }
//            };

//            var makePayment = ConfigMock();

//            var result = makePayment.Execute(makePaymentDto);

//            result.Should().NotBe(Guid.Empty);
//        }

//        public MakePaymentUseCase ConfigMock()
//        {
//            return new MakePaymentUseCase();
//        }
//    }
//}
