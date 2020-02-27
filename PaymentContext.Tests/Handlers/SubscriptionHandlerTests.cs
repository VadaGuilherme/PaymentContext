using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Handlers;
using PaymentContext.Tests.Mocks;

namespace PaymentContext.Tests
{
    [TestClass]
    public class SubscriptionHandlerTests
    {
        [TestMethod]
        public void ShouldReturnErrorWhenDocumentExists()
        {
            var handler = new SubscriptionHandler(new FakeStudentRepository(), new FakeEmailService());
            var command = new CreateBoletoSubscriptionCommand();
            command.FirstName = "Guilherme";
            command.LastName = "Vada";
            command.Document = "99999999999";
            command.Email = "gvadaguariba@gmail.com";
            command.BarCode = "123456789";
            command.BoletoNumber = "123454987";
            command.PaymentNumber = "123121";
            command.PaidDate = DateTime.Now;
            command.ExpireDate = DateTime.Now.AddMonths(1);
            command.Total = 60;
            command.PaidTotal = 60;
            command.Payer = "Vada Corp";
            command.PayerDocument = "12345678911";
            command.PayerEmail = "gvadaguariba@gmail.com";
            command.PayerDocumentType = EnumDocumentType.CPF;
            command.Street = "asd";
            command.Number = "123";
            command.Neighborhood = "dasdsa";
            command.City = "das";
            command.State = "das";
            command.Country = "asd";
            command.ZipCode = "14840000";

            handler.Handle(command);
            Assert.AreEqual(false, handler.Valid);
        }
    }
}