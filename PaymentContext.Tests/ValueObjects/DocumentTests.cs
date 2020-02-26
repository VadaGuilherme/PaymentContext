using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entity;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests
{
    [TestClass]
    public class DocumentTests
    {
        [TestMethod]
        [DataTestMethod]
        [DataRow("123")]
        [DataRow("456789")]
        [DataRow("1011121314")]
        public void ShouldReturnErrorWhenCNPJIsInvalid(string cnpj)
        {
            var doc = new Document(cnpj, EnumDocumentType.CNPJ);
            Assert.IsTrue(doc.Invalid);
        }

        [TestMethod]
        [DataTestMethod]
        [DataRow("91849453000142")]
        [DataRow("26197092000135")]
        [DataRow("21481284000155")]
        public void ShouldReturnSuccessWhenCNPJIsValid(string cnpj)
        {
            var doc = new Document(cnpj, EnumDocumentType.CNPJ);
            Assert.IsTrue(doc.Valid);
        }

        [TestMethod]
        [DataTestMethod]
        [DataRow("123")]
        [DataRow("456789")]
        [DataRow("1011121314")]
        public void ShouldReturnErrorWhenCPFIsInvalid(string cpf)
        {
            var doc = new Document(cpf, EnumDocumentType.CPF);
            Assert.IsTrue(doc.Invalid);
        }

        [TestMethod]
        [DataTestMethod]
        [DataRow("29542363028")]
        [DataRow("59135088079")]
        [DataRow("27729534088")]
        public void ShouldReturnSuccessWhenCPFIsValid(string cpf)
        {
            var doc = new Document(cpf, EnumDocumentType.CPF);
            Assert.IsTrue(doc.Valid);
        }
    }
}
