namespace TechChallenge.Domain.Entities
{
    public class Contact
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string DDD { get; set; }

        public Contact(Guid id, string name, string telefone, string email, string ddd)
        {
            Id = id;
            Name = name;
            Telefone = telefone;
            Email = email;
            DDD = ddd;
        }
    }
}