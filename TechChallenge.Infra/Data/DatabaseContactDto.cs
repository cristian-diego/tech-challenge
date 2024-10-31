
using Supabase.Postgrest.Models;
using Supabase.Postgrest.Attributes;

namespace TechChallenge.Infra.Data
{
    [Table("Contatos")]
    public class DatabaseContactDto : BaseModel
    {
        [PrimaryKey("id")]
        public Guid Id { get; set; }

        [Column("name")]
        public string Name { get; set; }
        
        [Column("telefone")]
        public string Telefone { get; set; }
        
        [Column("email")]
        public string Email { get; set; }
        
        [Column("ddd")]
        public string DDD { get; set; }
    }

}