using LeadManagement.Domain.Models;

namespace LeadManagement.Domain.Interfaces
{
    public interface ILeadRepository
    {
        Task<IEnumerable<Lead>> GetLeadsByStatusAsync(string status);
        Task<Lead> GetLeadByIdAsync(int id);
        Task UpdateLeadAsync(Lead lead);
        Task PublishEventAsync(object @event);
    }
}
