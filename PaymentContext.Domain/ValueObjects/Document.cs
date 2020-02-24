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
        }

        public string Number { get; private set; }
        public EnumDocumentType Type { get; private set; }
    }
}