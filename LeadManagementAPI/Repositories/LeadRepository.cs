using LeadManagementAPI.Context;
using LeadManagementAPI.Models;
using LeadManagementAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LeadManagementAPI.Repositories
{
    public class LeadRepository : ILeadRepository
    {
        private readonly LeadContext _context;

        public LeadRepository(LeadContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Lead>> GetInvitedLeadsAsync()
        {
            return await _context.Leads.Where(l => l.Status == "Invited").ToListAsync();
        }

        public async Task<Lead> GetLeadByIdAsync(int id)
        {
            return await _context.Leads.FindAsync(id);
        }

        public async Task UpdateLeadAsync(Lead lead)
        {
            _context.Entry(lead).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
