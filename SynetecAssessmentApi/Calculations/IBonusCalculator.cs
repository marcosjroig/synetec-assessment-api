using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SynetecAssessmentApi.Calculations
{
    public interface IBonusCalculator
    {
        int GetBonusAmount(int employeeSalary, int totalSalary, int bonusPoolAmount);
    }
}
