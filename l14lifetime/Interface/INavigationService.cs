using l9_mvvm.Model.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace l9_mvvm.Interface
{
    public interface INavigationService
    {
        ViewModelBase? CurrentViewModel { get; }
        void NavigateTo<T>(object? parameter = null) 
        where T : ViewModelBase;
    }
}
