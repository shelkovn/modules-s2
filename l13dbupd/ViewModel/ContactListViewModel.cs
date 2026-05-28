using l9_mvvm.Interface;
using l9_mvvm.Model.App;
using l9_mvvm.Model.Data;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace l9_mvvm.ViewModel
{
    public class ContactListViewModel: ViewModelBase
    {
        private readonly ApplicationContext _context;
        private readonly ContactFormatHelper _validator = new ContactFormatHelper();
        public ObservableCollection<Contact> Contacts { get; set; }

        private string _name = string.Empty;
        private string _phone = string.Empty;
        private string _errMsg = string.Empty;
        private Contact? _selectedContact;
        private IDialogService _dialogService;
        private int id = 0;

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
        public ContactListViewModel(IDialogService ds, INavigationService navigation, ApplicationContext context) : base(navigation)
        {
            _context = context;
            _dialogService = ds;
            Contacts = new ObservableCollection<Contact>(_context.Contacts.ToList());
            AddCommand = new RelayCommand(
            AddContact, () => CanAddContact());

            DeleteCommand = new RelayCommand(
            DeleteContact, () => CanDeleteOrEditContact());

            EditCommand = new RelayCommand(
            () => _navigation.NavigateTo<ContactEditViewModel>(SelectedContact),
            () => CanDeleteOrEditContact());
        }
        private void AddContact()
        {
            if (_validator.ValidatePhoneNumber(PhoneInput) && !string.IsNullOrEmpty(NameInput))
            {
                try
                {
                    var newContact = new Contact { Phone = _validator.FormatPhoneNumber(PhoneInput), Name = NameInput };
                    // 1. Помечаем объект как добавленный
                    _context.Contacts.Add(newContact);
                    // 2. Сохраняем изменения в БД (генерирует INSERT)
                    _context.SaveChanges();
                    Contacts.Add(newContact); // обновить локальную коллекцию
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
                    // 1. Помечаем объект как удалённый
                    _context.Contacts.Remove(SelectedContact);
                    // 2. Сохраняем изменения (генерирует DELETE)
                    _context.SaveChanges();
                    // 3. Обновляем UI коллекцию
                    Contacts.Remove(SelectedContact);
                }
            }
        }
        private bool CanDeleteOrEditContact()
        {
            return (SelectedContact is not null); 
        }
    }
}
