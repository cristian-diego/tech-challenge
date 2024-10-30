using TechChallenge.Domain.Entities;
using TechChallenge.Domain.Interfaces;

namespace TechChallenge.Application.Services
{
    public class ContactService
    {
        private readonly IContactRepository _contactRepository;

        public ContactService(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async Task AddContact(Contact contact)
        {
            if (string.IsNullOrWhiteSpace(contact.Name))
            {
                throw new ArgumentException("Name cannot be null or whitespace.");
            }

            if (string.IsNullOrWhiteSpace(contact.Telefone))
            {
                throw new ArgumentException("Phone number cannot be null or whitespace.");
            }

            if (string.IsNullOrWhiteSpace(contact.DDD))
            {
                throw new ArgumentException("DDD cannot be null or whitespace.");
            }

            if (!IsValidEmail(contact.Email))
            {
                throw new ArgumentException("Invalid email format.");
            }

            await _contactRepository.Save(contact);
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}