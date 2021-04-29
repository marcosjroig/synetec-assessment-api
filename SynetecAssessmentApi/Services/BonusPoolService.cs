using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SynetecAssessmentApi.DbContext;
using SynetecAssessmentApi.Domain;
using SynetecAssessmentApi.Dtos;
using SynetecAssessmentApi.Persistence;
using System.Linq;
using SynetecAssessmentApi.Builders;
using SynetecAssessmentApi.Calculations;

namespace SynetecAssessmentApi.Services
{
    public class BonusPoolService : IBonusPoolService
    {
        private readonly IBonusCalculator _bonusCalculator;
        private readonly ICalculatorResultBuilder _calculatorResultBuilder;
        private readonly AppDbContext _dbContext;

        public BonusPoolService(IDbContextBuilder dbContextBuilder, IBonusCalculator bonusCalculator, ICalculatorResultBuilder calculatorResultBuilder)
        {
            _bonusCalculator = bonusCalculator;
            _calculatorResultBuilder = calculatorResultBuilder;
            _dbContext = dbContextBuilder.GetDbContext();
        }

        public async Task<IEnumerable<Employee>> GetEmployeesAsync()
        {
            return await _dbContext
                .Employees
                .Include(e => e.Department)
                .ToListAsync();
        }

        public async Task<BonusPoolCalculatorResultDto> CalculateAsync(int bonusPoolAmount, int selectedEmployeeId)
        {
            //load the details of the selected employee using the Id
            var employee = await GetEmployeeByIdAsync(selectedEmployeeId);

            if (employee != null)
            {
                return _calculatorResultBuilder
                    .SetEmployee(employee)
                    .SetDepartment(employee.Department)
                    .SetAmount(CalculateBonus(employee.Salary, bonusPoolAmount))
                    .Build();
            }

            return null;
        }

        private int CalculateBonus(int salary, int bonusPoolAmount)
        {
            //get the total salary budget for the company
            var totalSalary = GetTotalSalaryBudget();

            //calculate the bonus allocation for the employee
            return _bonusCalculator.GetBonusAmount(salary, totalSalary, bonusPoolAmount);
        }

        private async Task<Employee> GetEmployeeByIdAsync(int employeeId)
        {
            return await _dbContext.Employees
                .Include(e => e.Department)
                .FirstOrDefaultAsync(item => item.Id == employeeId);
        }

        private int GetTotalSalaryBudget()
        {
            return _dbContext.Employees.Sum(item => item.Salary);
        }
    }
}
