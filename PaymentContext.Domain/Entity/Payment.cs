using System;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Domain.Entity
{
    public abstract class Payment 
    {
        protected Payment(DateTime paidDate, DateTime expireDate, decimal total, decimal paidTotal, string payer, Document document, Address address, Email email)
        {
            Number = Guid.NewGuid().ToString().Replace("-","").Substring(0, 10).ToUpper();
            PaidDate = paidDate;
            ExpireDate = expireDate;
            Total = total;
            PaidTotal = paidTotal;
            Payer = payer;
            Document = document;
            Address = address;
            Email = email;
        }

        public string Number { get; private set; }
        public DateTime PaidDate { get; private set; }
        public DateTime ExpireDate { get; private set; }
        public decimal Total { get; private set; }
        public decimal PaidTotal{ get; private set; }
        public string Payer { get; private set; }
        public Document Document { get; private set; }
        public Address Address { get; private set; }
        public Email Email { get; private set; }
    }
}