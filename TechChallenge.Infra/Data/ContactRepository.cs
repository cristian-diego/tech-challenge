using TechChallenge.Domain.Entities;
using TechChallenge.Domain.Interfaces;

namespace TechChallenge.Infra.Data
{
    public class ContactRepository : IContactRepository
    {
        private readonly DatabaseConnection _databaseConnection;

        public ContactRepository(DatabaseConnection databaseConnection)
        {
            _databaseConnection = databaseConnection;
        }

        public async Task Save(Contact contact)
        {
            var db = _databaseConnection.GetConnection();
            await db.InsertAsync(contact);
        }
    }
}