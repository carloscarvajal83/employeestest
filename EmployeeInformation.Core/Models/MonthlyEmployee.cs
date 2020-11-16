using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeInformation.Core.Models
{
    public class MonthlyEmployee : Employee
    {
        public override double AnnualSalary
        {
            get
            {
                return MonthlySalary * 12;
            }
        }
    }
}
