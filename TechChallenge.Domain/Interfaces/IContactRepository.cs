using TechChallenge.Domain.Entities;

namespace TechChallenge.Domain.Interfaces
{
    public interface IContactRepository
    {
        Task DeleteById(Guid id);
        Task<IEnumerable<Contact>> GetContacts();
        Task<IEnumerable<Contact>> GetContactsByDDD(string ddd);
        Task<Guid> Save(Contact contact);
        Task Update(Contact contact);
    }
}