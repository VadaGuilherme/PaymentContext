using PaymentContext.Domain.Entity;

namespace PaymentContext.Domain.Repositories {
    public interface IStudentyRepository
    {
        bool DocumentExists(string document);
        bool EmailExists(string email);
        void CreateSubscription(Student student);
    }
}