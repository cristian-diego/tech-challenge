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
    }
}