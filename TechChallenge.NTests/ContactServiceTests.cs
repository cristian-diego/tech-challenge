using NSubstitute;

namespace TechChallenge.Tests;

public class ContactServiceTests
{
    ContactService _target;
    ContactRepository _contactRepository;

    [SetUp]
    public void Setup()
    {
        _contactRepository = Substitute.For<ContactRepository>();
        _target = new ContactService(_contactRepository);
    }

    [Test]
    public void ContactService_AddContact_SaveContactToRepository()
    {
        // Arrange
        var contact = new Contact("John Doe", "123456789", "teste@gmail.com", "11");
        
        // Act
        var result = _target.Add(contact);

        // Assert
        Assert.NotNull(result);
    }

    [TestCase((string?)null)]
    [TestCase(" ")]
    [TestCase("")]
    public void ContactService_AddContact_ThrowsExceptionIfNameIsNullOrWhiteSpace(string? name)
    {
        // Arrange
        var contact = new Contact(name!, "123456789", "teste@gmail.com", "11");
        
        // Act & Assert
        Assert.Throws<ArgumentException>(() => _target.Add(contact));
    }


    [TestCase((string?)null)]
    [TestCase(" ")]
    [TestCase("")]
    public void ContactService_AddContact_ThrowsExceptionIfTelefoneIsNullOrWhiteSpace(string? telefone)
    {
        // Arrange
        var contact = new Contact("John Doe", telefone, "teste@gmail.com", "11");
        
        // Act & Assert
        Assert.Throws<ArgumentException>(() => _target.Add(contact));
    }


    [TestCase((string?)null)]
    [TestCase(" ")]
    [TestCase("")]
    public void ContactService_AddContact_ThrowsExceptionIfDDDIsNullOrWhiteSpace(string? ddd)
    {
        // Arrange
        var contact = new Contact("John Doe", "123456789", "teste@gmail.com", ddd);
        
        // Act & Assert
        Assert.Throws<ArgumentException>(() => _target.Add(contact));
    }
}
