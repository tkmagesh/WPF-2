using System;
using System.ComponentModel;
using System.Windows.Input;

namespace MyFirstWPFApp
{
    public class SalaryCalculatorViewModel : INotifyPropertyChanged
    {
        private double _basic;
        private double _hra;
        private double _da;
        private int _tax;
        private double _salary;
        private SalaryCalculator salaryCalculator;
        public event PropertyChangedEventHandler PropertyChanged;

        public double Basic
        {
            get { return _basic; }
            set
            {
                _basic = value;
                TriggerPropertyChanged("Basic");
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
                TriggerPropertyChanged("IsSalaryValid");
            }
        }

        public double Da
        {
            get { return _da; }
            set { _da = value;
                TriggerPropertyChanged("Da");
                TriggerPropertyChanged("IsSalaryValid");
            }
        }

        public int Tax
        {
            get { return _tax; }
            set { _tax = value;
                TriggerPropertyChanged("Tax");
            }
        }

        public bool IsSalaryValid
        {
            get { return Math.Abs(Basic - 0) > 0.00 && Math.Abs(Hra - 0) > 0.00 && Math.Abs(Da - 0) > 0.00; }
        }

        public SalaryCalculatorViewModel()
        {
            salaryCalculator = new SalaryCalculator();
        }

        private void CalculateSalary()
        {
            Salary = salaryCalculator.CalculateSalary(Basic, Hra, Da, Tax);
        }

        public double Salary { 
            private set { 
                _salary = value;
                TriggerPropertyChanged("Salary");
            } 
            get
            {
                return _salary;
            }  
        }

        public ICommand CalculateSalaryCommand
        {
            get { return new MyCommander(o => this.CalculateSalary(), o => true); }
        }

        private void IncrementSalary()
        {
            Basic = Basic*1.1;
        }

        public ICommand IncrementSalaryCommand
        {
            get { return new MyCommander(o => this.IncrementSalary(), o => true);}
        }
        
    }

    public class MyCommander : ICommand
    {
        private readonly Action<object> _execute;
        private readonly Func<object, bool> _canExecute;

        public MyCommander(Action<object> execute, Func<object,bool> canExecute )
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute(parameter);
        }

        public event EventHandler CanExecuteChanged;
    }
}