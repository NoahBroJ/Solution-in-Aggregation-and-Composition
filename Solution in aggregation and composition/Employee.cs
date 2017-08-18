using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution_in_aggregation_and_composition
{
    class Employee
    {
        private decimal christmasBonus;
        private string firstName;
        private string lastName;
        private decimal monthlyBaseSalary;
        private decimal monthlyBonusSalary;
        private const double normalTaxRate = 0.37;
        private string ssn;
        private const decimal topTaxLimit = 467300m;
        private const double topTaxRate = 0.15;

        public decimal ChristmasBonus { get => christmasBonus; set => christmasBonus = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public decimal MonthlyBaseSalary { get => monthlyBaseSalary; set => monthlyBaseSalary = value; }
        public decimal MonthlyBonusSalary { get => monthlyBonusSalary; set => monthlyBonusSalary = value; }
        public static double NormalTaxRate => normalTaxRate;
        public string Ssn { get => ssn; set => ssn = value; }
        public static decimal TopTaxLimit => topTaxLimit;
        public static double TopTaxRate => topTaxRate;

        public Employee(string firstName, string lastName, string ssn, decimal monthlyBaseSalary, decimal monthlyBonusSalary, decimal christmasBonus)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Ssn = ssn;
            this.MonthlyBaseSalary = monthlyBaseSalary;
            this.MonthlyBonusSalary = monthlyBonusSalary;
            this.ChristmasBonus = christmasBonus;
        }

        public decimal GetMonthlyPayout()
        {
            return MonthlyBaseSalary + MonthlyBonusSalary;
        }

        public decimal GetYearlyPayout()
        {
            return GetMonthlyPayout() * 12 + ChristmasBonus;
        }
    }
}
