using LeadManagement.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace LeadManagement.Domain.Context
{
    public class LeadContext : DbContext
    {
        public DbSet<Lead> Leads { get; set; }

        public LeadContext(DbContextOptions<LeadContext> options) : base(options) { }
    }
}
