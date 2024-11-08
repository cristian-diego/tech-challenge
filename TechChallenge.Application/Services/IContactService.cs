﻿using TechChallenge.API.Application.DTOs;
using TechChallenge.Domain.Entities;

namespace TechChallenge.Application.Services
{
    public interface IContactService
    {
        Task<Guid> AddContact(AddContactDto contact);
        Task UpdateContact(UpdateContactDto contact);
        Task<IEnumerable<Contact>> GetContacts();
        Task<IEnumerable<Contact>> GetContactsByDDD(string ddd);
        Task DeleteContactById(Guid id);
    }
}