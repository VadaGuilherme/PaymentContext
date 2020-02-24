using System;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Domain.Entity
{
    public class PayPalPayment : Payment
    {
        public PayPalPayment(
            string transactionCode, 
            DateTime paidDate, 
            DateTime expireDate, 
            decimal total, 
            decimal paidTotal, 
            string payer, 
            Document document, 
            Address address, 
            Email email) : base(
                    paidDate, 
                    expireDate, 
                    total, 
                    paidTotal, 
                    payer, 
                    document, 
                    address, 
                    email
                    )
        {
            TransactionCode = transactionCode;
        }

        public string TransactionCode { get; private set; }
    }
}