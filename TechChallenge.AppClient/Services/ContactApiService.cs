using System.Net.Http.Json;
using TechChallenge.AppClient.Models;

namespace TechChallenge.MauiClient.Services
{
    public class ContactApiService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl = "https://766b4f1q-7273.brs.devtunnels.ms/"; // Update with your API URL
        //private readonly string _baseUrl = "https://localhost:7273/"; // Update with your API URL

        public ContactApiService()
        {
            _httpClient = new HttpClient() 
            {
                BaseAddress = new Uri(_baseUrl)
            };
        }

        public Task<List<ContactDto>> GetContactsAsync() 
            => _httpClient.GetFromJsonAsync<List<ContactDto>>("contacts") ?? Task.FromResult(new List<ContactDto>());

        public async Task AddContactAsync(ContactDto contact)
        {
            var response = await _httpClient.PostAsJsonAsync("contacts", contact);
            response.EnsureSuccessStatusCode();
        }

        public Task UpdateContactAsync(ContactDto contact)
            => _httpClient.PutAsJsonAsync("contacts", contact);

        public Task DeleteContactAsync(Guid id) 
            => _httpClient.DeleteAsync($"{_baseUrl}/contacts/{id}");
    }
} 