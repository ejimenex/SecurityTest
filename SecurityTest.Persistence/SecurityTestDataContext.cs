using Microsoft.EntityFrameworkCore;

namespace SecurityTest.Persistence
{
    public class SecurityTestDataContext:DbContext
    {
        public SecurityTestDataContext(DbContextOptions<SecurityTestDataContext> options) : base(options)
        {
        }
    }
}
