using Moq;
using SalesWeb.Server.Services;

namespace SalesWeb.Tests
{
    public class SellerTests
    {


        private readonly Mock<ISellerService> _mockSellerService;
         

        private const string CPF_INVALIDO = "123A";
        private const string CPF_ERRO_COMUNICACAO = "76217486300";
        private const string CPF_SEM_PENDENCIAS = "60487583752";
        private const string CPF_INADIMPLENTE = "82226651209";



        [Fact]

        //Given_When_Then
        public void Test1()
        {
            //arrange

            //act

            //assert
        }
    }
}