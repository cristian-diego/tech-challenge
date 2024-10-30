
namespace TechChallenge.Tests;

public class ContactService
{
    private readonly ContactRepository _contactRepository;

    public ContactService(ContactRepository contactRepository)
    {
        _contactRepository = contactRepository;
    }

    internal Contact Add(Contact contact)
    {
        if (string.IsNullOrWhiteSpace(contact.Name))
        {
            throw new ArgumentException("Name cannot be null or whitespace.");
        }

        if (string.IsNullOrWhiteSpace(contact.Phone))
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

        _contactRepository.Save(contact);

        return contact;
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