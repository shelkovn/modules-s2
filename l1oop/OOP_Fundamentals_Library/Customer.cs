namespace OOP_Fundamentals_Library
{
    public class Customer: IPerson
    {
        private string _name = "NoName";
        private int _age;

        public string Name
        {
            get { return _name; } 
            set 
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Name cannot be empty");
                if (value.Length > 100)
                    throw new ArgumentException("Name too long");
                if (!value.All(c => char.IsLetter(c) || c == ' ' || c == '-' || c == '\''))
                    throw new ArgumentException("Name contains invalid characters");
                _name = value;
            }
        }

        public int Age
        {
            get { return _age; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Age cannot be negative");
                if (value > 120)
                    throw new ArgumentException("Age is too high");
                _age = value;
            }
        }

        public void PrintInfo()
        {
            Console.WriteLine($"Customer: {_name}, {_age} years old");
        }
    }
}
