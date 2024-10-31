using NSubstitute;
using NUnit.Framework;
using System;
using System.Threading.Tasks;
using TechChallenge.API.Application.DTOs;
using TechChallenge.Application.Services;
using TechChallenge.Domain.Entities;
using TechChallenge.Domain.Interfaces;

namespace TechChallenge.Tests
{
    [TestFixture]
    public class ContactServiceTests
    {
        private ContactService _target;
        private IContactRepository _contactRepository;

        [SetUp]
        public void Setup()
        {
            _contactRepository = Substitute.For<IContactRepository>();
            _target = new ContactService(_contactRepository);
        }

        [Test]
        public async Task AddContact_ShouldSaveContact()
        {
            // Arrange
            var contact = new AddContactDto("John Doe", "123456789", "john.doe@example.com", "11");

            // Act
            await _target.AddContact(contact);

            // Assert
            await _contactRepository.Received(1).Save(Arg.Any<Contact>());
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void AddContact_ShouldThrowException_WhenNameIsInvalid(string? invalidName)
        {
            // Arrange
            var contact = new AddContactDto(invalidName, "123456789", "john.doe@example.com", "11");

            // Act & Assert
            Assert.ThrowsAsync<ArgumentException>(() => _target.AddContact(contact));
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void AddContact_ShouldThrowException_WhenTelefoneIsInvalid(string? invalidTelefone)
        {
            // Arrange
            var contact = new AddContactDto("John Doe", invalidTelefone, "john.doe@example.com", "11");

            // Act & Assert
            Assert.ThrowsAsync<ArgumentException>(() => _target.AddContact(contact));
        }


        [TestCase(null)]
        [TestCase("invalid-email")]
        [TestCase("invalid-email@")]
        public void AddContact_ShouldThrowException_WhenEmailIsInvalid(string? invalidEmail)
        {
            // Arrange
            var contact = new AddContactDto("John Doe", "123456789", invalidEmail, "11");

            // Act & Assert
            Assert.ThrowsAsync<ArgumentException>(() => _target.AddContact(contact));
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void AddContact_ShouldThrowException_WhenDDDIsNullOrWhiteSpace(string? ddd)
        {
            // Arrange
            var contact = new AddContactDto("John Doe", "123456789", "teste@gmail.com", ddd);

            // Act & Assert
            Assert.ThrowsAsync<ArgumentException>(() => _target.AddContact(contact));
        }

        [Test]
        public async Task GetContacts_ShouldReturnAllContacts()
        {
            // Arrange
            var expectedContacts = new List<Contact>
            {
                new Contact(Guid.NewGuid(), "John Doe", "123456789", "john@example.com", "11"),
                new Contact(Guid.NewGuid(), "Jane Doe", "987654321", "jane@example.com", "21")
            };
            _contactRepository.GetContacts().Returns(expectedContacts);

            // Act
            var result = await _target.GetContacts();

            // Assert
            Assert.That(result, Is.EqualTo(expectedContacts));
            await _contactRepository.Received(1).GetContacts();
        }

        [Test]
        public async Task GetContactsByDDD_ShouldReturnFilteredContacts()
        {
            // Arrange
            var ddd = "11";
            var expectedContacts = new List<Contact>
            {
                new Contact(Guid.NewGuid(), "John Doe", "123456789", "john@example.com", "11")
            };
            _contactRepository.GetContactsByDDD(ddd).Returns(expectedContacts);

            // Act
            var result = await _target.GetContactsByDDD(ddd);

            // Assert
            Assert.That(result, Is.EqualTo(expectedContacts));
            await _contactRepository.Received(1).GetContactsByDDD(ddd);
        }

        [Test]
        public async Task DeleteContactById_ShouldCallRepository()
        {
            // Arrange
            var id = Guid.NewGuid();

            // Act
            await _target.DeleteContactById(id);

            // Assert
            await _contactRepository.Received(1).DeleteById(id);
        }

        [Test]
        public async Task UpdateContact_ShouldUpdateContact()
        {
            // Arrange
            var contact = new UpdateContactDto(
                Guid.NewGuid(),
                "John Doe",
                "123456789",
                "john.doe@example.com",
                "11"
            );

            // Act
            await _target.UpdateContact(contact);

            // Assert
            await _contactRepository.Received(1).Update(Arg.Any<Contact>());
        }

        [Test]
        public void UpdateContact_ShouldThrowException_WhenIdIsEmpty()
        {
            // Arrange
            var contact = new UpdateContactDto(
                Guid.Empty,
                "John Doe",
                "123456789",
                "john.doe@example.com",
                "11"
            );

            // Act & Assert
            Assert.ThrowsAsync<ArgumentException>(() => _target.UpdateContact(contact));
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void UpdateContact_ShouldThrowException_WhenNameIsInvalid(string? invalidName)
        {
            // Arrange
            var contact = new UpdateContactDto(
                Guid.NewGuid(),
                invalidName,
                "123456789",
                "john.doe@example.com",
                "11"
            );

            // Act & Assert
            Assert.ThrowsAsync<ArgumentException>(() => _target.UpdateContact(contact));
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void UpdateContact_ShouldThrowException_WhenTelefoneIsInvalid(string? invalidTelefone)
        {
            // Arrange
            var contact = new UpdateContactDto(
                Guid.NewGuid(),
                "John Doe",
                invalidTelefone,
                "john.doe@example.com",
                "11"
            );

            // Act & Assert
            Assert.ThrowsAsync<ArgumentException>(() => _target.UpdateContact(contact));
        }

        [TestCase(null)]
        [TestCase("invalid-email")]
        [TestCase("invalid-email@")]
        public void UpdateContact_ShouldThrowException_WhenEmailIsInvalid(string? invalidEmail)
        {
            // Arrange
            var contact = new UpdateContactDto(
                Guid.NewGuid(),
                "John Doe",
                "123456789",
                invalidEmail,
                "11"
            );

            // Act & Assert
            Assert.ThrowsAsync<ArgumentException>(() => _target.UpdateContact(contact));
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void UpdateContact_ShouldThrowException_WhenDDDIsInvalid(string? invalidDDD)
        {
            // Arrange
            var contact = new UpdateContactDto(
                Guid.NewGuid(),
                "John Doe",
                "123456789",
                "john.doe@example.com",
                invalidDDD
            );

            // Act & Assert
            Assert.ThrowsAsync<ArgumentException>(() => _target.UpdateContact(contact));
        }
    }
}