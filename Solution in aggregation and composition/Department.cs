using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution_in_aggregation_and_composition
{
    class Department
    {
        private List<Employee> employees;
        private bool isBudgetExceeded;
        private decimal yearlyBudget;

        internal IReadOnlyList<Employee> Employees { get => employees; }
        public bool IsBudgetExceeded { get => isBudgetExceeded; set => isBudgetExceeded = value; }
        public decimal MonthlyPayout
        {
            get
            {
                return CalculateMonthlyPayout();
            }
        }
        public decimal YearlyPayout
        {
            get
            {
                decimal sum = 0m;
                decimal decPayout;
                decimal decPayoutTop;
                foreach (Employee employee in Employees)
                {
                    decPayout = employee.GetMonthlyPayout() + employee.ChristmasBonus;
                    if (decPayout < Employee.TopTaxLimit)
                    {
                        decPayout *= 1 + Convert.ToDecimal(Employee.NormalTaxRate);
                    }
                    else
                    {
                        decPayoutTop = decPayout - Employee.TopTaxLimit;
                        decPayout -= Employee.TopTaxLimit;
                        decPayout *= 1 + Convert.ToDecimal(Employee.NormalTaxRate);
                        decPayoutTop *= 1 + Convert.ToDecimal(Employee.TopTaxRate);
                        decPayout += decPayoutTop;
                    }
                    sum += employee.GetMonthlyPayout() * 11 + decPayout;
                }
                return sum;
            }
        }
        public decimal YearlyBudget { get => yearlyBudget; set => yearlyBudget = value; }

        public void Add(Employee employee)
        {
            employees.Add(employee);
        }
        public Department(List<Employee> employees, decimal yearlyBudget)
        {
            this.employees = employees;
            YearlyBudget = yearlyBudget;
        }
        public Employee GetEmployeeBy(string ssn)
        {
            return employees.Find(x => x.Ssn == ssn);
        }
        public Employee GetEmployeeBy(string firstname, string lastname)
        {
            return employees.Find(x => x.FirstName == firstname && x.LastName == lastname);
        }
        public void Remove(Employee employee)
        {
            employees.Remove(employee);
        }
        private void CalculateBudgetExcession()
        {
            isBudgetExceeded = YearlyPayout > yearlyBudget;
        }
        private decimal CalculateMonthlyPayout()
        {
            decimal sum = 0m;
            decimal payout;
            decimal payoutTop;
            foreach (Employee employee in Employees)
            {
                payout = employee.GetMonthlyPayout();
                if (payout < Employee.TopTaxLimit)
                {
                    payout *= 1 + Convert.ToDecimal(Employee.NormalTaxRate);
                }
                else
                {
                    payoutTop = payout - Employee.TopTaxLimit;
                    payout -= Employee.TopTaxLimit;
                    payout *= 1 + Convert.ToDecimal(Employee.NormalTaxRate);
                    payoutTop *= 1 + Convert.ToDecimal(Employee.TopTaxRate);
                    payout += payoutTop;
                }
                sum += payout;
            }
            return sum;
        }
    }
}
