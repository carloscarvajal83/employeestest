using System;

namespace EmployeeInformation.Core.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ContractTypeName { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public string RoleDescription { get; set; }
        public float HourlySalary { get; set; }
        public float MonthlySalary { get; set; }
        public virtual double AnnualSalary { get; }


        public T As<T>()
        {
            var type = typeof(T);
            var instance = Activator.CreateInstance(type);
            if (type.BaseType != null)
            {
                var properties = type.BaseType.GetProperties();
                foreach (var property in properties)
                    if (property.CanWrite)
                        property.SetValue(instance, property.GetValue(this, null), null);
            }
            return (T) instance;
        }

    }
}
