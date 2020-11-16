namespace EmployeeInformation.Core.Models
{
    public class HourlyEmployee : Employee
    {
        public override double AnnualSalary {
            get {
                return 120 * HourlySalary * 12;
            }
        }
    }
}
