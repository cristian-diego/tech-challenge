namespace TechChallenge.Domain.Entities
{
    public class Contact
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string DDD { get; set; }

        public Contact() { }

        public Contact(string name, string telefone, string email, string ddd)
        {
            Name = name;
            Telefone = telefone;
            Email = email;
            DDD = ddd;
        }
    }
}