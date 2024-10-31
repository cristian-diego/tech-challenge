using TechChallenge.MauiClient.ViewModels;

namespace TechChallenge.AppClient
{
    public partial class MainPage : ContentPage
    {
        private readonly ContactsViewModel _contactsViewModel;

        public MainPage(ContactsViewModel contactsViewModel)
        {
            InitializeComponent();
            _contactsViewModel = contactsViewModel;
            BindingContext = contactsViewModel;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            await _contactsViewModel.LoadContacts();
        }
    }

}
