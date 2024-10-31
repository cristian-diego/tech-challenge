using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using TechChallenge.AppClient.Models;
using TechChallenge.MauiClient.Services;

namespace TechChallenge.MauiClient.ViewModels
{
    public partial class ContactsViewModel : ObservableObject
    {
        private readonly ContactApiService _apiService;

        [ObservableProperty]
        private ObservableCollection<ContactDto> contacts;

        [ObservableProperty]
        private ContactDto selectedContact;

        [ObservableProperty]
        private bool isLoading;

        public ContactsViewModel(ContactApiService apiService)
        {
            _apiService = apiService;
            contacts = new ObservableCollection<ContactDto>();
            selectedContact = new ContactDto();
        }

        [RelayCommand]
        public async Task LoadContacts()
        {
            try
            {
                IsLoading = true;
                var contactsList = await _apiService.GetContactsAsync();
                Contacts.Clear();
                foreach (var contact in contactsList)
                {
                    Contacts.Add(contact);
                }
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", ex.Message, "OK");
            }
            finally
            {
                IsLoading = false;
            }
        }

        [RelayCommand]
        private async Task AddContact()
        {
            try
            {
                IsLoading = true;
                await _apiService.AddContactAsync(SelectedContact);
                await LoadContacts();
                SelectedContact = new ContactDto();
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", ex.Message, "OK");
            }
            finally
            {
                IsLoading = false;
            }
        }
    }
} 