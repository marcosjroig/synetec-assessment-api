using SynetecAssessmentApi.Persistence;

namespace SynetecAssessmentApi.DbContext
{
    public interface IDbContextBuilder
    {
        AppDbContext GetDbContext();
    }
}
