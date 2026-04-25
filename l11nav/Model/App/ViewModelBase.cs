using l9_mvvm.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace l9_mvvm.Model.App
{
    public class ViewModelBase : ObservableObject, INavigationAware
    {
        public readonly INavigationService _navigation;

        public ViewModelBase(INavigationService navigation)
        {
            _navigation = navigation;
        }

        public virtual void OnNavigatedTo(object? parameter)
        {
            
        }
    }
}
