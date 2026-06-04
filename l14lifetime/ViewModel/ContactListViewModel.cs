using l9_mvvm.Interface;
using l9_mvvm.Model.App;
using l9_mvvm.Model.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Diagnostics.Contracts;
using System.Windows.Input;

namespace l9_mvvm.ViewModel
{
    public class ContactListViewModel: ViewModelBase
    {
        private readonly IDbContextFactory<ApplicationContext> _contextFactory;
        private readonly ContactFormatHelper _validator = new ContactFormatHelper();
        public ObservableCollection<Contact> Contacts { get; set; }

        private string _name = string.Empty;
        private string _phone = string.Empty;
        private string _errMsg = string.Empty;
        private Contact? _selectedContact;
        private IDialogService _dialogService;

        public string ErrorMsg 
        { 
            get => _errMsg;
            set => Set(ref _errMsg, value);
        }
        public string NameInput
        {
            get => _name;
            set => Set(ref _name, value);
        }
        public string PhoneInput
        {
            get => _phone;
            set => Set(ref _phone, value);
        }
        public Contact? SelectedContact
        {
            get => _selectedContact;
            set => Set(ref _selectedContact, value);
        }



        // Команды
        public ICommand AddCommand { get; }
        public ICommand DeleteCommand { get; }
        public ICommand EditCommand { get; }

        private void RefreshContacts()
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                Contacts = new ObservableCollection<Contact>(context.Contacts.ToList());
            }
        }

        public ContactListViewModel(IDialogService ds, INavigationService navigation, IDbContextFactory<ApplicationContext> contextFactory) : base(navigation)
        {
            _contextFactory = contextFactory;
            _dialogService = ds;
            RefreshContacts();
            AddCommand = new RelayCommand(
            AddContact, () => CanAddContact());

            DeleteCommand = new RelayCommand(
            DeleteContact, () => CanDeleteOrEditContact());

            EditCommand = new RelayCommand(
            () => 
                {
                    using (var context = _contextFactory.CreateDbContext())
                    {
                        var contactToChange = context.Contacts.Find(SelectedContact.Id);
                        if (contactToChange != null)
                        {
                            _navigation.NavigateTo<ContactEditViewModel>(contactToChange);
                        }
                        else
                        {
                            _dialogService.ShowError($"Selected contact wasn't found");
                            RefreshContacts();
                        }
                    }
                },
            () => CanDeleteOrEditContact());
        }

        public override void OnNavigatedTo(object? parameter)
        {
            RefreshContacts();
        }

        private void AddContact()
        {
            if (_validator.ValidatePhoneNumber(PhoneInput) && !string.IsNullOrEmpty(NameInput))
            {
                try
                {
                    using (var context = _contextFactory.CreateDbContext())
                    {
                        var newContact = new Contact { Phone = _validator.FormatPhoneNumber(PhoneInput), Name = NameInput };
                        // 1. Помечаем объект как добавленный
                        context.Contacts.Add(newContact);
                        // 2. Сохраняем изменения в БД (генерирует INSERT)
                        context.SaveChanges();
                        Contacts.Add(newContact); // обновить локальную коллекцию
                    }
                }
                catch (Exception ex)
                {
                    _dialogService.ShowError(ex.Message);
                }
            }
            else
            {
                ErrorMsg = $"Invalid info";
                _dialogService.ShowError($"Invalid info");
            }
        }
        private bool CanAddContact()
        {
            return (!string.IsNullOrEmpty(_name) && !string.IsNullOrEmpty(_phone));
        }
        private void DeleteContact()
        {
            if (SelectedContact is not null && Contacts.Contains(SelectedContact))
            {
                if (_dialogService.GetConfirmation($"Delete contact {SelectedContact}?"))
                {
                    try
                    {
                        using (var context = _contextFactory.CreateDbContext())
                        {
                            var contactToChange = context.Contacts.Find(SelectedContact.Id);
                            if (contactToChange != null)
                            {
                                // 1. Помечаем объект как удалённый
                                context.Contacts.Remove(contactToChange);
                                // 2. Сохраняем изменения (генерирует DELETE)
                                context.SaveChanges();
                                // 3. Обновляем UI коллекцию
                                Contacts.Remove(SelectedContact);
                            }
                            else
                            {
                                _dialogService.ShowError($"No contact {SelectedContact.Name} {SelectedContact.Phone} found (id: {SelectedContact.Id})");
                                RefreshContacts();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        _dialogService.ShowError(ex.Message);
                    }
                }
            }
        }
        private bool CanDeleteOrEditContact()
        {
            return (SelectedContact is not null); 
        }
    }
}
