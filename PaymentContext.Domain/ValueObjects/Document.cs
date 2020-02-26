using Flunt.Validations;
using PaymentContext.Domain.Enums;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects
{
    public class Document : ValueObject
    {
        public Document(string number, EnumDocumentType type)
        {
            Number = number;
            Type = type;

            AddNotifications(new Contract()
                .Requires()
                .IsTrue(Validate(), "Document.Number", "Documento invalido")
            );
        }

        public string Number { get; private set; }
        public EnumDocumentType Type { get; private set; }

        private bool Validate()
        {
            if(Type == EnumDocumentType.CNPJ && Number.Length == 14)
                return true;

            if(Type == EnumDocumentType.CPF && Number.Length == 11)
                return true;

            return false;
        }
    }
}