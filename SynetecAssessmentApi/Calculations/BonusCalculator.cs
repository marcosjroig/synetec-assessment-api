namespace SynetecAssessmentApi.Calculations
{
    public class BonusCalculator: IBonusCalculator
    {
        public int GetBonusAmount(int employeeSalary, int totalSalary, int bonusPoolAmount)
        {
            var bonusPercentage = employeeSalary / (decimal)totalSalary;

            return (int)(bonusPercentage * bonusPoolAmount);
        }
    }
}
