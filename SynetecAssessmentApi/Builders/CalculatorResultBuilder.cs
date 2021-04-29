using SynetecAssessmentApi.Domain;
using SynetecAssessmentApi.Dtos;

namespace SynetecAssessmentApi.Builders
{
    public class CalculatorResultBuilder: ICalculatorResultBuilder
    {
        protected BonusPoolCalculatorResultDto ResultDto;

        public CalculatorResultBuilder()
        {
            ResultDto = new BonusPoolCalculatorResultDto();
        }
        public BonusPoolCalculatorResultDto Build() => ResultDto;

        public CalculatorResultBuilder SetEmployee(Employee employee)
        {
            ResultDto.Employee = new EmployeeDto
            {
                Fullname = employee.Fullname,
                JobTitle = employee.JobTitle,
                Salary = employee.Salary
            };

            return this;
        }

        public CalculatorResultBuilder SetDepartment(Department department)
        {
            ResultDto.Employee.Department = new DepartmentDto
            {
                Title = department.Title,
                Description = department.Description
            };

            return this;
        }

        public CalculatorResultBuilder SetAmount(int amount)
        {
            ResultDto.Amount = amount;
            return this;
        }
    }
}
