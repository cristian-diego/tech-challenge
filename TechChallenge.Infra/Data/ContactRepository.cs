using TechChallenge.Domain.Entities;
using TechChallenge.Domain.Interfaces;

namespace TechChallenge.Infra.Data
{
    public class ContactRepository : IContactRepository
    {
        private readonly SupabaseConnection _supabaseConnection;

        public ContactRepository(SupabaseConnection supabaseConnection)
        {
            _supabaseConnection = supabaseConnection;
        }

        public Task DeleteById(Guid id)
        {
            var client = _supabaseConnection.GetClient();
            return client.From<DatabaseContactDto>().Where(x => x.Id == id).Delete();
        }

        public async Task<IEnumerable<Contact>> GetContacts()
        {
            var client = _supabaseConnection.GetClient();
            var contacts = await client.From<DatabaseContactDto>().Get();
            return contacts.Models.Select(c => new Contact(c.Id, c.Name, c.Telefone, c.Email, c.DDD));
        }

        public async Task<IEnumerable<Contact>> GetContactsByDDD(string ddd)
        {
            var client = _supabaseConnection.GetClient();
            var contacts = await client.From<DatabaseContactDto>().Where(x => x.DDD == ddd).Get();
            return contacts.Models.Select(c => new Contact(c.Id, c.Name, c.Telefone, c.Email, c.DDD));
        }

        public async Task<Guid> Save(Contact contact)
        {
            var client = _supabaseConnection.GetClient();
            var response = await client.From<DatabaseContactDto>()
                .Insert(new DatabaseContactDto
                {
                    Name = contact.Name,
                    Telefone = contact.Telefone,
                    Email = contact.Email,
                    DDD = contact.DDD
                });

            if (response.Model is null)
            {
                throw new InvalidOperationException("Aconteceu um erro ao tentar persistir o Contato");
            }

            return response.Model.Id;
        }

        public async Task Update(Contact contact)
        {
            var client = _supabaseConnection.GetClient();
            await client.From<DatabaseContactDto>()
                .Where(x => x.Id == contact.Id)
                .Set(x => x.Name, contact.Name)
                .Set(x => x.Telefone, contact.Telefone)
                .Set(x => x.Email, contact.Email)
                .Set(x => x.DDD, contact.DDD)
                .Update();
        }
    }
}