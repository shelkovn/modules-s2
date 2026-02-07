using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Fundamentals_Library
{
    public abstract class Staff : Person
    {
        private decimal _salary;
        private int _years;
        private bool _hasCertification;

        public decimal Salary
        {
            get { return _salary; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Salary cannot be negative");
                _salary = value;
            }
        }

        public virtual int Years
        {
            get { return _years; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Years cannot be negative");
                _years = value;
            }
        }

        public bool HasCertification
        {
            get { return _hasCertification; }
            set { _hasCertification = value; }
        }

        public abstract decimal BonusMultiplier { get; }
        public abstract decimal SalaryIncrease { get; }
    }

}
