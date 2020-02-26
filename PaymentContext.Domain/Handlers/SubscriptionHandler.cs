using Flunt.Notifications;
using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Entity;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Repositories;
using PaymentContext.Domain.Services;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Commands;
using PaymentContext.Shared.Handlers;
using System;

namespace PaymentContext.Domain.Handlers
{
    public class SubscriptionHandler : Notifiable, 
        IHandler<CreateBoletoSubscriptionCommand>
    {
        private readonly IStudentyRepository _repository;
        private readonly IEmailService _emailService;

        public SubscriptionHandler(IStudentyRepository repository, IEmailService emailService)
        {
            _repository = repository;
            _emailService = emailService;
        }

        public ICommandResult Handle(CreateBoletoSubscriptionCommand command)
        {
            command.Validate();

            if (command.Invalid)
            {
                AddNotifications(command);
                return new CommandResult(false, "Não foi possivel realizar sua assinatura.");
            }

            if (_repository.DocumentExists(command.Document))
            {
                AddNotification("Document", "Este CPF já está em uso.");
            }

            if (_repository.EmailExists(command.Email))
            {
                AddNotification("Document", "Este Email já está em uso.");
            }

            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document, EnumDocumentType.CPF);
            var email = new Email(command.Email);
            var address = new Address(command.Street, command.Number, command.Neighborhood, command.City, command.State, command.Country, command.ZipCode);

            var student = new Student(name, document, email);
            var subscription = new Subscription(DateTime.Now.AddMonths(1));
            var payment = new BoletoPayment(command.BarCode, command.BoletoNumber, command.PaidDate, command.ExpireDate, command.Total, command.PaidTotal, command.Payer, new Document(command.PayerDocument, command.PayerDocumentType), address, email);

            subscription.AddPayment(payment);
            student.AddSubscription(subscription);

            AddNotifications(name, document, email, address, student, subscription, payment);

            _repository.CreateSubscription(student);

            _emailService.Send(student.Name.ToString(), student.Email.Address, "Bem vindo na plataforma de cursos.", "Sua assinatura foi criada.");

            return new CommandResult(true, "Assinatura realizada com sucesso.");
        }
    }
}
