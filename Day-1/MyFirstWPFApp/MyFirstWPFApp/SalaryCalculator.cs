using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace MyFirstWPFApp
{
    public class SalaryCalculator : INotifyPropertyChanged
    {
        private double _basic;
        private double _hra;
        private double _da;
        private int _tax;
        private double _salary;
        public event PropertyChangedEventHandler PropertyChanged;

        public double Basic
        {
            get { return _basic; }
            set
            {
                _basic = value;
                TriggerPropertyChanged("Basic");
                TriggerPropertyChanged("Salary");
                TriggerPropertyChanged("IsSalaryValid");
            }
        }

        private void TriggerPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null) PropertyChanged(this,new PropertyChangedEventArgs(propertyName));
        }

        public double Hra
        {
            get { return _hra; }
            set { _hra = value;
            TriggerPropertyChanged("Hra");
            TriggerPropertyChanged("Salary");
            TriggerPropertyChanged("IsSalaryValid");
            }
        }

        public double Da
        {
            get { return _da; }
            set { _da = value;
            TriggerPropertyChanged("Da");
            TriggerPropertyChanged("Salary");
            TriggerPropertyChanged("IsSalaryValid");
            }
        }

        public int Tax
        {
            get { return _tax; }
            set { _tax = value;
            TriggerPropertyChanged("Tax");
            TriggerPropertyChanged("Salary");
            }
        }

        public bool IsSalaryValid
        {
            get { return Math.Abs(Basic - 0) > 0.00 && Math.Abs(Hra - 0) > 0.00 && Math.Abs(Da - 0) > 0.00; }
        }

        public double Salary
        {
            get { 
                var net = Basic + Hra + Da;
                return net*(1 - ((double)Tax/100));
            }
        }
    }
}
