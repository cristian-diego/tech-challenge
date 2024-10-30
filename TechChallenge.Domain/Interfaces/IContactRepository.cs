using TechChallenge.Domain.Entities;
using System.Threading.Tasks;

namespace TechChallenge.Domain.Interfaces
{
    public interface IContactRepository
    {
        Task Save(Contact contact);
    }
}