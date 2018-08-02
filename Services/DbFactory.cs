using Domain;
using Infrastructure;

namespace Services
{
    public class DbFactory
    {
        public static IDbContext Create()
        {
            return new DemographicsDbContext();
        }
    }
}
