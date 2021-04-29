using AutoMapper;
using SynetecAssessmentApi.Builders;
using SynetecAssessmentApi.Calculations;
using SynetecAssessmentApi.DbContext;
using SynetecAssessmentApi.Mappings;
using SynetecAssessmentApi.Services;
using SynetecAssessmentApi.Test.Models;

namespace SynetecAssessmentApi.Test.Helpers
{
    public static class ControllerHelper
    {
        public static ConstructorModel GetConstructorParameters()
        {

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();

            IDbContextBuilder dbContextBuilder = new DbContextBuilder();
            IBonusCalculator bonusCalculator = new BonusCalculator();
            CalculatorResultBuilder calculatorResultBuilder = new CalculatorResultBuilder();
            IBonusPoolService bonusPoolService = new BonusPoolService(dbContextBuilder, bonusCalculator, calculatorResultBuilder);

            var constructorModel = new ConstructorModel {BonusPoolService = bonusPoolService, Mapper = mapper};

            return constructorModel;
        }
    }
}
