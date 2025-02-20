using LeadManagementAPI.Models;

namespace LeadManagementAPI.Repositories.Interfaces
{
    public interface ILeadRepository
    {
        Task<IEnumerable<Lead>> GetInvitedLeadsAsync();
        Task<Lead> GetLeadByIdAsync(int id);
        Task UpdateLeadAsync(Lead lead);
    }
}
