using LeadManagement.Domain.Models;

namespace LeadManagement.Application.Interfaces
{
    public interface ILeadService
    {
        Task<IEnumerable<Lead>> GetInvitedLeadsAsync();
        Task AcceptLeadAsync(int id);
        Task DeclineLeadAsync(int id);
    }
}
