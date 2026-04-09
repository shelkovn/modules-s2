using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace l9_mvvm.Model
{
    public class Contact : ObservableObject
    {
        private int _id;
        private string _name;
        private string _phone;

        public string Name 
        {
            get { return _name; } 
            set { _name = value.Trim(); }
        }

        public string Phone
        {
            get { return _phone; }
            set 
            {
                value = value.Trim();
                if (value.StartsWith('+') && value.Substring(1, value.Length-1).All(char.IsDigit) && value.Length == 11) // начинается с +, после + только цифры, не менее 11 символов
                {
                    _phone = value;
                }
            }
        }

        public Contact(int id, string name, string phone)
        {
            _id = id;
            _name = name;
            _phone = phone;
        }
    }
}
