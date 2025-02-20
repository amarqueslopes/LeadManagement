using LeadManagementAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LeadManagementAPI.Context
{
    public class LeadContext : DbContext
    {
        public DbSet<Lead> Leads { get; set; }

        public LeadContext(DbContextOptions<LeadContext> options) : base(options) { }
    }
}
