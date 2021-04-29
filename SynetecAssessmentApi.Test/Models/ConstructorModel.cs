using AutoMapper;
using SynetecAssessmentApi.Services;

namespace SynetecAssessmentApi.Test.Models
{
    public class ConstructorModel
    {
        public IMapper Mapper { get; set; }
        public IBonusPoolService BonusPoolService { get; set; }
    }
}
