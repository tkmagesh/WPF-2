using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyFirstWPFApp
{
    public class SalaryCalculator
    {
        public double CalculateSalary(double Basic, double Hra, double Da, int Tax)
        {
            var net = Basic + Hra + Da;
            return net * (1 - ((double)Tax / 100));
        }
    }
}
