using SynetecAssessmentApi.Persistence;

namespace SynetecAssessmentApi.DbContext
{
    public class DbContextBuilder: IDbContextBuilder
    {
        public AppDbContext GetDbContext()
        {
            var dbContextGenerator = new DbContextGenerator();
            
            return dbContextGenerator.AppContext;
        }
    }
}
