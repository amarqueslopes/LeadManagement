using LeadManagement.Domain.Models;

namespace LeadManagement.Application.Interfaces
{
    public interface ILeadService
    {
        Task<IEnumerable<Lead>> GetLeadsByStatusAsync(string status);
        Task AcceptLeadAsync(int id);
        Task DeclineLeadAsync(int id);
    }
}
