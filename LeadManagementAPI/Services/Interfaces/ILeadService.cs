using LeadManagementAPI.Models;

namespace LeadManagementAPI.Services.Interfaces
{
    public interface ILeadService
    {
        Task<IEnumerable<Lead>> GetInvitedLeadsAsync();
        Task AcceptLeadAsync(int id);
        Task DeclineLeadAsync(int id);
    }
}
