namespace TechChallenge.API.Application.DTOs;
public class UpdateContactDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Telefone { get; set; }
    public string Email { get; set; }
    public string DDD { get; set; }
}
