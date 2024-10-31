namespace TechChallenge.API.Application.DTOs;
public class UpdateContactDto
{
    public UpdateContactDto()
    {
        
    }
    public UpdateContactDto(Guid id, string name, string telefone, string email, string dDD)
    {
        Id = id;
        Name = name;
        Telefone = telefone;
        Email = email;
        DDD = dDD;
    }

    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Telefone { get; set; }
    public string Email { get; set; }
    public string DDD { get; set; }
}
