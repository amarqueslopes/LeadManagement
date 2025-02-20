using LeadManagement.Domain.Models;

namespace LeadManagement.Domain.Interfaces
{
    public interface ILeadRepository
    {
        Task<IEnumerable<Lead>> GetInvitedLeadsAsync();
        Task<Lead> GetLeadByIdAsync(int id);
        Task UpdateLeadAsync(Lead lead);
    }
}
