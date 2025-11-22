using Domain.Entities.Abstraction;
using Shared_Kernal.Interfaces;


namespace Domain.Entities
{
    public class User : EntityBase<int>, IAggregateRoot
    {
        public CivilInfo UserCivilInfo { get; set; }
        public AccountInfo UserAccountInfo { get; set; }
        public bool IsActive { get; private set; } = false;

        public List<Salary>? Salaries { get; set; }

        

        public User ActivateUser(bool isActive)
        {
            IsActive = isActive;
            return this;
        }

        public decimal BaseSalarySum() => Salaries.Sum(e => e.SalaryCalculations());


        public decimal AverageSalary() => BaseSalarySum() / Salaries.Count; 

        public decimal DetuctTax(int totalSalary) => totalSalary - totalSalary * 0.07m;

        public bool ShouldDetuctTax(int totalSalary) => totalSalary > 10000;

        public string GetUserSalaryStatus() {
            var averageSalary = AverageSalary();
            if (averageSalary > 2000)
                return "GREEN";
            else if (averageSalary < 2000)
                return "RED";
            else
                return "ORANGE";
        }

        public bool IsEmployeeFeasibleFromSalaryCalculation()
        {
            return Salaries!.Count >= 3;
        }
        public User(CivilInfo userCivilInfo, AccountInfo userAccountInfo, List<Salary>? salaries = null)
        {
            UserCivilInfo = userCivilInfo;
            UserAccountInfo = userAccountInfo;
            Salaries = salaries;
            IsActive = true;
        }

        public User() { }
    }
}
