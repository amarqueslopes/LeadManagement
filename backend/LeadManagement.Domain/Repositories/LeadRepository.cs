using LeadManagement.Domain.Context;
using LeadManagement.Domain.Models;
using LeadManagement.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LeadManagement.Domain.Repositories
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
