namespace TechChallenge.API.Application.DTOs;

public class AddContactDto
{
    public AddContactDto(string name, string telefone, string email, string dDD)
    {
        Name = name;
        Telefone = telefone;
        Email = email;
        DDD = dDD;
    }

    public string Name { get; set; }
    public string Telefone { get; set; }
    public string Email { get; set; }
    public string DDD { get; set; }
}