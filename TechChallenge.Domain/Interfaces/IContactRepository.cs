using TechChallenge.Domain.Entities;

namespace TechChallenge.Domain.Interfaces
{
    public interface IContactRepository
    {
        Task<IEnumerable<Contact>> GetContacts();
        Task<IEnumerable<Contact>> GetContactsByDDD(string ddd);
        Task<Guid> Save(Contact contact);
    }
}