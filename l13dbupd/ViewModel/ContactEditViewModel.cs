using l9_mvvm.Interface;
using l9_mvvm.Model.App;
using l9_mvvm.Model.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace l9_mvvm.ViewModel
{
    public class ContactEditViewModel : ViewModelBase
    {
        private Contact _contact = null!; 
        private string _editName = string.Empty;
        private string _editPhone = string.Empty;
        private readonly ApplicationContext _context;
        private readonly ContactFormatHelper _formathelper = new ContactFormatHelper();
        private readonly IDialogService _dialogService;
        public string EditName
        {
            get => _editName;
            set => Set(ref _editName, value);
        }
        public string EditPhone
        {
            get => _editPhone;
            set => Set(ref _editPhone, value);
        }
        public ICommand SaveCommand { get; }
        public ICommand CancelCommand { get; }
        public ContactEditViewModel(INavigationService navigation, ApplicationContext context, IDialogService dialogService) : base(navigation)
        {
            _context = context;
            _dialogService = dialogService;
            SaveCommand = new RelayCommand(
            () =>
            {
                if (_formathelper.ValidatePhoneNumber(EditPhone) && !string.IsNullOrEmpty(EditName))
                {
                    try
                    {
                        _contact.Name = EditName;
                        _contact.Phone = EditPhone;
                        // SaveChanges обнаружит изменения и сгенерирует UPDATE
                        _context.SaveChanges();
                        _navigation.NavigateTo<ContactListViewModel>();
                    }
                    catch (Exception ex)
                    {
                        _dialogService.ShowError(ex.Message);
                    }
                }
                else
                {
                    _dialogService.ShowError($"Invalid info");
                }
            });
            CancelCommand = new RelayCommand(
            () => _navigation.NavigateTo<ContactListViewModel>());
        }
        public override void OnNavigatedTo(object? parameter)
        {
            if (parameter is Contact c)
            {
                _contact = c;
                EditName = c.Name;
                EditPhone = c.Phone;
            }
        }
    }
}
