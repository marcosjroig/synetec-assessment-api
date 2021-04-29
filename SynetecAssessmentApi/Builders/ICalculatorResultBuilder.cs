using SynetecAssessmentApi.Domain;
using SynetecAssessmentApi.Dtos;

namespace SynetecAssessmentApi.Builders
{
    public interface ICalculatorResultBuilder
    {
        BonusPoolCalculatorResultDto Build();
        CalculatorResultBuilder SetEmployee(Employee employee);
        CalculatorResultBuilder SetDepartment(Department department);
        CalculatorResultBuilder SetAmount(int amount);
    }
}
