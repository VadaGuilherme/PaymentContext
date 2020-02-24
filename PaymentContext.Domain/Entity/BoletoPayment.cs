using System;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Domain.Entity
{
    public class BoletoPayment : Payment
    {
        public BoletoPayment(
            string barCode,
            string boletoNumber,
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
            BarCode = barCode;
            BoletoNumber = boletoNumber;
        }

        public string BarCode { get; private set; }
        public string BoletoNumber { get; private set; }
    }
}